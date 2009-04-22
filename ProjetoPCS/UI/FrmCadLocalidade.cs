using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocios;
using ClassesBasicas;

namespace UI
{
    public partial class FrmCadLocalidade : Form
    {
        public FrmCadLocalidade()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Controlador controlador = Controlador.GetInstancia();
            //DateTime data = new DateTime(1987, 04, 09);
            //Dependente dependente = new Dependente(0, "Filho de Jeff", data, 'M', "Filho");
            //controlador.DependenteInserirDependente(1, dependente);
            Dependente dependente = controlador.DependenteConsultarPorCodigo(2);
            DateTime data = dependente.DataNascimento;
            MessageBox.Show(data.Day+"/"+data.Month+"/"+data.Year);


            //Controlador controlador = Controlador.GetInstancia();

            //Localidade localidade = new Localidade(0, "Localidade teste");
            //controlador.LocalidadeInserirLocalidade(localidade);
        }
    }
}
