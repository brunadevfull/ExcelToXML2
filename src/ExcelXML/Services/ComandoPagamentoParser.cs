using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using ExcelXML.Models;

namespace ExcelXML.Services
{
    public static class ComandoPagamentoParser
    {
        private static readonly string[] RequiredColumns =
        {
            "identificador",
            "matricula",
            "alterador",
            "rubrica",
            "tprubrica",
            "formpagto",
            "valcomando"
        };

        public static IReadOnlyList<ComandoPagamento> Parse(DataTable table)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            if (table.Columns.Count == 0)
            {
                throw new InvalidOperationException("A planilha selecionada não possui dados para conversão.");
            }

            var columnMap = CriarMapaColunas(table.Columns);

            var comandos = new List<ComandoPagamento>();
            foreach (DataRow row in table.Rows)
            {
                var valores = RequiredColumns
                    .Select(coluna => ObterValor(row, columnMap[coluna]))
                    .ToArray();

                if (!ComandoPagamento.TryCreate(
                        valores[0],
                        valores[1],
                        valores[2],
                        valores[3],
                        valores[4],
                        valores[5],
                        valores[6],
                        out var comando))
                {
                    continue;
                }

                comandos.Add(comando);
            }

            return comandos;
        }

        private static IReadOnlyDictionary<string, int> CriarMapaColunas(DataColumnCollection columns)
        {
            var map = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < columns.Count; i++)
            {
                map[columns[i].ColumnName] = i;
            }

            foreach (var required in RequiredColumns)
            {
                if (!map.Keys.Any(k => string.Equals(k, required, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new InvalidOperationException($"A coluna obrigatória '{required}' não foi encontrada na planilha selecionada.");
                }
            }

            return RequiredColumns.ToDictionary(
                key => key,
                key => map.First(pair => string.Equals(pair.Key, key, StringComparison.OrdinalIgnoreCase)).Value,
                StringComparer.OrdinalIgnoreCase);
        }

        private static string? ObterValor(DataRow row, int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= row.Table.Columns.Count)
            {
                return null;
            }

            if (row.IsNull(columnIndex))
            {
                return null;
            }

            var valor = row[columnIndex];
            return valor switch
            {
                DateTime dateTime => dateTime.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
                _ => Convert.ToString(valor, CultureInfo.InvariantCulture)
            };
        }
    }
}
