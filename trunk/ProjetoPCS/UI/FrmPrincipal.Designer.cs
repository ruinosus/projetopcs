namespace UI
{
    partial class FrmPrincipal
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
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.bnmbnmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LocalidadeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.projetoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.empregadoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dependenteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnmbnmToolStripMenuItem,
            this.cadastroMenu});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(531, 24);
            this.menuPrincipal.TabIndex = 9;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // bnmbnmToolStripMenuItem
            // 
            this.bnmbnmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.bnmbnmToolStripMenuItem.Name = "bnmbnmToolStripMenuItem";
            this.bnmbnmToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.bnmbnmToolStripMenuItem.Text = "Inicio";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // cadastroMenu
            // 
            this.cadastroMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocalidadeMenu,
            this.departamentoMenu,
            this.projetoMenu,
            this.empregadoMenu,
            this.dependenteMenu});
            this.cadastroMenu.Name = "cadastroMenu";
            this.cadastroMenu.Size = new System.Drawing.Size(66, 20);
            this.cadastroMenu.Text = "Cadastro";
            // 
            // LocalidadeMenu
            // 
            this.LocalidadeMenu.Name = "LocalidadeMenu";
            this.LocalidadeMenu.Size = new System.Drawing.Size(152, 22);
            this.LocalidadeMenu.Text = "Localidade";
            this.LocalidadeMenu.Click += new System.EventHandler(this.LocalidadeMenu_Click);
            // 
            // departamentoMenu
            // 
            this.departamentoMenu.Name = "departamentoMenu";
            this.departamentoMenu.Size = new System.Drawing.Size(152, 22);
            this.departamentoMenu.Text = "Departamento";
            this.departamentoMenu.Click += new System.EventHandler(this.departamentoMenu_Click);
            // 
            // projetoMenu
            // 
            this.projetoMenu.Name = "projetoMenu";
            this.projetoMenu.Size = new System.Drawing.Size(152, 22);
            this.projetoMenu.Text = "Projeto";
            // 
            // empregadoMenu
            // 
            this.empregadoMenu.Name = "empregadoMenu";
            this.empregadoMenu.Size = new System.Drawing.Size(152, 22);
            this.empregadoMenu.Text = "Empregado";
            // 
            // dependenteMenu
            // 
            this.dependenteMenu.Name = "dependenteMenu";
            this.dependenteMenu.Size = new System.Drawing.Size(152, 22);
            this.dependenteMenu.Text = "Dependente";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 356);
            this.Controls.Add(this.menuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPrincipal";
            this.Text = "Formulário Principal - Projeto PCS";
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem bnmbnmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroMenu;
        private System.Windows.Forms.ToolStripMenuItem LocalidadeMenu;
        private System.Windows.Forms.ToolStripMenuItem departamentoMenu;
        private System.Windows.Forms.ToolStripMenuItem empregadoMenu;
        private System.Windows.Forms.ToolStripMenuItem projetoMenu;
        private System.Windows.Forms.ToolStripMenuItem dependenteMenu;
    }
}

