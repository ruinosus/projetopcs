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
    public partial class FrmCadDependente : Form
    {
        private Status status = new Status();
        private Controlador controlador = Controlador.GetInstancia();
        private Dependente dependenteAtual;

        private ArrayList dependentes;
        private ArrayList empregados;

        private bool pesquisando = false;

        private void AdicionarEmpregado()
        {
            btnAdicionarEmpregado.Enabled = cmbEmpregado.Items.Count > 0 && lstEmpregado.Items.Count < 1;
        }

        private void RemoverEmpregado()
        {
            btnRemoverEmpregado.Enabled = (lstEmpregado.Items.Count > 0);
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
                        break;
                    }
                case "Navegação":
                    {
                        btnAnterior.Enabled = bsDependente.Position > 0;
                        btnCancelar.Enabled = false;
                        btnGravar.Enabled = false;
                        btnNovo.Enabled = true;
                        btnPrimeiro.Enabled = bsDependente.Position > 0;
                        btnProximo.Enabled = bsDependente.Position + 1 < bsDependente.Count;
                        btnUltimo.Enabled = bsDependente.Position + 1 < bsDependente.Count;

                        btnRemover.Enabled = bsDependente.Count > 0;
                        btnAlterar.Enabled = bsDependente.Count > 0;

                        btnAdicionarEmpregado.Enabled = false;
                        btnRemoverEmpregado.Enabled = false;
                        break;
                    }
            }


        }

        private void AjustaEdits()
        {
            if (pesquisando == false)
            {
                dependentes = controlador.DependenteConsultarTodos();
            }
            else
            {
                dependentes = controlador.DependenteConsultarPorNome(txtLocalizar.Text);
            }
            bsDependente.DataSource = dependentes;

            empregados = controlador.EmpregadoConsultarTodos();
            if (empregados.Count > 0)
            {
                cmbEmpregado.DataSource = empregados;
                cmbEmpregado.DisplayMember = "Nome";
                cmbEmpregado.ValueMember = "Codigo";
                lstEmpregado.DisplayMember = "Nome";
                lstEmpregado.ValueMember = "Codigo";
            }            
            switch (status.StatusAtual())
            {
                case "Inativa":
                    {
                        txtNome.ReadOnly = true;
                        txtNome.Clear();

                        mskDataNascimento.ReadOnly = true;
                        mskDataNascimento.Clear();

                        cmbEmpregado.Enabled = false;
                        lstEmpregado.Enabled = false;

                        cmbGrauParentesco.Enabled = false;
                        break;
                    }

                case "Inclusão":
                    {
                        txtNome.ReadOnly = false;
                        txtNome.Clear();

                        mskDataNascimento.ReadOnly = false;
                        mskDataNascimento.Clear();

                        cmbEmpregado.Enabled = true;
                        lstEmpregado.Enabled = true;
                        lstEmpregado.Items.Clear();

                        cmbGrauParentesco.Enabled = true;
                        break;
                    }
                case "Alteração":
                    {
                        txtNome.ReadOnly = false;

                        mskDataNascimento.ReadOnly = false;

                        cmbEmpregado.Enabled = true;
                        lstEmpregado.Enabled = true;

                        cmbGrauParentesco.Enabled = true;
                        break;
                    }
                case "Navegação":
                    {
                        txtNome.ReadOnly = true;
                        txtNome.Clear();

                        mskDataNascimento.ReadOnly = true;
                        mskDataNascimento.Clear();

                        cmbEmpregado.Enabled = false;
                        lstEmpregado.Enabled = false;
                        lstEmpregado.Items.Clear();

                        cmbGrauParentesco.Enabled = false;

                        if (bsDependente.Count > 0)
                        {
                            dependenteAtual = (Dependente)dependentes[bsDependente.Position];

                            txtNome.Text = dependenteAtual.Nome;
                            if (dependenteAtual.DataNascimento != Convert.ToDateTime("01/01/0001"))
                            {
                                mskDataNascimento.Text = dependenteAtual.DataNascimento + "";
                            }

                            if (dependenteAtual.Empregado != null)
                            {
                                lstEmpregado.Items.Add(dependenteAtual.Empregado);
                            }

                            if (dependenteAtual.Sexo.Equals('M'))
                            {
                                rdSexoMasculino.Checked = true;
                            }
                            else
                            {
                                rdSexoFeminino.Checked = true;
                            }

                            cmbGrauParentesco.Text = dependenteAtual.GrauParentesco;                           

                        }
                        lbInformacao.Text = "Quantidades de Dependentes cadastrados: " + bsDependente.Count;
                        break;
                    }
            }
        }

        public FrmCadDependente()
        {
            InitializeComponent();
        }

        private void txtLocalizar_TextChanged(object sender, EventArgs e)
        {
            pesquisando = txtLocalizar.Text.Trim() != "" && txtLocalizar.Text.Trim() != " ";
            status.Navegando();
            AjustaBotoes();
        }

        private void btnAdicionarEmpregado_Click(object sender, EventArgs e)
        {
            lstEmpregado.Items.Add(cmbEmpregado.Items[cmbEmpregado.SelectedIndex]);
            AdicionarEmpregado();
            RemoverEmpregado();
        }

        private void btnRemoverEmpregado_Click(object sender, EventArgs e)
        {
            lstEmpregado.Items.Clear();
            AdicionarEmpregado();
            RemoverEmpregado();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            status.Incluindo();
            AjustaBotoes();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            bool validacao = true;

            if ((txtNome.Text.Trim() == "") && (validacao == true))
            {
                validacao = false;
                tlMensagem.ToolTipTitle = "Campo inválido";
                tlMensagem.Show("O nome não pode ser vazio", txtNome);
                txtNome.Focus();
                txtNome.SelectAll();
            }

            if ((!mskDataNascimento.MaskCompleted) && (validacao == true))
            {
                validacao = false;
                tlMensagem.ToolTipTitle = "Campo inválido";
                tlMensagem.Show("A data de Nascimento deve ser informada", mskDataNascimento);
                mskDataNascimento.Focus();
                mskDataNascimento.SelectAll();
            }

            if (!(lstEmpregado.Items.Count > 0) && (validacao == true))
            {
                validacao = false;
                tlMensagem.ToolTipTitle = "Campo inválido";
                tlMensagem.Show("Deve ser informado o empregado responsável", lstEmpregado);
                btnAdicionarEmpregado.Focus();
            }

            if (validacao)
            {
                switch (status.StatusAtual())
                {
                    case "Alteração":
                        {
                            dependenteAtual.Nome = txtNome.Text;
                            dependenteAtual.GrauParentesco = cmbGrauParentesco.Text;

                            if (rdSexoMasculino.Checked)
                            {
                                dependenteAtual.Sexo = 'M';
                            }
                            else
                            {
                                dependenteAtual.Sexo = 'F';
                            }

                            if (lstEmpregado.Items.Count > 0)
                            {
                                dependenteAtual.Empregado = (Empregado)lstEmpregado.Items[0];
                            }

                            if (mskDataNascimento.MaskCompleted)
                            {
                                dependenteAtual.DataNascimento = Convert.ToDateTime(mskDataNascimento.Text);
                            }
                            else
                            {
                                dependenteAtual.DataNascimento = Convert.ToDateTime("01/01/0001");
                            }
                            controlador.DependenteAlterarDependente(dependenteAtual);
                            break;
                        }

                    case "Inclusão":
                        {
                            Dependente dep = new Dependente();

                            dep.Nome = txtNome.Text;

                            if (rdSexoMasculino.Checked)
                            {
                                dep.Sexo = 'M';
                            }
                            else
                            {
                                dep.Sexo = 'F';
                            }

                            if (lstEmpregado.Items.Count > 0)
                            {
                                dep.Empregado = (Empregado)lstEmpregado.Items[0];
                            }


                            if (mskDataNascimento.MaskCompleted)
                            {
                                dep.DataNascimento = Convert.ToDateTime(mskDataNascimento.Text);
                            }
                            else
                            {
                                dep.DataNascimento = Convert.ToDateTime("01/01/0001");
                            }
                            controlador.DependenteInserirDependente(dep);
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
                controlador.DependenteRemoverDependente(dependenteAtual.Codigo);
                System.Windows.Forms.MessageBox.Show("Dependente Removido com sucesso.");
                status.Navegando();
                AjustaBotoes();
            }        
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsDependente.MoveFirst();
            AjustaBotoes();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsDependente.MovePrevious();
            AjustaBotoes();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsDependente.MoveNext();
            AjustaBotoes();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsDependente.MoveLast();
            AjustaBotoes();
        }

        private void FrmCadDependente_Load(object sender, EventArgs e)
        {
            AjustaBotoes();
            if (bsDependente.Count > 0)
                status.Navegando();
            else
                status.Inativa();
            AjustaBotoes();
        }

        private void txtLocalizar_Click(object sender, EventArgs e)
        {

        }
    }
}
