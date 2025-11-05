using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace ExcelXML.Services
{
    public static class ExcelWorksheetLoader
    {
        public static DataTable LoadFirstWorksheet(string filePath, out string? worksheetName)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("O caminho do arquivo é obrigatório.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Planilha não encontrada.", filePath);
            }

            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            string connectionString = extension switch
            {
                ".xls" => $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={filePath};Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\";",
                ".xlsx" or ".xlsm" => $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";",
                _ => throw new NotSupportedException($"Extensão '{extension}' não suportada.")
            };

            using var connection = new OleDbConnection(connectionString);
            connection.Open();

            worksheetName = ObterPrimeiraPlanilha(connection);
            if (worksheetName == null)
            {
                throw new InvalidOperationException("Nenhuma planilha foi encontrada no arquivo selecionado.");
            }

            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM [{worksheetName}]";

            using var adapter = new OleDbDataAdapter(command);
            var table = new DataTable(worksheetName);
            adapter.Fill(table);
            return table;
        }

        private static string? ObterPrimeiraPlanilha(OleDbConnection connection)
        {
            var schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (schemaTable == null)
            {
                return null;
            }

            foreach (DataRow row in schemaTable.Rows)
            {
                string? tableName = row["TABLE_NAME"] as string;
                if (string.IsNullOrWhiteSpace(tableName))
                {
                    continue;
                }

                if (tableName!.EndsWith("$", StringComparison.Ordinal) || tableName.EndsWith("$'", StringComparison.Ordinal))
                {
                    return tableName.Trim(''');
                }
            }

            return null;
        }

    }
}
