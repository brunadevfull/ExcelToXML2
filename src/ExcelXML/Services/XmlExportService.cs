using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using ExcelXML.Models;

namespace ExcelXML.Services
{
    public sealed class XmlExportOptions
    {
        public string Sistema { get; set; } = string.Empty;

        public DateTime DataGeracao { get; set; } = DateTime.Now;

        public DateTime DataRemessa { get; set; } = DateTime.Now;

        public string NomeResponsavel { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        public string Perfil { get; set; } = string.Empty;

        public string TipoPerfilOm { get; set; } = string.Empty;

        public string NIP { get; set; } = string.Empty;

        public string CodPapem { get; set; } = string.Empty;

        public string Folha { get; set; } = string.Empty;

        public string Trigrama { get; set; } = string.Empty;
    }

    public static class XmlExportService
    {
        private static readonly CultureInfo CulturaBrasileira = new("pt-BR");

        public static void Export(string outputPath, XmlExportOptions options, IReadOnlyList<ComandoPagamento> comandos)
        {
            if (string.IsNullOrWhiteSpace(outputPath))
            {
                throw new ArgumentException("Informe o caminho do arquivo de saída.", nameof(outputPath));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (comandos == null || comandos.Count == 0)
            {
                throw new InvalidOperationException("Não há comandos para exportar.");
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? Environment.CurrentDirectory);

            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.GetEncoding("iso-8859-1"),
                Indent = true,
                IndentChars = "  ",
                NewLineChars = Environment.NewLine,
                NewLineHandling = NewLineHandling.Replace
            };

            using var writer = XmlWriter.Create(outputPath, settings);
            writer.WriteStartDocument(true);
            writer.WriteStartElement("ArquivoComandosPagamento");

            writer.WriteElementString("sistema", options.Sistema);
            writer.WriteElementString("dtGeracao", FormatarData(options.DataGeracao));
            writer.WriteElementString("dtRemessa", FormatarData(options.DataRemessa));
            writer.WriteElementString("nome", options.NomeResponsavel);
            writer.WriteElementString("cpf", options.CPF);
            writer.WriteElementString("perfil", options.Perfil);
            writer.WriteElementString("tipoPerfilOM", options.TipoPerfilOm);
            writer.WriteElementString("nip", options.NIP);
            writer.WriteElementString("codPapem", options.CodPapem);
            writer.WriteElementString("qtdeTotal", comandos.Count.ToString(CulturaBrasileira));
            writer.WriteElementString("folha", options.Folha);

            writer.WriteStartElement("listaTrigrama");
            writer.WriteStartElement("trigrama");
            writer.WriteElementString("trigrama", options.Trigrama);

            writer.WriteStartElement("listaComandosPagamento");

            foreach (var comando in comandos)
            {
                writer.WriteStartElement("ComandoPagamento");
                writer.WriteElementString("identificador", comando.Identificador.ToString(CulturaBrasileira));
                writer.WriteElementString("matricula", comando.Matricula);
                writer.WriteElementString("alterador", comando.Alterador);
                writer.WriteElementString("rubrica", comando.Rubrica);
                writer.WriteElementString("tpRubrica", comando.TipoRubrica);
                writer.WriteElementString("formPagto", comando.FormaPagamento);
                writer.WriteElementString("valComando", comando.ValorComando.ToString("0.00", CultureInfo.InvariantCulture));
                writer.WriteEndElement();
            }

            writer.WriteEndElement(); // listaComandosPagamento
            writer.WriteEndElement(); // trigrama
            writer.WriteEndElement(); // listaTrigrama
            writer.WriteEndElement(); // ArquivoComandosPagamento
            writer.WriteEndDocument();
        }

        private static string FormatarData(DateTime data)
        {
            return data.ToString("dd/MM/yyyy HH:mm:ss", CulturaBrasileira);
        }
    }
}
