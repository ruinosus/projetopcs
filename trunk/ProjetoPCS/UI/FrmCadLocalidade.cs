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
using System.Collections;

namespace UI
{
    public partial class FrmCadLocalidade : Form
    {
        private Controlador controlador = Controlador.GetInstancia();
        //private Localidade localidade = new Localidade();
        private ArrayList localidades = new ArrayList();

        private void AjustaBotoes(Controlador.Status status)
        {

            localidades = controlador.LocalidadeConsultarTodos();
            bsLocalidade.DataSource = localidades;
            switch (status)
            {
                case Controlador.Status.Inativa:
                    {
                        btnAnterior.Enabled = false;
                        btnCancelar.Enabled = false;
                        btnGravar.Enabled = false;
                        btnNovo.Enabled = true;
                        btnPrimeiro.Enabled = false;
                        btnProximo.Enabled = false;
                        btnUltimo.Enabled = false;
                        btnRemover.Enabled = false;
                        btnAlterar.Enabled = false;
                        break;
                    }

                case Controlador.Status.Inclusao:
                    {
                        btnAnterior.Enabled = false;
                        btnCancelar.Enabled = true;
                        btnGravar.Enabled = true;
                        btnNovo.Enabled = false;
                        btnPrimeiro.Enabled = false;
                        btnProximo.Enabled = false;
                        btnUltimo.Enabled = false;
                        btnRemover.Enabled = false;
                        btnAlterar.Enabled = false;
                        break;
                    }
                case Controlador.Status.Alteracao:
                    {
                        btnAnterior.Enabled = false;
                        btnCancelar.Enabled = true;
                        btnGravar.Enabled = true;
                        btnNovo.Enabled = false;
                        btnPrimeiro.Enabled = false;
                        btnProximo.Enabled = false;
                        btnUltimo.Enabled = false;
                        btnRemover.Enabled = false;
                        btnAlterar.Enabled = false;
                        break;
                    }
                case Controlador.Status.Navegacao:
                    {
                        btnAnterior.Enabled = bsLocalidade.Position > 0 ;
                        btnCancelar.Enabled = false;
                        btnGravar.Enabled = false;
                        btnNovo.Enabled = true;
                        btnPrimeiro.Enabled = bsLocalidade.Position > 0 ;
                        btnProximo.Enabled = bsLocalidade.Position +1 < bsLocalidade.Count;
                        btnUltimo.Enabled = bsLocalidade.Position +1 < bsLocalidade.Count ; 

                        btnRemover.Enabled = bsLocalidade.Count > 0;
                        btnAlterar.Enabled = bsLocalidade.Count > 0;
                        break;
                    }
            }

            AjustaEdits(status);
        }

        private void AjustaEdits(Controlador.Status status)
        {
            switch (status)
            {
                case Controlador.Status.Inativa:
                    {
                        txtNome.ReadOnly = true;
                        txtNome.Clear();
                        
                        break;
                    }

                case Controlador.Status.Inclusao:
                    {
                        txtNome.ReadOnly = false;
                        txtNome.Clear();
                        
                        break;
                    }
                case Controlador.Status.Alteracao:
                    {
                        txtNome.ReadOnly = false;
                        
                        break;
                    }
                case Controlador.Status.Navegacao:
                    {
                        txtNome.ReadOnly = true;
                        if (bsLocalidade.Count > 0)
                        {
                            //localidade = ;
                            txtNome.Text = ((Localidade)localidades[bsLocalidade.Position]).Nome;
                        }
                        lbInformacao.Text ="Quantidades de Localidades cadastradas: " + bsLocalidade.Count;
                        break;
                    }
            }          
            

        }

        public FrmCadLocalidade()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            AjustaBotoes(Controlador.Status.Inclusao);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            bsLocalidade.MovePrevious();
            AjustaBotoes(Controlador.Status.Navegacao);

        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            bsLocalidade.MoveNext();
            AjustaBotoes(Controlador.Status.Navegacao);
        }

        private void FrmCadLocalidade_Load(object sender, EventArgs e)
        {
            //localidades.Add(new Localidade(1, "Goiana"));
            //localidades.Add(new Localidade(2, "tambau"));
            //localidades.Add(new Localidade(3, "bla bla bla"));
            
            AjustaBotoes(Controlador.Status.Navegacao);        
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            bsLocalidade.MoveFirst();
            AjustaBotoes(Controlador.Status.Navegacao);
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            bsLocalidade.MoveLast();
            AjustaBotoes(Controlador.Status.Navegacao);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Localidade localidade = new Localidade(0, txtNome.Text);
            controlador.LocalidadeInserirLocalidade(localidade);
            AjustaBotoes(Controlador.Status.Navegacao);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AjustaBotoes(Controlador.Status.Navegacao);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AjustaBotoes(Controlador.Status.Alteracao);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            controlador.LocalidadeRemoverLocalidade(((Localidade)localidades[bsLocalidade.Position]).Codigo);
            System.Windows.Forms.MessageBox.Show("Localidade Removida com sucesso.");
            AjustaBotoes(Controlador.Status.Navegacao);

        }


    }
}
