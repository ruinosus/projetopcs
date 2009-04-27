using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Negocios;
using ClassesBasicas;

namespace UI
{
    public partial class FrmCadEmpregado : Form
    {

        private Status status = new Status();
        private Controlador controlador = Controlador.GetInstancia();
        private Empregado empregadoAtual;

        private ArrayList empregados;
        private ArrayList supervisores;
        private ArrayList departamentosAlocados;
        private ArrayList departamentosChefiados;

        private bool pesquisando = false;

        private void AdicionarSupervisor()
        {
            btnAdicionarSupervisor.Enabled = cmbSupervisor.Items.Count > 0 && lstSupervisor.Items.Count < 1;

        }

        private void RemoverSupervisor()
        {
            btnRemoverSupervisor.Enabled = (lstSupervisor.Items.Count > 0);

        }

        private void AdicionarAlocar()
        {
            btnAdicionarAlocar.Enabled = cmbAlocar.Items.Count > 0 && lstAlocar.Items.Count < 1;
        }

        private void RemoverAlocar()
        {
            btnRemoverAlocar.Enabled = (lstAlocar.Items.Count > 0);
        }

        private void AdicionarChefiar()
        {
            btnAdicionarChefiar.Enabled = cmbChefiar.Items.Count > 0 && lstChefiar.Items.Count < 1;
        }

        private void RemoverChefiar()
        {
            btnRemoverChefiar.Enabled = (lstChefiar.Items.Count > 0);
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

                        btnAdicionarAlocar.Enabled = false;
                        btnRemoverAlocar.Enabled = false;

                        btnAdicionarChefiar.Enabled = false;
                        btnRemoverChefiar.Enabled = false;

                        btnAdicionarSupervisor.Enabled = false;
                        btnRemoverSupervisor.Enabled = false;
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

                        AdicionarSupervisor();
                        RemoverSupervisor();

                        AdicionarAlocar();
                        RemoverAlocar();

                        AdicionarChefiar();
                        RemoverChefiar();
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

                        AdicionarSupervisor();
                        RemoverSupervisor();

                        AdicionarAlocar();
                        RemoverAlocar();

                        AdicionarChefiar();
                        RemoverChefiar();
                        break;
                    }
                case "Navegação":
                    {
                        btnAnterior.Enabled = bsEmpregado.Position > 0;
                        btnCancelar.Enabled = false;
                        btnGravar.Enabled = false;
                        btnNovo.Enabled = true;
                        btnPrimeiro.Enabled = bsEmpregado.Position > 0;
                        btnProximo.Enabled = bsEmpregado.Position + 1 < bsEmpregado.Count;
                        btnUltimo.Enabled = bsEmpregado.Position + 1 < bsEmpregado.Count;

                        btnRemover.Enabled = bsEmpregado.Count > 0;
                        btnAlterar.Enabled = bsEmpregado.Count > 0;

                        btnAdicionarAlocar.Enabled = false;
                        btnRemoverAlocar.Enabled = false;

                        btnAdicionarChefiar.Enabled = false;
                        btnRemoverChefiar.Enabled = false;

                        btnAdicionarSupervisor.Enabled = false;
                        btnRemoverSupervisor.Enabled = false;
                        break;
                    }
            }


        }

        private void AjustaEdits()
        {
            if (pesquisando == false)
            {
                empregados = controlador.EmpregadoConsultarTodos();
            }
            else
            {
                empregados = controlador.EmpregadoConsultarPorNome(txtLocalizar.Text);
            }
            bsEmpregado.DataSource = empregados;

            supervisores = controlador.EmpregadoConsultarTodos();       
            cmbSupervisor.DataSource = supervisores;
            cmbSupervisor.DisplayMember = "Nome";
            cmbSupervisor.ValueMember = "Codigo";
            lstSupervisor.DisplayMember = "Nome";
            lstSupervisor.ValueMember = "Codigo";

            departamentosAlocados = controlador.DepartamentoConsultarTodos();
            cmbAlocar.DataSource = departamentosAlocados;
            cmbAlocar.DisplayMember = "Nome";
            cmbAlocar.ValueMember = "Codigo";
            lstAlocar.DisplayMember = "Nome";
            lstAlocar.ValueMember = "Codigo";

            departamentosChefiados = controlador.DepartamentoConsultarTodos();
            cmbChefiar.DataSource = departamentosChefiados;
            cmbChefiar.DisplayMember = "Nome";
            cmbChefiar.ValueMember = "Codigo";
            lstChefiar.DisplayMember = "Nome";
            lstChefiar.ValueMember = "Codigo";

            switch (status.StatusAtual())
            {
                case "Inativa":
                    {
                        txtNome.ReadOnly = true;
                        txtNome.Clear();

                        mskDataNascimento.ReadOnly = true;
                        mskDataNascimento.Clear();

                        mskRg.ReadOnly = true;
                        mskRg.Clear();

                        mskCpf.ReadOnly = true;
                        mskCpf.Clear();

                        mskTelefone.ReadOnly = true;
                        mskTelefone.Clear();

                        txtSalario.ReadOnly = true;
                        txtSalario.Text = "0";

                        cmbSupervisor.Enabled = false;
                        lstSupervisor.Enabled = false;

                        txtLogradouro.ReadOnly = true;
                        txtLogradouro.Clear();

                        txtNumero.ReadOnly = true;
                        txtNumero.Clear();

                        txtComplemento.ReadOnly = true;
                        txtComplemento.Clear();

                        txtBairro.ReadOnly = true;
                        txtBairro.Clear();

                        txtCidade.ReadOnly = true;
                        txtCidade.Clear();

                        cmbUf.Enabled = false;

                        txtPais.ReadOnly = true;
                        txtPais.Clear();

                        mskCep.ReadOnly = true;
                        mskCep.Clear();

                        cmbAlocar.Enabled = false;
                        lstAlocar.Enabled = false;

                        mskDataAlocacao.ReadOnly = true;
                        mskDataAlocacao.Clear();

                        cmbChefiar.Enabled = false;
                        lstChefiar.Enabled = false;

                        mskDataInicio.ReadOnly = true;
                        mskDataInicio.Clear();

                        mskDataFinal.ReadOnly = true;
                        mskDataFinal.Clear();                    
                        break;
                    }

                case "Inclusão":
                    {
                        txtNome.ReadOnly = false;
                        txtNome.Clear();

                        mskDataNascimento.ReadOnly = false;
                        mskDataNascimento.Clear();

                        mskRg.ReadOnly = false;
                        mskRg.Clear();

                        mskCpf.ReadOnly = false;
                        mskCpf.Clear();

                        mskTelefone.ReadOnly = false;
                        mskTelefone.Clear();

                        txtSalario.ReadOnly = false;
                        txtSalario.Text = "0";

                        cmbSupervisor.Enabled = true;
                        lstSupervisor.Enabled = true;
                        lstSupervisor.Items.Clear();

                        txtLogradouro.ReadOnly = false;
                        txtLogradouro.Clear();

                        txtNumero.ReadOnly = false;
                        txtNumero.Clear();

                        txtComplemento.ReadOnly = false;
                        txtComplemento.Clear();

                        txtBairro.ReadOnly = false;
                        txtBairro.Clear();

                        txtCidade.ReadOnly = false;
                        txtCidade.Clear();

                        cmbUf.Enabled = true;

                        txtPais.ReadOnly = false;
                        txtPais.Clear();

                        mskCep.ReadOnly = false;
                        mskCep.Clear();

                        cmbAlocar.Enabled = true;
                        lstAlocar.Enabled = true;
                        lstAlocar.Items.Clear();

                        mskDataAlocacao.ReadOnly = false;
                        mskDataAlocacao.Clear();

                        cmbChefiar.Enabled = true;
                        lstChefiar.Enabled = true;
                        lstChefiar.Items.Clear();

                        mskDataInicio.ReadOnly = false;
                        mskDataInicio.Clear();

                        mskDataFinal.ReadOnly = false;
                        mskDataFinal.Clear();  

                        break;
                    }
                case "Alteração":
                    {
                        txtNome.ReadOnly = false;

                        mskDataNascimento.ReadOnly = false;

                        mskRg.ReadOnly = false;

                        mskCpf.ReadOnly = false;

                        mskTelefone.ReadOnly = false;

                        txtSalario.ReadOnly = false;

                        cmbSupervisor.Enabled = true;
                        lstSupervisor.Enabled = true;

                        txtLogradouro.ReadOnly = false;

                        txtNumero.ReadOnly = false;

                        txtComplemento.ReadOnly = false;

                        txtBairro.ReadOnly = false;

                        txtCidade.ReadOnly = false;

                        cmbUf.Enabled = true;

                        txtPais.ReadOnly = false;

                        mskCep.ReadOnly = false;

                        cmbAlocar.Enabled = true;
                        lstAlocar.Enabled = true;

                        mskDataAlocacao.ReadOnly = false;

                        cmbChefiar.Enabled = true;
                        lstChefiar.Enabled = true;

                        mskDataInicio.ReadOnly = false;

                        mskDataFinal.ReadOnly = false;

                        break;
                    }
                case "Navegação":
                    {
                        txtNome.ReadOnly = true;
                        txtNome.Clear();

                        mskDataNascimento.ReadOnly = true;
                        mskDataNascimento.Clear();

                        mskRg.ReadOnly = true;
                        mskRg.Clear();

                        mskCpf.ReadOnly = true;
                        mskCpf.Clear();

                        mskTelefone.ReadOnly = true;
                        mskTelefone.Clear();

                        txtSalario.ReadOnly = true;
                        txtSalario.Text = "0";

                        cmbSupervisor.Enabled = false;
                        lstSupervisor.Enabled = false;
                        lstSupervisor.Items.Clear();

                        txtLogradouro.ReadOnly = true;
                        txtLogradouro.Clear();

                        txtNumero.ReadOnly = true;
                        txtNumero.Clear();

                        txtComplemento.ReadOnly = true;
                        txtComplemento.Clear();

                        txtBairro.ReadOnly = true;
                        txtBairro.Clear();

                        txtCidade.ReadOnly = true;
                        txtCidade.Clear();

                        cmbUf.Enabled = false;

                        txtPais.ReadOnly = true;
                        txtPais.Clear();

                        mskCep.ReadOnly = true;
                        mskCep.Clear();

                        cmbAlocar.Enabled = false;
                        lstAlocar.Enabled = false;
                        lstAlocar.Items.Clear();

                        mskDataAlocacao.ReadOnly = true;
                        mskDataAlocacao.Clear();

                        cmbChefiar.Enabled = false;
                        lstChefiar.Enabled = false;
                        lstChefiar.Items.Clear();

                        mskDataInicio.ReadOnly = true;
                        mskDataInicio.Clear();

                        mskDataFinal.ReadOnly = true;
                        mskDataFinal.Clear(); 

                        if (bsEmpregado.Count > 0)
                        {
                            empregadoAtual = (Empregado)empregados[bsEmpregado.Position];

                            txtNome.Text = empregadoAtual.Nome;
                            mskDataNascimento.Text = empregadoAtual.DataNascimento+"" ;
                            mskRg.Text = empregadoAtual.Rg;
                            mskCpf.Text = empregadoAtual.Cpf;
                            mskTelefone.Text = empregadoAtual.Telefone;
                            txtSalario.Text = empregadoAtual.Salario+"";

                            if (empregadoAtual.Supervisor != null)
                            {
                                lstSupervisor.Items.Add(empregadoAtual.Supervisor); 
                            }

                            if (empregadoAtual.Sexo.Equals('M'))
                            {
                                rdSexoMasculino.Checked = true;
                            }
                            else
                            {
                                rdSexoFeminino.Checked = true;
                            }

                            txtLogradouro.Text = empregadoAtual.Endereco.Logradouro;
                            txtNumero.Text = empregadoAtual.Endereco.Numero;
                            txtComplemento.Text = empregadoAtual.Endereco.Complemento;
                            txtBairro.Text = empregadoAtual.Endereco.Bairro;
                            txtCidade.Text = empregadoAtual.Endereco.Cidade;
                            cmbUf.Text = empregadoAtual.Endereco.Uf;
                            txtPais.Text = empregadoAtual.Endereco.Pais;
                            mskCep.Text = empregadoAtual.Endereco.Cep+"";

                            if (empregadoAtual.DepartamentoAlocado != null)
	                        {
                                lstAlocar.Items.Add(empregadoAtual.DepartamentoAlocado);
                                mskDataAlocacao.Text = empregadoAtual.DataAlocação+""; 
	                        }

                            if (empregadoAtual.DepartamentoChefiado != null)
                            {
                                lstChefiar.Items.Add( empregadoAtual.DepartamentoChefiado);
                                mskDataInicio.Text = empregadoAtual.DataInicio+"";
                                mskDataFinal.Text = empregadoAtual.DataFinal + ""; 
                            }


                            //if (departamentoAtual.Localidades.Count > 0)
                            //{
                            //    localidadesDepartamento = departamentoAtual.Localidades;
                            //    LimparLista();
                            //    CarregarLista();
                            //}
                            //else
                            //{
                            //    localidadesDepartamento = new ArrayList();
                            //    LimparLista();
                            //    //CarregarLista();
                            //}
                        }
                        lbInformacao.Text = "Quantidades de Empregados cadastrados: " + bsEmpregado.Count;
                        break;
                    }
            }
        }

        public FrmCadEmpregado()
        {
            InitializeComponent();
        }

        private void FrmCadEmpregado_Load(object sender, EventArgs e)
        {
            status.Navegando();
            AjustaBotoes();
        }

        private void btnAdicionarSupervisor_Click(object sender, EventArgs e)
        {
            lstSupervisor.Items.Add(cmbSupervisor.Items[cmbSupervisor.SelectedIndex]);
            AdicionarSupervisor();
            RemoverSupervisor();
        }

        private void btnRemoverSupervisor_Click(object sender, EventArgs e)
        {
            lstSupervisor.Items.Clear();
            AdicionarSupervisor();
            RemoverSupervisor();
        }

        private void txtLocalizar_TextChanged(object sender, EventArgs e)
        {
            pesquisando = txtLocalizar.Text.Trim() != "" && txtLocalizar.Text.Trim() != " ";
            status.Navegando();
            AjustaBotoes();
        }

        private void btnAdicionarAlocar_Click(object sender, EventArgs e)
        {
            lstAlocar.Items.Add(cmbAlocar.Items[cmbAlocar.SelectedIndex]);
            AdicionarAlocar();
            RemoverAlocar();
        }

        private void btnRemoverAlocar_Click(object sender, EventArgs e)
        {
            lstAlocar.Items.Clear();
            AdicionarAlocar();
            RemoverAlocar();
        }

        private void btnAdicionarChefiar_Click(object sender, EventArgs e)
        {
            lstChefiar.Items.Add(cmbChefiar.Items[cmbChefiar.SelectedIndex]);
            AdicionarChefiar();
            RemoverChefiar();
        }

        private void btnRemoverChefiar_Click(object sender, EventArgs e)
        {
            lstChefiar.Items.Clear();
            AdicionarChefiar();
            RemoverChefiar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            status.Incluindo();
            AjustaBotoes();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            switch (status.StatusAtual())
            {
                case "Alteração":
                    {
                        empregadoAtual.Nome = txtNome.Text;
                        //colocar o resto do código aki
                        controlador.EmpregadoAlterarEmpregado(empregadoAtual);
                        break;
                    }

                case "Inclusão":
                    {
                        Empregado emp = new Empregado();
                        //colocar o resto do código aki
                        controlador.EmpregadoInserirEmpregado(emp);
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

            if (d.ToString()=="Yes")
            {
                controlador.EmpregadoRemoverEmpregado(empregadoAtual.Codigo);
                System.Windows.Forms.MessageBox.Show("Empregado Removido com sucesso.");
                status.Navegando();
                AjustaBotoes();
            }          

            
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsEmpregado.MoveFirst();
            AjustaBotoes();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsEmpregado.MovePrevious();
            AjustaBotoes();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsEmpregado.MoveNext();
            AjustaBotoes();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            status.Navegando();
            bsEmpregado.MoveLast();
            AjustaBotoes();
        }



    }
}
