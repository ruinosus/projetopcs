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
        private Status status = new Status();
        private Controlador controlador = Controlador.GetInstancia();
        private Localidade localidadeAtual;
        private ArrayList localidades;
        private bool pesquisando = false;

        private void AjustaBotoes()
        {
            AjustaEdits();

            switch (status.StatusAtual())
            {
                case "Inativa":
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

                case "Inclusão":
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
                case "Alteração":
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
                case "Navegação":
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
        }

        private void AjustaEdits()
        {
            if (pesquisando == false)
            {
                localidades = controlador.LocalidadeConsultarTodos();
            }
            else
            {
                localidades = controlador.LocalidadeConsultarPorNome(txtLocalizar.Text);
            }

            bsLocalidade.DataSource = localidades;

            switch (status.StatusAtual())
            {
                case "Inativa":
                    {
                        txtNome.ReadOnly = true;
                        txtNome.Clear();
                        
                        break;
                    }

                case "Inclusão":
                    {
                        txtNome.ReadOnly = false;
                        txtNome.Clear();
                        
                        break;
                    }
                case "Alteração":
                    {
                        txtNome.ReadOnly = false;
                        
                        break;
                    }
                case "Navegação":
                    {
                        txtNome.ReadOnly = true;
                        if (bsLocalidade.Count > 0)
                        {
                            localidadeAtual = (Localidade)localidades[bsLocalidade.Position] ;
                            txtNome.Text = localidadeAtual.Nome;
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
            status.Incluindo();
            AjustaBotoes();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsLocalidade.MovePrevious();
            AjustaBotoes();

        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsLocalidade.MoveNext();
            AjustaBotoes();
        }

        private void FrmCadLocalidade_Load(object sender, EventArgs e)
        {

            status.Navegando();
            AjustaBotoes();        
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsLocalidade.MoveFirst();
            AjustaBotoes();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsLocalidade.MoveLast();
            AjustaBotoes();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            switch (status.StatusAtual())
            {
                case "Alteração":
                    {
                        localidadeAtual.Nome = txtNome.Text;
                        controlador.LocalidadeAlterarLocalidade(localidadeAtual);
                        break;
                    }

                case "Inclusão":
                    {
                        Localidade l = new Localidade(0, txtNome.Text);
                        controlador.LocalidadeInserirLocalidade(l);
                        break;
                    }
            }
            status.Navegando();
            AjustaBotoes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            status.Navegando();
            AjustaBotoes();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            status.Alterando();
            AjustaBotoes();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Tem certeza que deseja remover?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (d.ToString() == "Yes")
            {
                controlador.LocalidadeRemoverLocalidade(localidadeAtual.Codigo);
                System.Windows.Forms.MessageBox.Show("Localidade Removida com sucesso.");
                status.Navegando();
                AjustaBotoes();
            }

        }

        private void txtLocalizar_TextChanged(object sender, EventArgs e)
        {
            pesquisando = txtLocalizar.Text.Trim() != "" && txtLocalizar.Text.Trim() != " ";
            status.Navegando();
            AjustaBotoes();
        }


    }
}
