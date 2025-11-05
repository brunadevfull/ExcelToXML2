namespace ExcelXML
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeExcel = new System.Windows.Forms.TextBox();
            this.btnLocalizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeArquivoXML = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSistema = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrigrama = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNomeResponsavel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPerfil = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPerfilOM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNIP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFolha = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodPapem = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpGeracao = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpRemessa = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.lblQtdeComandos = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConverter = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNomeExcel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLocalizar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNomeArquivoXML, 1, 1);
            this.tableLayoutPanel1.SetColumnSpan(this.txtNomeArquivoXML, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSistema, 1, 2);
            this.tableLayoutPanel1.SetColumnSpan(this.txtSistema, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTrigrama, 1, 3);
            this.tableLayoutPanel1.SetColumnSpan(this.txtTrigrama, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNomeResponsavel, 1, 4);
            this.tableLayoutPanel1.SetColumnSpan(this.txtNomeResponsavel, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtCPF, 1, 5);
            this.tableLayoutPanel1.SetColumnSpan(this.txtCPF, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtPerfil, 1, 6);
            this.tableLayoutPanel1.SetColumnSpan(this.txtPerfil, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtPerfilOM, 1, 7);
            this.tableLayoutPanel1.SetColumnSpan(this.txtPerfilOM, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtNIP, 1, 8);
            this.tableLayoutPanel1.SetColumnSpan(this.txtNIP, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtFolha, 1, 9);
            this.tableLayoutPanel1.SetColumnSpan(this.txtFolha, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.txtCodPapem, 1, 10);
            this.tableLayoutPanel1.SetColumnSpan(this.txtCodPapem, 2);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.dtpGeracao, 1, 11);
            this.tableLayoutPanel1.SetColumnSpan(this.dtpGeracao, 2);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.dtpRemessa, 1, 12);
            this.tableLayoutPanel1.SetColumnSpan(this.dtpRemessa, 2);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.lblQtdeComandos, 1, 13);
            this.tableLayoutPanel1.SetColumnSpan(this.lblQtdeComandos, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(664, 420);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Planilha Excel";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNomeExcel
            // 
            this.txtNomeExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNomeExcel.Location = new System.Drawing.Point(143, 3);
            this.txtNomeExcel.Name = "txtNomeExcel";
            this.txtNomeExcel.ReadOnly = true;
            this.txtNomeExcel.Size = new System.Drawing.Size(408, 23);
            this.txtNomeExcel.TabIndex = 1;
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLocalizar.Location = new System.Drawing.Point(589, 3);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(72, 24);
            this.btnLocalizar.TabIndex = 2;
            this.btnLocalizar.Text = "Localizar";
            this.btnLocalizar.UseVisualStyleBackColor = true;
            this.btnLocalizar.Click += new System.EventHandler(this.BtnLocalizar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Arquivo XML";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNomeArquivoXML
            // 
            this.txtNomeArquivoXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNomeArquivoXML.Location = new System.Drawing.Point(143, 33);
            this.txtNomeArquivoXML.Name = "txtNomeArquivoXML";
            this.txtNomeArquivoXML.Size = new System.Drawing.Size(518, 23);
            this.txtNomeArquivoXML.TabIndex = 4;
            this.txtNomeArquivoXML.TextChanged += new System.EventHandler(this.TxtNomeArquivoXML_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sistema";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSistema
            // 
            this.txtSistema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSistema.Location = new System.Drawing.Point(143, 63);
            this.txtSistema.Name = "txtSistema";
            this.txtSistema.Size = new System.Drawing.Size(518, 23);
            this.txtSistema.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Trigrama";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTrigrama
            // 
            this.txtTrigrama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTrigrama.Location = new System.Drawing.Point(143, 93);
            this.txtTrigrama.Name = "txtTrigrama";
            this.txtTrigrama.Size = new System.Drawing.Size(518, 23);
            this.txtTrigrama.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nome responsável";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNomeResponsavel
            // 
            this.txtNomeResponsavel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNomeResponsavel.Location = new System.Drawing.Point(143, 123);
            this.txtNomeResponsavel.Name = "txtNomeResponsavel";
            this.txtNomeResponsavel.Size = new System.Drawing.Size(518, 23);
            this.txtNomeResponsavel.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 30);
            this.label6.TabIndex = 11;
            this.label6.Text = "CPF";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCPF
            // 
            this.txtCPF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCPF.Location = new System.Drawing.Point(143, 153);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(518, 23);
            this.txtCPF.TabIndex = 12;
            this.txtCPF.Leave += new System.EventHandler(this.TxtCPF_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 30);
            this.label7.TabIndex = 13;
            this.label7.Text = "Perfil";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPerfil
            // 
            this.txtPerfil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPerfil.Location = new System.Drawing.Point(143, 183);
            this.txtPerfil.Name = "txtPerfil";
            this.txtPerfil.Size = new System.Drawing.Size(518, 23);
            this.txtPerfil.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 30);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tipo Perfil OM";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPerfilOM
            // 
            this.txtPerfilOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPerfilOM.Location = new System.Drawing.Point(143, 213);
            this.txtPerfilOM.Name = "txtPerfilOM";
            this.txtPerfilOM.Size = new System.Drawing.Size(518, 23);
            this.txtPerfilOM.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 30);
            this.label9.TabIndex = 17;
            this.label9.Text = "NIP";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNIP
            // 
            this.txtNIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNIP.Location = new System.Drawing.Point(143, 243);
            this.txtNIP.Name = "txtNIP";
            this.txtNIP.Size = new System.Drawing.Size(518, 23);
            this.txtNIP.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 270);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 30);
            this.label10.TabIndex = 19;
            this.label10.Text = "Folha";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFolha
            // 
            this.txtFolha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFolha.Location = new System.Drawing.Point(143, 273);
            this.txtFolha.Name = "txtFolha";
            this.txtFolha.Size = new System.Drawing.Size(518, 23);
            this.txtFolha.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 300);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 30);
            this.label11.TabIndex = 21;
            this.label11.Text = "Cod. PAPEM";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodPapem
            // 
            this.txtCodPapem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodPapem.Location = new System.Drawing.Point(143, 303);
            this.txtCodPapem.Name = "txtCodPapem";
            this.txtCodPapem.Size = new System.Drawing.Size(518, 23);
            this.txtCodPapem.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 330);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 30);
            this.label12.TabIndex = 23;
            this.label12.Text = "Data geração";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpGeracao
            // 
            this.dtpGeracao.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpGeracao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpGeracao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGeracao.Location = new System.Drawing.Point(143, 333);
            this.dtpGeracao.Name = "dtpGeracao";
            this.dtpGeracao.ShowUpDown = true;
            this.dtpGeracao.Size = new System.Drawing.Size(518, 23);
            this.dtpGeracao.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 360);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 30);
            this.label13.TabIndex = 25;
            this.label13.Text = "Data remessa";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpRemessa
            // 
            this.dtpRemessa.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpRemessa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpRemessa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRemessa.Location = new System.Drawing.Point(143, 363);
            this.dtpRemessa.Name = "dtpRemessa";
            this.dtpRemessa.ShowUpDown = true;
            this.dtpRemessa.Size = new System.Drawing.Size(518, 23);
            this.dtpRemessa.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(3, 390);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 30);
            this.label14.TabIndex = 27;
            this.label14.Text = "Total registros";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQtdeComandos
            // 
            this.lblQtdeComandos.AutoSize = true;
            this.lblQtdeComandos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQtdeComandos.Location = new System.Drawing.Point(143, 390);
            this.lblQtdeComandos.Name = "lblQtdeComandos";
            this.lblQtdeComandos.Size = new System.Drawing.Size(518, 30);
            this.lblQtdeComandos.TabIndex = 28;
            this.lblQtdeComandos.Text = "0 registros";
            this.lblQtdeComandos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnConverter);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 440);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(664, 50);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnConverter
            // 
            this.btnConverter.Enabled = false;
            this.btnConverter.Location = new System.Drawing.Point(556, 13);
            this.btnConverter.Name = "btnConverter";
            this.btnConverter.Size = new System.Drawing.Size(105, 30);
            this.btnConverter.TabIndex = 0;
            this.btnConverter.Text = "Gerar XML";
            this.btnConverter.UseVisualStyleBackColor = true;
            this.btnConverter.Click += new System.EventHandler(this.BtnConverter_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 500);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(700, 540);
            this.Name = "frmPrincipal";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel para XML";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeExcel;
        private System.Windows.Forms.Button btnLocalizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeArquivoXML;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSistema;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTrigrama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNomeResponsavel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPerfil;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPerfilOM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNIP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFolha;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodPapem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpGeracao;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpRemessa;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblQtdeComandos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnConverter;
    }
}
