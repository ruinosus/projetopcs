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
            this.empregadoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dependenteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.projetoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.menuPrincipal.Size = new System.Drawing.Size(706, 24);
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
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // cadastroMenu
            // 
            this.cadastroMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocalidadeMenu,
            this.departamentoMenu,
            this.empregadoMenu,
            this.projetoMenu});
            this.cadastroMenu.Name = "cadastroMenu";
            this.cadastroMenu.Size = new System.Drawing.Size(66, 20);
            this.cadastroMenu.Text = "Cadastro";
            // 
            // LocalidadeMenu
            // 
            this.LocalidadeMenu.Name = "LocalidadeMenu";
            this.LocalidadeMenu.Size = new System.Drawing.Size(150, 22);
            this.LocalidadeMenu.Text = "Localidade";
            this.LocalidadeMenu.Click += new System.EventHandler(this.LocalidadeMenu_Click);
            // 
            // departamentoMenu
            // 
            this.departamentoMenu.Name = "departamentoMenu";
            this.departamentoMenu.Size = new System.Drawing.Size(150, 22);
            this.departamentoMenu.Text = "Departamento";
            this.departamentoMenu.Click += new System.EventHandler(this.departamentoMenu_Click);
            // 
            // empregadoMenu
            // 
            this.empregadoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dependenteMenu});
            this.empregadoMenu.Name = "empregadoMenu";
            this.empregadoMenu.Size = new System.Drawing.Size(150, 22);
            this.empregadoMenu.Text = "Empregado";
            this.empregadoMenu.Click += new System.EventHandler(this.empregadoMenu_Click);
            // 
            // dependenteMenu
            // 
            this.dependenteMenu.Name = "dependenteMenu";
            this.dependenteMenu.Size = new System.Drawing.Size(138, 22);
            this.dependenteMenu.Text = "Dependente";
            this.dependenteMenu.Click += new System.EventHandler(this.dependenteMenu_Click);
            // 
            // projetoMenu
            // 
            this.projetoMenu.Name = "projetoMenu";
            this.projetoMenu.Size = new System.Drawing.Size(150, 22);
            this.projetoMenu.Text = "Projeto";
            this.projetoMenu.Click += new System.EventHandler(this.projetoMenu_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::UI.Properties.Resources.Clients_15_96x96_32bpp;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(152, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 128);
            this.button2.TabIndex = 11;
            this.button2.Text = "Departamentos";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Calibri", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::UI.Properties.Resources.List_1_96x96_32bpp;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.Location = new System.Drawing.Point(422, 132);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(128, 128);
            this.button5.TabIndex = 14;
            this.button5.Text = "Dependentes";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Calibri", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::UI.Properties.Resources.G_Projects_96;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(557, 132);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 128);
            this.button4.TabIndex = 13;
            this.button4.Text = "Projetos";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Calibri", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::UI.Properties.Resources.Add_Card_1_96x96_32bpp;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(287, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 128);
            this.button3.TabIndex = 12;
            this.button3.Text = "Empregados";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::UI.Properties.Resources.World_15_96x96_32bpp;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(17, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 128);
            this.button1.TabIndex = 10;
            this.button1.Text = "Localidades";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 281);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

