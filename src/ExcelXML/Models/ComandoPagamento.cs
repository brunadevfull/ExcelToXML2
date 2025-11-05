using System;
using System.Globalization;

namespace ExcelXML.Models
{
    public sealed class ComandoPagamento
    {
        public int Identificador { get; }

        public string Matricula { get; }

        public string Alterador { get; }

        public string Rubrica { get; }

        public string TipoRubrica { get; }

        public string FormaPagamento { get; }

        public decimal ValorComando { get; }

        public ComandoPagamento(
            int identificador,
            string matricula,
            string alterador,
            string rubrica,
            string tipoRubrica,
            string formaPagamento,
            decimal valorComando)
        {
            Identificador = identificador;
            Matricula = matricula;
            Alterador = alterador;
            Rubrica = rubrica;
            TipoRubrica = tipoRubrica;
            FormaPagamento = formaPagamento;
            ValorComando = valorComando;
        }

        public static bool TryCreate(
            string? identificador,
            string? matricula,
            string? alterador,
            string? rubrica,
            string? tipoRubrica,
            string? formaPagamento,
            string? valorComando,
            out ComandoPagamento? comando)
        {
            comando = null;

            if (!int.TryParse(identificador, out int id))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(matricula))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(alterador))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(rubrica))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(tipoRubrica))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(formaPagamento))
            {
                return false;
            }

            if (!decimal.TryParse(valorComando, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                return false;
            }

            comando = new ComandoPagamento(
                id,
                matricula.Trim(),
                alterador.Trim(),
                rubrica.Trim(),
                tipoRubrica.Trim(),
                formaPagamento.Trim(),
                valor);
            return true;
        }
    }
}
