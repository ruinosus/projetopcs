namespace UI
{
    partial class FrmCadDependente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.stInformacao = new System.Windows.Forms.StatusStrip();
            this.lbInformacao = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlMensagem = new System.Windows.Forms.ToolTip(this.components);
            this.tlPrincipal = new System.Windows.Forms.ToolStrip();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGravar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAlterar = new System.Windows.Forms.ToolStripButton();
            this.btnRemover = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lbLocalizar = new System.Windows.Forms.ToolStripLabel();
            this.txtLocalizar = new System.Windows.Forms.ToolStripTextBox();
            this.lbNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lbDataNascimento = new System.Windows.Forms.Label();
            this.mskDataNascimento = new System.Windows.Forms.MaskedTextBox();
            this.gpbSexo = new System.Windows.Forms.GroupBox();
            this.rdSexoMasculino = new System.Windows.Forms.RadioButton();
            this.rdSexoFeminino = new System.Windows.Forms.RadioButton();
            this.lstEmpregado = new System.Windows.Forms.ListBox();
            this.lbEmpregado = new System.Windows.Forms.Label();
            this.cmbEmpregado = new System.Windows.Forms.ComboBox();
            this.lbGrauParentesco = new System.Windows.Forms.Label();
            this.cmbGrauParentesco = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPrimeiro = new System.Windows.Forms.ToolStripButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripButton();
            this.btnProximo = new System.Windows.Forms.ToolStripButton();
            this.btnUltimo = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRemoverEmpregado = new System.Windows.Forms.Button();
            this.btnAdicionarEmpregado = new System.Windows.Forms.Button();
            this.bsDependente = new System.Windows.Forms.BindingSource(this.components);
            this.stInformacao.SuspendLayout();
            this.tlPrincipal.SuspendLayout();
            this.gpbSexo.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDependente)).BeginInit();
            this.SuspendLayout();
            // 
            // stInformacao
            // 
            this.stInformacao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbInformacao});
            this.stInformacao.Location = new System.Drawing.Point(0, 299);
            this.stInformacao.Name = "stInformacao";
            this.stInformacao.Size = new System.Drawing.Size(474, 22);
            this.stInformacao.TabIndex = 140;
            // 
            // lbInformacao
            // 
            this.lbInformacao.Name = "lbInformacao";
            this.lbInformacao.Size = new System.Drawing.Size(68, 17);
            this.lbInformacao.Text = "informação";
            // 
            // tlPrincipal
            // 
            this.tlPrincipal.Dock = System.Windows.Forms.DockStyle.None;
            this.tlPrincipal.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tlPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNovo,
            this.toolStripSeparator1,
            this.btnGravar,
            this.btnCancelar,
            this.toolStripSeparator2,
            this.btnAlterar,
            this.btnRemover,
            this.toolStripSeparator4,
            this.lbLocalizar,
            this.txtLocalizar});
            this.tlPrincipal.Location = new System.Drawing.Point(0, 53);
            this.tlPrincipal.Name = "tlPrincipal";
            this.tlPrincipal.Size = new System.Drawing.Size(455, 39);
            this.tlPrincipal.TabIndex = 139;
            this.tlPrincipal.Text = "toolStrip1";
            // 
            // btnNovo
            // 
            this.btnNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNovo.Image = global::UI.Properties.Resources.New_Doc_5_32x32_32bpp;
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(36, 36);
            this.btnNovo.ToolTipText = "Clique aqui para incluir um novo dependente";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnGravar
            // 
            this.btnGravar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGravar.Image = global::UI.Properties.Resources.Save_5_32x32_32bpp;
            this.btnGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(36, 36);
            this.btnGravar.ToolTipText = "Clique aqui para confirmar";
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancelar.Image = global::UI.Properties.Resources.Stop_5_32x32_32bpp;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(36, 36);
            this.btnCancelar.ToolTipText = "Clique aqui para cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnAlterar
            // 
            this.btnAlterar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlterar.Image = global::UI.Properties.Resources.Write_5_32x32_32bpp;
            this.btnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(36, 36);
            this.btnAlterar.ToolTipText = "Clique aqui para alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemover.Image = global::UI.Properties.Resources.Delete_6_32x32_32bpp;
            this.btnRemover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(36, 36);
            this.btnRemover.ToolTipText = "Clique aqui para remover";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // lbLocalizar
            // 
            this.lbLocalizar.Name = "lbLocalizar";
            this.lbLocalizar.Size = new System.Drawing.Size(43, 36);
            this.lbLocalizar.Text = "Nome:";
            // 
            // txtLocalizar
            // 
            this.txtLocalizar.Name = "txtLocalizar";
            this.txtLocalizar.Size = new System.Drawing.Size(200, 39);
            this.txtLocalizar.ToolTipText = "Informe o nome ou parte dele para localiza-lo";
            this.txtLocalizar.TextChanged += new System.EventHandler(this.txtLocalizar_TextChanged);
            this.txtLocalizar.Click += new System.EventHandler(this.txtLocalizar_Click);
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(4, 97);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(38, 13);
            this.lbNome.TabIndex = 142;
            this.lbNome.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(42, 93);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(252, 20);
            this.txtNome.TabIndex = 141;
            // 
            // lbDataNascimento
            // 
            this.lbDataNascimento.AutoSize = true;
            this.lbDataNascimento.Location = new System.Drawing.Point(293, 97);
            this.lbDataNascimento.Name = "lbDataNascimento";
            this.lbDataNascimento.Size = new System.Drawing.Size(107, 13);
            this.lbDataNascimento.TabIndex = 144;
            this.lbDataNascimento.Text = "Data de Nascimento:";
            // 
            // mskDataNascimento
            // 
            this.mskDataNascimento.Location = new System.Drawing.Point(402, 93);
            this.mskDataNascimento.Mask = "00/00/0000";
            this.mskDataNascimento.Name = "mskDataNascimento";
            this.mskDataNascimento.ResetOnPrompt = false;
            this.mskDataNascimento.ResetOnSpace = false;
            this.mskDataNascimento.Size = new System.Drawing.Size(68, 20);
            this.mskDataNascimento.TabIndex = 143;
            this.mskDataNascimento.ValidatingType = typeof(System.DateTime);
            // 
            // gpbSexo
            // 
            this.gpbSexo.Controls.Add(this.rdSexoMasculino);
            this.gpbSexo.Controls.Add(this.rdSexoFeminino);
            this.gpbSexo.Location = new System.Drawing.Point(3, 123);
            this.gpbSexo.Name = "gpbSexo";
            this.gpbSexo.Size = new System.Drawing.Size(181, 50);
            this.gpbSexo.TabIndex = 145;
            this.gpbSexo.TabStop = false;
            this.gpbSexo.Text = "Sexo:";
            // 
            // rdSexoMasculino
            // 
            this.rdSexoMasculino.AutoSize = true;
            this.rdSexoMasculino.Checked = true;
            this.rdSexoMasculino.Location = new System.Drawing.Point(13, 17);
            this.rdSexoMasculino.Name = "rdSexoMasculino";
            this.rdSexoMasculino.Size = new System.Drawing.Size(73, 17);
            this.rdSexoMasculino.TabIndex = 2;
            this.rdSexoMasculino.TabStop = true;
            this.rdSexoMasculino.Text = "Masculino";
            this.rdSexoMasculino.UseVisualStyleBackColor = true;
            // 
            // rdSexoFeminino
            // 
            this.rdSexoFeminino.AutoSize = true;
            this.rdSexoFeminino.Location = new System.Drawing.Point(97, 17);
            this.rdSexoFeminino.Name = "rdSexoFeminino";
            this.rdSexoFeminino.Size = new System.Drawing.Size(67, 17);
            this.rdSexoFeminino.TabIndex = 1;
            this.rdSexoFeminino.Text = "Feminino";
            this.rdSexoFeminino.UseVisualStyleBackColor = true;
            // 
            // lstEmpregado
            // 
            this.lstEmpregado.FormattingEnabled = true;
            this.lstEmpregado.Location = new System.Drawing.Point(76, 220);
            this.lstEmpregado.Name = "lstEmpregado";
            this.lstEmpregado.Size = new System.Drawing.Size(220, 17);
            this.lstEmpregado.TabIndex = 151;
            // 
            // lbEmpregado
            // 
            this.lbEmpregado.AutoSize = true;
            this.lbEmpregado.Location = new System.Drawing.Point(6, 182);
            this.lbEmpregado.Name = "lbEmpregado";
            this.lbEmpregado.Size = new System.Drawing.Size(64, 13);
            this.lbEmpregado.TabIndex = 150;
            this.lbEmpregado.Text = "Empregado:";
            // 
            // cmbEmpregado
            // 
            this.cmbEmpregado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpregado.FormattingEnabled = true;
            this.cmbEmpregado.Location = new System.Drawing.Point(76, 179);
            this.cmbEmpregado.Name = "cmbEmpregado";
            this.cmbEmpregado.Size = new System.Drawing.Size(220, 21);
            this.cmbEmpregado.TabIndex = 149;
            // 
            // lbGrauParentesco
            // 
            this.lbGrauParentesco.AutoSize = true;
            this.lbGrauParentesco.Location = new System.Drawing.Point(192, 142);
            this.lbGrauParentesco.Name = "lbGrauParentesco";
            this.lbGrauParentesco.Size = new System.Drawing.Size(105, 13);
            this.lbGrauParentesco.TabIndex = 159;
            this.lbGrauParentesco.Text = "Grau de Parentesco:";
            // 
            // cmbGrauParentesco
            // 
            this.cmbGrauParentesco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrauParentesco.FormattingEnabled = true;
            this.cmbGrauParentesco.Items.AddRange(new object[] {
            "Filho(a)",
            "Esposo(a)",
            "Pai",
            "Mãe",
            "Irmão(ã)",
            "Sobrinho(a)",
            "Avô(ó)",
            "Primo(a)",
            "Outro"});
            this.cmbGrauParentesco.Location = new System.Drawing.Point(300, 138);
            this.cmbGrauParentesco.Name = "cmbGrauParentesco";
            this.cmbGrauParentesco.Size = new System.Drawing.Size(170, 21);
            this.cmbGrauParentesco.TabIndex = 158;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrimeiro,
            this.btnAnterior,
            this.btnProximo,
            this.btnUltimo});
            this.toolStrip1.Location = new System.Drawing.Point(158, 258);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(187, 39);
            this.toolStrip1.TabIndex = 160;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPrimeiro
            // 
            this.btnPrimeiro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrimeiro.Image = global::UI.Properties.Resources.Back_2_5_32x32_32bpp;
            this.btnPrimeiro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrimeiro.Name = "btnPrimeiro";
            this.btnPrimeiro.Size = new System.Drawing.Size(36, 36);
            this.btnPrimeiro.Text = "<<";
            this.btnPrimeiro.ToolTipText = "Vai para o primeiro elemento";
            this.btnPrimeiro.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnterior.Image = global::UI.Properties.Resources.Back___Previous_5_32x32_32bpp;
            this.btnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(36, 36);
            this.btnAnterior.Text = "<";
            this.btnAnterior.ToolTipText = "Vai para o elemento anterior";
            this.btnAnterior.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // btnProximo
            // 
            this.btnProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnProximo.Image = global::UI.Properties.Resources.Forward___Next_5_32x32_32bpp;
            this.btnProximo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(36, 36);
            this.btnProximo.Text = ">";
            this.btnProximo.ToolTipText = "Vai para o proximo elemento";
            this.btnProximo.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // btnUltimo
            // 
            this.btnUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUltimo.Image = global::UI.Properties.Resources.Forward_2_5_32x32_32bpp;
            this.btnUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(36, 36);
            this.btnUltimo.Text = ">>";
            this.btnUltimo.ToolTipText = "Vai para o último elemento";
            this.btnUltimo.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.dependentes1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(473, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 161;
            this.pictureBox1.TabStop = false;
            // 
            // btnRemoverEmpregado
            // 
            this.btnRemoverEmpregado.Image = global::UI.Properties.Resources.Delete_21_24x24_32bpp;
            this.btnRemoverEmpregado.Location = new System.Drawing.Point(299, 212);
            this.btnRemoverEmpregado.Name = "btnRemoverEmpregado";
            this.btnRemoverEmpregado.Size = new System.Drawing.Size(32, 32);
            this.btnRemoverEmpregado.TabIndex = 153;
            this.btnRemoverEmpregado.UseVisualStyleBackColor = true;
            this.btnRemoverEmpregado.Click += new System.EventHandler(this.btnRemoverEmpregado_Click);
            // 
            // btnAdicionarEmpregado
            // 
            this.btnAdicionarEmpregado.Image = global::UI.Properties.Resources.Add_21_24x24_32bpp;
            this.btnAdicionarEmpregado.Location = new System.Drawing.Point(299, 173);
            this.btnAdicionarEmpregado.Name = "btnAdicionarEmpregado";
            this.btnAdicionarEmpregado.Size = new System.Drawing.Size(32, 32);
            this.btnAdicionarEmpregado.TabIndex = 152;
            this.btnAdicionarEmpregado.UseVisualStyleBackColor = true;
            this.btnAdicionarEmpregado.Click += new System.EventHandler(this.btnAdicionarEmpregado_Click);
            // 
            // FrmCadDependente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 321);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lbGrauParentesco);
            this.Controls.Add(this.cmbGrauParentesco);
            this.Controls.Add(this.btnRemoverEmpregado);
            this.Controls.Add(this.btnAdicionarEmpregado);
            this.Controls.Add(this.lstEmpregado);
            this.Controls.Add(this.lbEmpregado);
            this.Controls.Add(this.cmbEmpregado);
            this.Controls.Add(this.gpbSexo);
            this.Controls.Add(this.lbDataNascimento);
            this.Controls.Add(this.mskDataNascimento);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.stInformacao);
            this.Controls.Add(this.tlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCadDependente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastrar Dependentes";
            this.Load += new System.EventHandler(this.FrmCadDependente_Load);
            this.stInformacao.ResumeLayout(false);
            this.stInformacao.PerformLayout();
            this.tlPrincipal.ResumeLayout(false);
            this.tlPrincipal.PerformLayout();
            this.gpbSexo.ResumeLayout(false);
            this.gpbSexo.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDependente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsDependente;
        private System.Windows.Forms.StatusStrip stInformacao;
        private System.Windows.Forms.ToolStripStatusLabel lbInformacao;
        private System.Windows.Forms.ToolTip tlMensagem;
        private System.Windows.Forms.ToolStrip tlPrincipal;
        private System.Windows.Forms.ToolStripButton btnNovo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnGravar;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnAlterar;
        private System.Windows.Forms.ToolStripButton btnRemover;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lbLocalizar;
        private System.Windows.Forms.ToolStripTextBox txtLocalizar;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lbDataNascimento;
        private System.Windows.Forms.MaskedTextBox mskDataNascimento;
        private System.Windows.Forms.GroupBox gpbSexo;
        private System.Windows.Forms.RadioButton rdSexoMasculino;
        private System.Windows.Forms.RadioButton rdSexoFeminino;
        private System.Windows.Forms.Button btnRemoverEmpregado;
        private System.Windows.Forms.Button btnAdicionarEmpregado;
        private System.Windows.Forms.ListBox lstEmpregado;
        private System.Windows.Forms.Label lbEmpregado;
        private System.Windows.Forms.ComboBox cmbEmpregado;
        private System.Windows.Forms.Label lbGrauParentesco;
        private System.Windows.Forms.ComboBox cmbGrauParentesco;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPrimeiro;
        private System.Windows.Forms.ToolStripButton btnAnterior;
        private System.Windows.Forms.ToolStripButton btnProximo;
        private System.Windows.Forms.ToolStripButton btnUltimo;
        private System.Windows.Forms.PictureBox pictureBox1;


    }
}