namespace UI
{
    partial class FrmCadProjeto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadProjeto));
            this.lstEmpregado = new System.Windows.Forms.ListBox();
            this.lbEmpregado = new System.Windows.Forms.Label();
            this.cmbEmpregado = new System.Windows.Forms.ComboBox();
            this.lbNome = new System.Windows.Forms.Label();
            this.tlMensagem = new System.Windows.Forms.ToolTip(this.components);
            this.txtNome = new System.Windows.Forms.TextBox();
            this.stInformacao = new System.Windows.Forms.StatusStrip();
            this.lbInformacao = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.cmbLocalidades = new System.Windows.Forms.ComboBox();
            this.lstLocalidades = new System.Windows.Forms.ListBox();
            this.lbLocalidades = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lstDepartamento = new System.Windows.Forms.ListBox();
            this.lbDepartamento = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPrimeiro = new System.Windows.Forms.ToolStripButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripButton();
            this.btnProximo = new System.Windows.Forms.ToolStripButton();
            this.btnUltimo = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRemoverDepartamento = new System.Windows.Forms.Button();
            this.btnAdicionarDepartamento = new System.Windows.Forms.Button();
            this.btnRemoverLocalidade = new System.Windows.Forms.Button();
            this.btnAdicionarLocalidade = new System.Windows.Forms.Button();
            this.btnRemoverEmpregado = new System.Windows.Forms.Button();
            this.btnAdicionarEmpregado = new System.Windows.Forms.Button();
            this.bsProjeto = new System.Windows.Forms.BindingSource(this.components);
            this.stInformacao.SuspendLayout();
            this.tlPrincipal.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProjeto)).BeginInit();
            this.SuspendLayout();
            // 
            // lstEmpregado
            // 
            this.lstEmpregado.FormattingEnabled = true;
            this.lstEmpregado.Location = new System.Drawing.Point(84, 295);
            this.lstEmpregado.Name = "lstEmpregado";
            this.lstEmpregado.Size = new System.Drawing.Size(220, 43);
            this.lstEmpregado.TabIndex = 160;
            this.lstEmpregado.SelectedIndexChanged += new System.EventHandler(this.lstEmpregado_SelectedIndexChanged);
            // 
            // lbEmpregado
            // 
            this.lbEmpregado.AutoSize = true;
            this.lbEmpregado.Location = new System.Drawing.Point(12, 272);
            this.lbEmpregado.Name = "lbEmpregado";
            this.lbEmpregado.Size = new System.Drawing.Size(64, 13);
            this.lbEmpregado.TabIndex = 159;
            this.lbEmpregado.Text = "Empregado:";
            // 
            // cmbEmpregado
            // 
            this.cmbEmpregado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpregado.FormattingEnabled = true;
            this.cmbEmpregado.Location = new System.Drawing.Point(84, 268);
            this.cmbEmpregado.Name = "cmbEmpregado";
            this.cmbEmpregado.Size = new System.Drawing.Size(220, 21);
            this.cmbEmpregado.TabIndex = 158;
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(38, 100);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(38, 13);
            this.lbNome.TabIndex = 157;
            this.lbNome.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(84, 93);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(255, 20);
            this.txtNome.TabIndex = 156;
            // 
            // stInformacao
            // 
            this.stInformacao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbInformacao});
            this.stInformacao.Location = new System.Drawing.Point(0, 393);
            this.stInformacao.Name = "stInformacao";
            this.stInformacao.Size = new System.Drawing.Size(532, 22);
            this.stInformacao.TabIndex = 155;
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
            this.tlPrincipal.Location = new System.Drawing.Point(0, 54);
            this.tlPrincipal.Name = "tlPrincipal";
            this.tlPrincipal.Size = new System.Drawing.Size(420, 39);
            this.tlPrincipal.TabIndex = 154;
            this.tlPrincipal.Text = "toolStrip1";
            // 
            // btnNovo
            // 
            this.btnNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNovo.Image = global::UI.Properties.Resources.New_Doc_5_32x32_32bpp;
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(36, 36);
            this.btnNovo.ToolTipText = "Clique aqui para incluir um novo projeto";
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
            this.txtLocalizar.Size = new System.Drawing.Size(165, 39);
            this.txtLocalizar.ToolTipText = "Informe o nome ou parte dele para localiza-lo";
            this.txtLocalizar.TextChanged += new System.EventHandler(this.txtLocalizar_TextChanged);
            // 
            // cmbLocalidades
            // 
            this.cmbLocalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidades.FormattingEnabled = true;
            this.cmbLocalidades.Location = new System.Drawing.Point(84, 128);
            this.cmbLocalidades.Name = "cmbLocalidades";
            this.cmbLocalidades.Size = new System.Drawing.Size(212, 21);
            this.cmbLocalidades.TabIndex = 165;
            // 
            // lstLocalidades
            // 
            this.lstLocalidades.FormattingEnabled = true;
            this.lstLocalidades.Location = new System.Drawing.Point(84, 164);
            this.lstLocalidades.Name = "lstLocalidades";
            this.lstLocalidades.Size = new System.Drawing.Size(212, 17);
            this.lstLocalidades.TabIndex = 164;
            // 
            // lbLocalidades
            // 
            this.lbLocalidades.AutoSize = true;
            this.lbLocalidades.Location = new System.Drawing.Point(17, 132);
            this.lbLocalidades.Name = "lbLocalidades";
            this.lbLocalidades.Size = new System.Drawing.Size(59, 13);
            this.lbLocalidades.TabIndex = 163;
            this.lbLocalidades.Text = "Localidade";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(84, 198);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(213, 21);
            this.cmbDepartamento.TabIndex = 170;
            // 
            // lstDepartamento
            // 
            this.lstDepartamento.FormattingEnabled = true;
            this.lstDepartamento.Location = new System.Drawing.Point(84, 232);
            this.lstDepartamento.Name = "lstDepartamento";
            this.lstDepartamento.Size = new System.Drawing.Size(213, 17);
            this.lstDepartamento.TabIndex = 169;
            // 
            // lbDepartamento
            // 
            this.lbDepartamento.AutoSize = true;
            this.lbDepartamento.Location = new System.Drawing.Point(-1, 202);
            this.lbDepartamento.Name = "lbDepartamento";
            this.lbDepartamento.Size = new System.Drawing.Size(77, 13);
            this.lbDepartamento.TabIndex = 168;
            this.lbDepartamento.Text = "Departamento:";
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
            this.toolStrip1.Location = new System.Drawing.Point(182, 354);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(187, 39);
            this.toolStrip1.TabIndex = 173;
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
            this.btnAnterior.Text = ">";
            this.btnAnterior.ToolTipText = "Vai para o proximo elemento";
            this.btnAnterior.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // btnProximo
            // 
            this.btnProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnProximo.Image = global::UI.Properties.Resources.Forward___Next_5_32x32_32bpp;
            this.btnProximo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(36, 36);
            this.btnProximo.Text = ">>";
            this.btnProximo.ToolTipText = "Vai para o último elemento";
            this.btnProximo.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // btnUltimo
            // 
            this.btnUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUltimo.Image = global::UI.Properties.Resources.Forward_2_5_32x32_32bpp;
            this.btnUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(36, 36);
            this.btnUltimo.Text = "<";
            this.btnUltimo.ToolTipText = "Vai para o elemento anterior";
            this.btnUltimo.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.projetos1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(532, 50);
            this.pictureBox1.TabIndex = 174;
            this.pictureBox1.TabStop = false;
            // 
            // btnRemoverDepartamento
            // 
            this.btnRemoverDepartamento.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoverDepartamento.Image")));
            this.btnRemoverDepartamento.Location = new System.Drawing.Point(306, 224);
            this.btnRemoverDepartamento.Name = "btnRemoverDepartamento";
            this.btnRemoverDepartamento.Size = new System.Drawing.Size(32, 32);
            this.btnRemoverDepartamento.TabIndex = 172;
            this.btnRemoverDepartamento.UseVisualStyleBackColor = true;
            this.btnRemoverDepartamento.Click += new System.EventHandler(this.btnRemoverDepartamento_Click);
            // 
            // btnAdicionarDepartamento
            // 
            this.btnAdicionarDepartamento.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarDepartamento.Image")));
            this.btnAdicionarDepartamento.Location = new System.Drawing.Point(306, 192);
            this.btnAdicionarDepartamento.Name = "btnAdicionarDepartamento";
            this.btnAdicionarDepartamento.Size = new System.Drawing.Size(32, 32);
            this.btnAdicionarDepartamento.TabIndex = 171;
            this.btnAdicionarDepartamento.UseVisualStyleBackColor = true;
            this.btnAdicionarDepartamento.Click += new System.EventHandler(this.btnAdicionarDepartamento_Click);
            // 
            // btnRemoverLocalidade
            // 
            this.btnRemoverLocalidade.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoverLocalidade.Image")));
            this.btnRemoverLocalidade.Location = new System.Drawing.Point(306, 156);
            this.btnRemoverLocalidade.Name = "btnRemoverLocalidade";
            this.btnRemoverLocalidade.Size = new System.Drawing.Size(32, 32);
            this.btnRemoverLocalidade.TabIndex = 167;
            this.btnRemoverLocalidade.UseVisualStyleBackColor = true;
            this.btnRemoverLocalidade.Click += new System.EventHandler(this.btnRemoverLocalidade_Click);
            // 
            // btnAdicionarLocalidade
            // 
            this.btnAdicionarLocalidade.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarLocalidade.Image")));
            this.btnAdicionarLocalidade.Location = new System.Drawing.Point(306, 121);
            this.btnAdicionarLocalidade.Name = "btnAdicionarLocalidade";
            this.btnAdicionarLocalidade.Size = new System.Drawing.Size(32, 32);
            this.btnAdicionarLocalidade.TabIndex = 166;
            this.btnAdicionarLocalidade.UseVisualStyleBackColor = true;
            this.btnAdicionarLocalidade.Click += new System.EventHandler(this.btnAdicionarLocalidade_Click);
            // 
            // btnRemoverEmpregado
            // 
            this.btnRemoverEmpregado.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoverEmpregado.Image")));
            this.btnRemoverEmpregado.Location = new System.Drawing.Point(307, 300);
            this.btnRemoverEmpregado.Name = "btnRemoverEmpregado";
            this.btnRemoverEmpregado.Size = new System.Drawing.Size(32, 32);
            this.btnRemoverEmpregado.TabIndex = 162;
            this.btnRemoverEmpregado.UseVisualStyleBackColor = true;
            this.btnRemoverEmpregado.Click += new System.EventHandler(this.btnRemoverEmpregado_Click);
            // 
            // btnAdicionarEmpregado
            // 
            this.btnAdicionarEmpregado.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarEmpregado.Image")));
            this.btnAdicionarEmpregado.Location = new System.Drawing.Point(307, 262);
            this.btnAdicionarEmpregado.Name = "btnAdicionarEmpregado";
            this.btnAdicionarEmpregado.Size = new System.Drawing.Size(32, 32);
            this.btnAdicionarEmpregado.TabIndex = 161;
            this.btnAdicionarEmpregado.UseVisualStyleBackColor = true;
            this.btnAdicionarEmpregado.Click += new System.EventHandler(this.btnAdicionarEmpregado_Click);
            // 
            // FrmCadProjeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 415);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnRemoverDepartamento);
            this.Controls.Add(this.btnAdicionarDepartamento);
            this.Controls.Add(this.cmbDepartamento);
            this.Controls.Add(this.lstDepartamento);
            this.Controls.Add(this.lbDepartamento);
            this.Controls.Add(this.btnRemoverLocalidade);
            this.Controls.Add(this.btnAdicionarLocalidade);
            this.Controls.Add(this.cmbLocalidades);
            this.Controls.Add(this.lstLocalidades);
            this.Controls.Add(this.lbLocalidades);
            this.Controls.Add(this.btnRemoverEmpregado);
            this.Controls.Add(this.btnAdicionarEmpregado);
            this.Controls.Add(this.lstEmpregado);
            this.Controls.Add(this.lbEmpregado);
            this.Controls.Add(this.cmbEmpregado);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.stInformacao);
            this.Controls.Add(this.tlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCadProjeto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastrar Projetos";
            this.Load += new System.EventHandler(this.FormCadProjeto_Load);
            this.stInformacao.ResumeLayout(false);
            this.stInformacao.PerformLayout();
            this.tlPrincipal.ResumeLayout(false);
            this.tlPrincipal.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProjeto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoverEmpregado;
        private System.Windows.Forms.Button btnAdicionarEmpregado;
        private System.Windows.Forms.ListBox lstEmpregado;
        private System.Windows.Forms.Label lbEmpregado;
        private System.Windows.Forms.BindingSource bsProjeto;
        private System.Windows.Forms.ComboBox cmbEmpregado;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.ToolTip tlMensagem;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.StatusStrip stInformacao;
        private System.Windows.Forms.ToolStripStatusLabel lbInformacao;
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
        private System.Windows.Forms.Button btnRemoverLocalidade;
        private System.Windows.Forms.Button btnAdicionarLocalidade;
        private System.Windows.Forms.ComboBox cmbLocalidades;
        private System.Windows.Forms.ListBox lstLocalidades;
        private System.Windows.Forms.Label lbLocalidades;
        private System.Windows.Forms.Button btnRemoverDepartamento;
        private System.Windows.Forms.Button btnAdicionarDepartamento;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.ListBox lstDepartamento;
        private System.Windows.Forms.Label lbDepartamento;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPrimeiro;
        private System.Windows.Forms.ToolStripButton btnAnterior;
        private System.Windows.Forms.ToolStripButton btnProximo;
        private System.Windows.Forms.ToolStripButton btnUltimo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}