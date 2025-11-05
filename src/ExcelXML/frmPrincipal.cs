using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ExcelXML.Models;
using ExcelXML.Services;
using ExcelXML.Utilities;

namespace ExcelXML
{
    public partial class frmPrincipal : Form
    {
        private readonly OpenFileDialog _openFileDialog;
        private readonly SaveFileDialog _saveFileDialog;
        private IReadOnlyList<ComandoPagamento>? _comandos;

        public frmPrincipal()
        {
            InitializeComponent();
            Icon = SystemIcons.Application;

            _openFileDialog = new OpenFileDialog
            {
                Title = "Selecionar planilha do Excel",
                Filter = "Planilhas Excel (*.xlsx;*.xls)|*.xlsx;*.xls|Todos os arquivos (*.*)|*.*",
                CheckFileExists = true,
                Multiselect = false
            };

            _saveFileDialog = new SaveFileDialog
            {
                Title = "Salvar arquivo XML",
                Filter = "Arquivo XML (*.xml)|*.xml",
                AddExtension = true,
                DefaultExt = "xml",
                OverwritePrompt = true
            };

            dtpGeracao.Value = DateTime.Now;
            dtpRemessa.Value = DateTime.Now;

            AtualizarEstadoInterface();
        }

        private void BtnLocalizar_Click(object? sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            txtNomeExcel.Text = _openFileDialog.FileName;
            DefinirSugestaoNomeArquivoXml(_openFileDialog.FileName);
            CarregarPlanilha(_openFileDialog.FileName);
        }

        private void DefinirSugestaoNomeArquivoXml(string caminhoPlanilha)
        {
            if (string.IsNullOrWhiteSpace(caminhoPlanilha))
            {
                return;
            }

            var pasta = Path.GetDirectoryName(caminhoPlanilha) ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var nomeBase = Path.GetFileNameWithoutExtension(caminhoPlanilha);
            txtNomeArquivoXML.Text = Path.Combine(pasta, nomeBase + ".xml");
        }

        private void CarregarPlanilha(string caminho)
        {
            try
            {
                var tabela = ExcelWorksheetLoader.LoadFirstWorksheet(caminho, out _);
                _comandos = ComandoPagamentoParser.Parse(tabela);
                AtualizarResumoComandos();
                AtualizarEstadoInterface();
            }
            catch (Exception ex)
            {
                _comandos = null;
                lblQtdeComandos.Text = "0 registros";
                AtualizarEstadoInterface();
                MessageBox.Show(this, $"Falha ao abrir a planilha: {ex.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarEstadoInterface()
        {
            var dadosCarregados = _comandos != null && _comandos.Count > 0;
            btnConverter.Enabled = dadosCarregados && !string.IsNullOrWhiteSpace(txtNomeArquivoXML.Text);
        }

        private void BtnConverter_Click(object? sender, EventArgs e)
        {
            if (_comandos == null || _comandos.Count == 0)
            {
                MessageBox.Show(this, "Carregue uma planilha antes de converter.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string caminhoSaida = txtNomeArquivoXML.Text.Trim();
            if (string.IsNullOrEmpty(caminhoSaida))
            {
                if (_saveFileDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                caminhoSaida = _saveFileDialog.FileName;
                txtNomeArquivoXML.Text = caminhoSaida;
            }

            if (!CpfValidator.IsValid(txtCPF.Text))
            {
                MessageBox.Show(this, "Informe um CPF válido antes de gerar o XML.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPF.Focus();
                return;
            }

            try
            {
                var options = new XmlExportOptions
                {
                    Sistema = txtSistema.Text.Trim(),
                    DataGeracao = dtpGeracao.Value,
                    DataRemessa = dtpRemessa.Value,
                    NomeResponsavel = txtNomeResponsavel.Text.Trim(),
                    CPF = txtCPF.Text.Trim(),
                    Perfil = txtPerfil.Text.Trim(),
                    TipoPerfilOm = txtPerfilOM.Text.Trim(),
                    NIP = txtNIP.Text.Trim(),
                    CodPapem = txtCodPapem.Text.Trim(),
                    Folha = txtFolha.Text.Trim(),
                    Trigrama = txtTrigrama.Text.Trim()
                };

                XmlExportService.Export(caminhoSaida, options, _comandos);

                MessageBox.Show(this, "Arquivo XML gerado com sucesso!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Erro ao gerar XML: {ex.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtNomeArquivoXML_TextChanged(object? sender, EventArgs e)
        {
            AtualizarEstadoInterface();
        }

        private void TxtCPF_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCPF.Text))
            {
                return;
            }

            if (CpfValidator.IsValid(txtCPF.Text))
            {
                return;
            }

            MessageBox.Show(this, "CPF inválido. Verifique o valor informado.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCPF.Focus();
        }

        private void AtualizarResumoComandos()
        {
            if (_comandos == null)
            {
                lblQtdeComandos.Text = "0 registros";
                return;
            }

            lblQtdeComandos.Text = _comandos.Count == 1
                ? "1 registro"
                : $"{_comandos.Count} registros";
        }
    }
}
