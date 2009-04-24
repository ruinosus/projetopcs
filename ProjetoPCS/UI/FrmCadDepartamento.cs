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
    public partial class FrmCadDepartamento : Form
    {
        private Status status = new Status();
        private Controlador controlador = Controlador.GetInstancia();
        private Departamento departamentoAtual;

        private ArrayList departamentos;
        private ArrayList localidades;
        private ArrayList localidadesDepartamento;

        private bool pesquisando = false;

        private void AdicionarLocalidade()
        {
            btnAdicionarLocalidade.Enabled = cmbLocalidades.Items.Count > 0;

        }

        private void RemoverLocalidade()
        {
            btnRemoverLocalidade.Enabled = (lstLocalidades.Items.Count > 0) && lstLocalidades.SelectedIndex > -1;

        }

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
                        btnAdicionarLocalidade.Enabled = false;
                        btnRemoverLocalidade.Enabled = false;
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
                        AdicionarLocalidade();
                        RemoverLocalidade();
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
                        AdicionarLocalidade();
                        RemoverLocalidade();
                        break;
                    }
                case "Navegação":
                    {
                        btnAnterior.Enabled = bsDepartamento.Position > 0;
                        btnCancelar.Enabled = false;
                        btnGravar.Enabled = false;
                        btnNovo.Enabled = true;
                        btnPrimeiro.Enabled = bsDepartamento.Position > 0;
                        btnProximo.Enabled = bsDepartamento.Position + 1 < bsDepartamento.Count;
                        btnUltimo.Enabled = bsDepartamento.Position + 1 < bsDepartamento.Count;

                        btnRemover.Enabled = bsDepartamento.Count > 0;
                        btnAlterar.Enabled = bsDepartamento.Count > 0;

                        btnAdicionarLocalidade.Enabled = false;
                        btnRemoverLocalidade.Enabled = false;
                        break;
                    }
            }

            
        }

        private void AjustaEdits()
        {
            if (pesquisando == false)
            {
                departamentos = controlador.DepartamentoConsultarTodos();
            }
            else
            {
                departamentos = controlador.DepartamentoConsultarPorNome(txtLocalizar.Text);
            }

            localidades =  controlador.LocalidadeConsultarTodos();

            bsDepartamento.DataSource = departamentos;
            cmbLocalidades.DataSource = localidades;
            cmbLocalidades.DisplayMember = "Nome";
            cmbLocalidades.ValueMember = "Codigo";

           // lstLocalidades.Items.Add(cmbLocalidades.Items[2]);
            


            switch (status.StatusAtual())
            {
                case "Inativa":
                    {
                        txtNome.ReadOnly = true;
                        txtNome.Clear();
                        lstLocalidades.Enabled = false;
                        cmbLocalidades.Enabled = false;
                        cmbLocalidades.Items.Clear();
                        LimparLista();
                        localidadesDepartamento = null;
                        break;
                    }

                case "Inclusão":
                    {
                        txtNome.ReadOnly = false;
                        txtNome.Clear();
                        lstLocalidades.Enabled = true;
                        cmbLocalidades.Enabled = true;
                        //AjustaLista();
                        localidadesDepartamento = new ArrayList();

                        LimparLista();
 
                        break;
                    }
                case "Alteração":
                    {
                        txtNome.ReadOnly = false;
                        lstLocalidades.Enabled = true;
                        cmbLocalidades.Enabled = true;
                        if (localidadesDepartamento.Count > 0)
                        {
                            LimparLista();
                            CarregarLista();
                        }
                        break;
                    }
                case "Navegação":
                    {
                        txtNome.ReadOnly = true;
                        lstLocalidades.Enabled = false;
                        cmbLocalidades.Enabled = false;
                        if (bsDepartamento.Count > 0)
                        {
                            departamentoAtual = (Departamento)departamentos[bsDepartamento.Position];
                            txtNome.Text = departamentoAtual.Nome;
                            if (departamentoAtual.Localidades.Count > 0)
                            {
                                localidadesDepartamento = departamentoAtual.Localidades;
                                LimparLista();
                                CarregarLista();
                            }
                        }
                        lbInformacao.Text = "Quantidades de Departamentos cadastrados: " + bsDepartamento.Count;
                        break;
                    }
            }
        }

        private void CarregarLista()
        {
            //lstLocalidades.Items.Clear();
            lstLocalidades.DataSource = localidadesDepartamento;
            lstLocalidades.DisplayMember = "Nome";
            lstLocalidades.ValueMember = "Codigo";
        }

        private void LimparLista()
        {
            lstLocalidades.DataSource = null;
            lstLocalidades.DisplayMember = "Nome";
            lstLocalidades.ValueMember = "Codigo";
            lstLocalidades.Items.Clear();
        }

        public FrmCadDepartamento()
        {
            InitializeComponent();
        }

        private void FrmCadDepartamento_Load(object sender, EventArgs e)
        {
            status.Navegando();
            AjustaBotoes(); 
        }       

        private void btnNovo_Click(object sender, EventArgs e)
        {
            status.Incluindo();
            AjustaBotoes();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsDepartamento.MovePrevious();
            AjustaBotoes();

        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsDepartamento.MoveNext();
            AjustaBotoes();
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsDepartamento.MoveFirst();
            AjustaBotoes();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsDepartamento.MoveLast();
            AjustaBotoes();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            switch (status.StatusAtual())
            {
                case "Alteração":
                    {

                        departamentoAtual.Nome = txtNome.Text;
                        ArrayList l = null;
                        if (lstLocalidades.Items.Count > 0)
                        {
                            l = new ArrayList();
                            for (int i = 0; i < lstLocalidades.Items.Count; i++)
                            {
                                l.Add(lstLocalidades.Items[i]);
                            }                            
                        }
                        departamentoAtual.Localidades = l;
                      
                        controlador.DepartamentoAlterarDepartamento(departamentoAtual);
                        break;
                    }

                case "Inclusão":
                    {
                        ArrayList l = null;
                        if (lstLocalidades.Items.Count > 0)
                        {
                            l = new ArrayList();
                            for (int i = 0; i < lstLocalidades.Items.Count; i++)
                            {
                                l.Add(lstLocalidades.Items[i]);
                            }                           
                        }
                        Departamento d = new Departamento(0, txtNome.Text, l);
                        controlador.DepartamentoInserirDepartamento(d);                    
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
            controlador.DepartamentoRemoverDepartamento(departamentoAtual.Codigo);
            System.Windows.Forms.MessageBox.Show("Departamento Removido com sucesso.");
            status.Navegando();
            AjustaBotoes();

        }

        private void txtLocalizar_TextChanged(object sender, EventArgs e)
        {
            pesquisando = txtLocalizar.Text.Trim() != "" && txtLocalizar.Text.Trim() != " ";
            status.Navegando();
            AjustaBotoes();
        }

        private void lstLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(((Localidade)localidades[lstLocalidades.SelectedIndex]).Codigo + "");
            AdicionarLocalidade();
            RemoverLocalidade();
        }

        private void cmbLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(((Localidade)localidades[cmbLocalidades.SelectedIndex]).Codigo+"");
        }

        private void btnAdicionarLocalidade_Click(object sender, EventArgs e)
        {
            bool achou = false;

            for (int i = 0; i < lstLocalidades.Items.Count; i++)
            {
                if (((Localidade)lstLocalidades.Items[i]).Codigo == ((Localidade)cmbLocalidades.Items[cmbLocalidades.SelectedIndex]).Codigo)
                {
                    achou = true;
                }
            }


            if (achou == false)
            {
                localidadesDepartamento.Add(cmbLocalidades.Items[cmbLocalidades.SelectedIndex]);
                LimparLista();
                CarregarLista();
                AdicionarLocalidade();
                RemoverLocalidade();
            }
            else
            {
                MessageBox.Show("localidade já adicionada a lista.");
            }
        }

        private void btnRemoverLocalidade_Click(object sender, EventArgs e)
        {
            localidadesDepartamento.RemoveAt(lstLocalidades.SelectedIndex);
            LimparLista();
            CarregarLista();
            AdicionarLocalidade();
            RemoverLocalidade();
        }
    }
}
