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
    public partial class FrmCadProjeto : Form
    {

        private Status status = new Status();
        private Controlador controlador = Controlador.GetInstancia();
        private Projeto projetoAtual;

        private ArrayList projetos;
        private ArrayList empregados;
        private ArrayList empregadosProjeto;
        private ArrayList departamentos;
        private ArrayList localidades;

        private bool pesquisando = false;

        private void CarregarListaEmpregado()
        {
            //lstLocalidades.Items.Clear();
            lstEmpregado.DataSource = empregadosProjeto;
            lstEmpregado.DisplayMember = "Nome";
            lstEmpregado.ValueMember = "Codigo";
        }

        private void LimparListaEmpregado()
        {
            lstEmpregado.DataSource = null;
            //lstEmpregado.DisplayMember = "Nome";
            //lstEmpregado.ValueMember = "Codigo";
            lstEmpregado.Items.Clear();
        }

        private void AdicionarEmpregado()
        {
            btnAdicionarEmpregado.Enabled = cmbEmpregado.Items.Count > 0 ;
        }

        private void RemoverEmpregado()
        {
            btnRemoverEmpregado.Enabled = (lstEmpregado.Items.Count > 0) && lstEmpregado.SelectedIndex > -1;
        }

        private void AdicionarLocalidade()
        {
            btnAdicionarLocalidade.Enabled = cmbLocalidades.Items.Count > 0 && lstLocalidades.Items.Count < 1;
        }

        private void RemoverLocalidade()
        {
            btnRemoverLocalidade.Enabled = (lstLocalidades.Items.Count > 0);
        }

        private void AdicionarDepartamento()
        {
            btnAdicionarDepartamento.Enabled = cmbDepartamento.Items.Count > 0 && lstDepartamento.Items.Count < 1;
        }

        private void RemoverDepartamento()
        {
            btnRemoverDepartamento.Enabled = (lstDepartamento.Items.Count > 0);
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

                        btnAdicionarEmpregado.Enabled = false;
                        btnRemoverEmpregado.Enabled = false;

                        btnAdicionarLocalidade.Enabled = false;
                        btnRemoverLocalidade.Enabled = false;

                        btnAdicionarDepartamento.Enabled = false;
                        btnRemoverDepartamento.Enabled = false;

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

                        AdicionarEmpregado();
                        RemoverEmpregado();

                        AdicionarLocalidade();
                        RemoverLocalidade();

                        AdicionarDepartamento();
                        RemoverDepartamento();
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

                        AdicionarEmpregado();
                        RemoverEmpregado();

                        AdicionarLocalidade();
                        RemoverLocalidade();

                        AdicionarDepartamento();
                        RemoverDepartamento();
                        break;
                    }
                case "Navegação":
                    {
                        btnAnterior.Enabled = bsProjeto.Position > 0;
                        btnCancelar.Enabled = false;
                        btnGravar.Enabled = false;
                        btnNovo.Enabled = true;
                        btnPrimeiro.Enabled = bsProjeto.Position > 0;
                        btnProximo.Enabled = bsProjeto.Position + 1 < bsProjeto.Count;
                        btnUltimo.Enabled = bsProjeto.Position + 1 < bsProjeto.Count;

                        btnRemover.Enabled = bsProjeto.Count > 0;
                        btnAlterar.Enabled = bsProjeto.Count > 0;

                        btnAdicionarEmpregado.Enabled = false;
                        btnRemoverEmpregado.Enabled = false;

                        btnAdicionarLocalidade.Enabled = false;
                        btnRemoverLocalidade.Enabled = false;

                        btnAdicionarDepartamento.Enabled = false;
                        btnRemoverDepartamento.Enabled = false;
                        break;
                    }
            }


        }

        private void AjustaEdits()
        {
            if (pesquisando == false)
            {
                projetos = controlador.ProjetoConsultarTodos();
            }
            else
            {
                projetos = controlador.ProjetoConsultarPorNome(txtLocalizar.Text);
            }
            bsProjeto.DataSource = projetos;

            empregados = controlador.EmpregadoConsultarTodos();
            if (empregados.Count > 0)
            {
                cmbEmpregado.DataSource = empregados;
                cmbEmpregado.DisplayMember = "Nome";
                cmbEmpregado.ValueMember = "Codigo";
                lstEmpregado.DisplayMember = "Nome";
                lstEmpregado.ValueMember = "Codigo";
            }

            localidades = controlador.LocalidadeConsultarTodos();
            if (localidades.Count > 0)
            {
                cmbLocalidades.DataSource = localidades;
                cmbLocalidades.DisplayMember = "Nome";
                cmbLocalidades.ValueMember = "Codigo";
                lstLocalidades.DisplayMember = "Nome";
                lstLocalidades.ValueMember = "Codigo";
            }

            departamentos = controlador.DepartamentoConsultarTodos();
            if (departamentos.Count > 0)
            {
                cmbDepartamento.DataSource = departamentos;
                cmbDepartamento.DisplayMember = "Nome";
                cmbDepartamento.ValueMember = "Codigo";
                lstDepartamento.DisplayMember = "Nome";
                lstDepartamento.ValueMember = "Codigo";
            }


            switch (status.StatusAtual())
            {
                case "Inativa":
                    {
                        txtNome.ReadOnly = true;
                        txtNome.Clear();

                        cmbEmpregado.Enabled = false;
                        lstEmpregado.Enabled = false;

                        cmbLocalidades.Enabled = false;
                        lstLocalidades.Enabled = false;

                        cmbDepartamento.Enabled = false;
                        lstDepartamento.Enabled = false;

                        LimparListaEmpregado();


                        break;
                    }

                case "Inclusão":
                    {
                        txtNome.ReadOnly = false;
                        txtNome.Clear();

                        cmbEmpregado.Enabled = true;
                        lstEmpregado.Enabled = true;
                        //lstEmpregado.Items.Clear();


                        cmbLocalidades.Enabled = true;
                        lstLocalidades.Enabled = true;
                        lstLocalidades.Items.Clear();

                        cmbDepartamento.Enabled = true;
                        lstDepartamento.Enabled = true;
                        lstDepartamento.Items.Clear();

                        empregadosProjeto = new ArrayList();

                        LimparListaEmpregado();

                        break;
                    }
                case "Alteração":
                    {
                        txtNome.ReadOnly = false;

                        cmbEmpregado.Enabled = true;
                        lstEmpregado.Enabled = true;
                        
                        cmbLocalidades.Enabled = true;
                        lstLocalidades.Enabled = true;

                        cmbDepartamento.Enabled = true;
                        lstDepartamento.Enabled = true;

                        if (empregadosProjeto.Count > 0)
                        {
                            LimparListaEmpregado();
                            CarregarListaEmpregado();
                        }
                        break;
                    }
                case "Navegação":
                    {
                        txtNome.ReadOnly = true;
                        txtNome.Clear();

                        cmbEmpregado.Enabled = false;
                        lstEmpregado.Enabled = false;
                        //lstEmpregado.Items.Clear();

                        cmbLocalidades.Enabled = false;
                        lstLocalidades.Enabled = false;
                        lstLocalidades.Items.Clear();

                        cmbDepartamento.Enabled = false;
                        lstDepartamento.Enabled = false;
                        lstDepartamento.Items.Clear();

                        if (bsProjeto.Count > 0)
                        {
                            projetoAtual = (Projeto)projetos[bsProjeto.Position];

                            txtNome.Text = projetoAtual.Nome;

                            if ( projetoAtual.Empregados != null && projetoAtual.Empregados.Count > 0 )
                            {
                                empregadosProjeto = projetoAtual.Empregados;
                                LimparListaEmpregado();
                                CarregarListaEmpregado();
                            }
                            else
                            {
                                empregadosProjeto = new ArrayList();
                                LimparListaEmpregado();
                                //CarregarLista();
                            }

                            lstLocalidades.Items.Add(projetoAtual.Localidade);
                            lstDepartamento.Items.Add(projetoAtual.Departamento);

                        }
                        lbInformacao.Text = "Quantidades de Projetos cadastrados: " + bsProjeto.Count;
                        break;
                    }
            }
        }

        public FrmCadProjeto()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            status.Incluindo();
            AjustaBotoes();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            bool validacao = true;

            if (txtNome.Text.Trim() == "" && (validacao == true))
            {
                validacao = false;
                tlMensagem.ToolTipTitle = "Campo inválido";
                tlMensagem.Show("O campo não pode ser vazio", txtNome);
            }

            if (!(lstLocalidades.Items.Count > 0) && (validacao == true))
            {
                validacao = false;
                tlMensagem.ToolTipTitle = "Campo inválido";
                tlMensagem.Show("Deve ser informado a localidade do projeto", lstLocalidades);
                btnAdicionarEmpregado.Focus();
            }

            if (!(lstDepartamento.Items.Count > 0) && (validacao == true))
            {
                validacao = false;
                tlMensagem.ToolTipTitle = "Campo inválido";
                tlMensagem.Show("Deve ser informado o departamento do projeto", lstDepartamento);
                btnAdicionarEmpregado.Focus();
            }


            if (validacao)
            {
                switch (status.StatusAtual())
                {
                    case "Alteração":
                        {

                            projetoAtual.Nome = txtNome.Text;
                            ArrayList emp = null;
                            if (lstEmpregado.Items.Count > 0)
                            {
                                emp = new ArrayList();
                                for (int i = 0; i < lstEmpregado.Items.Count; i++)
                                {
                                    emp.Add(lstEmpregado.Items[i]);
                                }
                            }
                            projetoAtual.Empregados = emp;

                            projetoAtual.Localidade = (Localidade)lstLocalidades.Items[0];

                            projetoAtual.Departamento = (Departamento)lstDepartamento.Items[0];

                            controlador.ProjetoAlterarProjeto(projetoAtual);
                            break;
                        }

                    case "Inclusão":
                        {
                            ArrayList emp = null;
                            if (lstEmpregado.Items.Count > 0)
                            {
                                emp = new ArrayList();
                                for (int i = 0; i < lstEmpregado.Items.Count; i++)
                                {
                                    emp.Add(lstEmpregado.Items[i]);
                                }
                            }

                            Localidade localidade = (Localidade)lstLocalidades.Items[0];

                            Departamento departamento = (Departamento)lstDepartamento.Items[0];

                            Projeto p = new Projeto(0, txtNome.Text, departamento, localidade, emp);

                            controlador.ProjetoInserirProjeto(p);
                            break;
                        }
                }
                status.Navegando();
                AjustaBotoes();
            }
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
                controlador.ProjetoRemoverProjeto(projetoAtual.Codigo);
                System.Windows.Forms.MessageBox.Show("Projeto Removido com sucesso.");
                status.Navegando();
                AjustaBotoes();
            }
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsProjeto.MoveFirst();
            AjustaBotoes();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsProjeto.MovePrevious();
            AjustaBotoes();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsProjeto.MoveNext();
            AjustaBotoes();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsProjeto.MoveLast();
            AjustaBotoes();
        }

        private void txtLocalizar_TextChanged(object sender, EventArgs e)
        {
            pesquisando = txtLocalizar.Text.Trim() != "" && txtLocalizar.Text.Trim() != " ";
            status.Navegando();
            AjustaBotoes();
        }

        private void btnAdicionarLocalidade_Click(object sender, EventArgs e)
        {
            lstLocalidades.Items.Add(cmbLocalidades.Items[cmbLocalidades.SelectedIndex]);
            AdicionarLocalidade();
            RemoverLocalidade();
        }

        private void btnRemoverLocalidade_Click(object sender, EventArgs e)
        {
            lstLocalidades.Items.Clear();
            AdicionarLocalidade();
            RemoverLocalidade();
        }

        private void btnAdicionarDepartamento_Click(object sender, EventArgs e)
        {
            lstDepartamento.Items.Add(cmbDepartamento.Items[cmbDepartamento.SelectedIndex]);
            AdicionarDepartamento();
            RemoverDepartamento();
        }

        private void btnRemoverDepartamento_Click(object sender, EventArgs e)
        {
            lstDepartamento.Items.Clear();
            AdicionarDepartamento();
            RemoverDepartamento();
        }

        private void btnAdicionarEmpregado_Click(object sender, EventArgs e)
        {
            bool achou = false;

            for (int i = 0; i < lstEmpregado.Items.Count; i++)
            {
                if (((Empregado)lstEmpregado.Items[i]).Codigo == ((Empregado)cmbEmpregado.Items[cmbEmpregado.SelectedIndex]).Codigo)
                {
                    achou = true;
                }
            }


            if (achou == false)
            {
                empregadosProjeto.Add(cmbEmpregado.Items[cmbEmpregado.SelectedIndex]);
                LimparListaEmpregado();
                CarregarListaEmpregado();
                AdicionarEmpregado();
                RemoverEmpregado();
            }
            else
            {
                tlMensagem.ToolTipTitle = "Valor já informado";
                tlMensagem.Show("Empregado já adicionada a lista", lstEmpregado);
            }
        }

        private void btnRemoverEmpregado_Click(object sender, EventArgs e)
        {
            empregadosProjeto.RemoveAt(lstEmpregado.SelectedIndex);
            LimparListaEmpregado();
            CarregarListaEmpregado();
            AdicionarEmpregado();
            RemoverEmpregado();
        }

        private void FormCadProjeto_Load(object sender, EventArgs e)
        {
            AjustaBotoes();
            if (bsProjeto.Count > 0)
                status.Navegando();
            else
                status.Inativa();
            AjustaBotoes();
        }

        private void lstEmpregado_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdicionarEmpregado();
            RemoverEmpregado();
        }
    }
}
