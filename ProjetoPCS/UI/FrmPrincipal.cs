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
        private FrmCadEmpregado frmCadEmpregado = new FrmCadEmpregado();
        private FrmCadDependente frmCadDependente = new FrmCadDependente();
        private FrmCadProjeto frmCadProjeto = new FrmCadProjeto();

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

        private void empregadoMenu_Click(object sender, EventArgs e)
        {
            frmCadEmpregado.ShowDialog();
        }

        private void dependenteMenu_Click(object sender, EventArgs e)
        {
            frmCadDependente.ShowDialog();
        }

        private void projetoMenu_Click(object sender, EventArgs e)
        {
            frmCadProjeto.ShowDialog();
        }
    }
}
