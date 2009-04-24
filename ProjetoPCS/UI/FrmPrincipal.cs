using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassesBasicas;
using Negocios;
using System.Collections;

namespace UI
{
    public partial class FrmPrincipal : Form
    {
        private FrmCadLocalidade frmCadLocalidade = new FrmCadLocalidade();
        private FrmCadDepartamento frmCadDepartamento = new FrmCadDepartamento();

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LocalidadeMenu_Click(object sender, EventArgs e)
        {
            frmCadLocalidade.ShowDialog();
        }

        private void departamentoMenu_Click(object sender, EventArgs e)
        {
            frmCadDepartamento.ShowDialog();
        }
    }
}
