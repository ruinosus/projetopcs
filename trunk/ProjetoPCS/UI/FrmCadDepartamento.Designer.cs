namespace UI
{
    partial class FrmCadDepartamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadDepartamento));
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
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.txtLocalizar = new System.Windows.Forms.ToolStripTextBox();
            this.lbNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.cmbLocalidades = new System.Windows.Forms.ComboBox();
            this.lbLocalidades = new System.Windows.Forms.Label();
            this.bsDepartamento = new System.Windows.Forms.BindingSource(this.components);
            this.lstLocalidades = new System.Windows.Forms.ListBox();
            this.btnAdicionarLocalidade = new System.Windows.Forms.Button();
            this.btnRemoverLocalidade = new System.Windows.Forms.Button();
            this.tlMensagem = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPrimeiro = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAnterior = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnProximo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUltimo = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.stInformacao.SuspendLayout();
            this.tlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDepartamento)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // stInformacao
            // 
            this.stInformacao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbInformacao});
            this.stInformacao.Location = new System.Drawing.Point(0, 288);
            this.stInformacao.Name = "stInformacao";
            this.stInformacao.Size = new System.Drawing.Size(474, 22);
            this.stInformacao.TabIndex = 136;
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
            this.toolStripSeparator3,
            this.txtLocalizar});
            this.tlPrincipal.Location = new System.Drawing.Point(0, 45);
            this.tlPrincipal.Name = "tlPrincipal";
            this.tlPrincipal.Size = new System.Drawing.Size(412, 39);
            this.tlPrincipal.TabIndex = 135;
            this.tlPrincipal.Text = "toolStrip1";
            // 
            // btnNovo
            // 
            this.btnNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(36, 36);
            this.btnNovo.ToolTipText = "Clique aqui para incluir um novo departamento";
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
            this.btnGravar.Image = ((System.Drawing.Image)(resources.GetObject("btnGravar.Image")));
            this.btnGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(36, 36);
            this.btnGravar.ToolTipText = "Clique aqui para confirmar";
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
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
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(36, 36);
            this.btnAlterar.ToolTipText = "Clique aqui para alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemover.Image = ((System.Drawing.Image)(resources.GetObject("btnRemover.Image")));
            this.btnRemover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(36, 36);
            this.btnRemover.ToolTipText = "Clique aqui para remover";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
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
            this.lbNome.Location = new System.Drawing.Point(26, 100);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(38, 13);
            this.lbNome.TabIndex = 138;
            this.lbNome.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(77, 100);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(347, 20);
            this.txtNome.TabIndex = 137;
            // 
            // cmbLocalidades
            // 
            this.cmbLocalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidades.FormattingEnabled = true;
            this.cmbLocalidades.Location = new System.Drawing.Point(70, 139);
            this.cmbLocalidades.Name = "cmbLocalidades";
            this.cmbLocalidades.Size = new System.Drawing.Size(191, 21);
            this.cmbLocalidades.TabIndex = 140;
            this.cmbLocalidades.SelectedIndexChanged += new System.EventHandler(this.cmbLocalidades_SelectedIndexChanged);
            // 
            // lbLocalidades
            // 
            this.lbLocalidades.AutoSize = true;
            this.lbLocalidades.Location = new System.Drawing.Point(5, 144);
            this.lbLocalidades.Name = "lbLocalidades";
            this.lbLocalidades.Size = new System.Drawing.Size(59, 13);
            this.lbLocalidades.TabIndex = 138;
            this.lbLocalidades.Text = "Localidade";
            this.lbLocalidades.Click += new System.EventHandler(this.lbLocalidades_Click);
            // 
            // lstLocalidades
            // 
            this.lstLocalidades.FormattingEnabled = true;
            this.lstLocalidades.Location = new System.Drawing.Point(307, 139);
            this.lstLocalidades.Name = "lstLocalidades";
            this.lstLocalidades.Size = new System.Drawing.Size(120, 95);
            this.lstLocalidades.TabIndex = 139;
            this.lstLocalidades.SelectedIndexChanged += new System.EventHandler(this.lstLocalidades_SelectedIndexChanged);
            // 
            // btnAdicionarLocalidade
            // 
            this.btnAdicionarLocalidade.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarLocalidade.Image")));
            this.btnAdicionarLocalidade.Location = new System.Drawing.Point(268, 139);
            this.btnAdicionarLocalidade.Name = "btnAdicionarLocalidade";
            this.btnAdicionarLocalidade.Size = new System.Drawing.Size(36, 36);
            this.btnAdicionarLocalidade.TabIndex = 141;
            this.btnAdicionarLocalidade.UseVisualStyleBackColor = true;
            this.btnAdicionarLocalidade.Click += new System.EventHandler(this.btnAdicionarLocalidade_Click);
            // 
            // btnRemoverLocalidade
            // 
            this.btnRemoverLocalidade.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoverLocalidade.Image")));
            this.btnRemoverLocalidade.Location = new System.Drawing.Point(433, 139);
            this.btnRemoverLocalidade.Name = "btnRemoverLocalidade";
            this.btnRemoverLocalidade.Size = new System.Drawing.Size(36, 36);
            this.btnRemoverLocalidade.TabIndex = 142;
            this.btnRemoverLocalidade.UseVisualStyleBackColor = true;
            this.btnRemoverLocalidade.Click += new System.EventHandler(this.btnRemoverLocalidade_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrimeiro,
            this.toolStripSeparator4,
            this.btnAnterior,
            this.toolStripSeparator6,
            this.btnProximo,
            this.toolStripSeparator5,
            this.btnUltimo});
            this.toolStrip1.Location = new System.Drawing.Point(135, 245);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(174, 39);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 143;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPrimeiro
            // 
            this.btnPrimeiro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrimeiro.Image = ((System.Drawing.Image)(resources.GetObject("btnPrimeiro.Image")));
            this.btnPrimeiro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrimeiro.Name = "btnPrimeiro";
            this.btnPrimeiro.Size = new System.Drawing.Size(36, 36);
            this.btnPrimeiro.Text = "<<";
            this.btnPrimeiro.ToolTipText = "Vai para o primeiro elemento";
            this.btnPrimeiro.Click += new System.EventHandler(this.btnPrimeiro_Click_1);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // btnAnterior
            // 
            this.btnAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
            this.btnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(36, 36);
            this.btnAnterior.Text = "<";
            this.btnAnterior.ToolTipText = "Vai para o elemento anterior";
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click_1);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // btnProximo
            // 
            this.btnProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnProximo.Image = ((System.Drawing.Image)(resources.GetObject("btnProximo.Image")));
            this.btnProximo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(36, 36);
            this.btnProximo.Text = ">";
            this.btnProximo.ToolTipText = "Vai para o proximo elemento";
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click_1);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // btnUltimo
            // 
            this.btnUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUltimo.Image = ((System.Drawing.Image)(resources.GetObject("btnUltimo.Image")));
            this.btnUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(36, 36);
            this.btnUltimo.Text = ">>";
            this.btnUltimo.ToolTipText = "Vai para o último elemento";
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(474, 50);
            this.pictureBox1.TabIndex = 144;
            this.pictureBox1.TabStop = false;
            // 
            // FrmCadDepartamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 310);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnRemoverLocalidade);
            this.Controls.Add(this.btnAdicionarLocalidade);
            this.Controls.Add(this.cmbLocalidades);
            this.Controls.Add(this.lstLocalidades);
            this.Controls.Add(this.lbLocalidades);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.stInformacao);
            this.Controls.Add(this.tlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCadDepartamento";
            this.Text = "Cadastrar Departamentos";
            this.Load += new System.EventHandler(this.FrmCadDepartamento_Load);
            this.stInformacao.ResumeLayout(false);
            this.stInformacao.PerformLayout();
            this.tlPrincipal.ResumeLayout(false);
            this.tlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDepartamento)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox txtLocalizar;
        private System.Windows.Forms.BindingSource bsDepartamento;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.ComboBox cmbLocalidades;
        private System.Windows.Forms.Label lbLocalidades;
        private System.Windows.Forms.ListBox lstLocalidades;
        private System.Windows.Forms.Button btnAdicionarLocalidade;
        private System.Windows.Forms.Button btnRemoverLocalidade;
        private System.Windows.Forms.ToolTip tlMensagem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPrimeiro;
        private System.Windows.Forms.ToolStripButton btnAnterior;
        private System.Windows.Forms.ToolStripButton btnProximo;
        private System.Windows.Forms.ToolStripButton btnUltimo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}