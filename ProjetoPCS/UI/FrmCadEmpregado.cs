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

        /*private bool VerificarSupervisor(params Empregado[] emp)
        {
            bool verificar = false;

            if (empregadoSupervisor.Supervisor != null)
            {
                if ((empregadoAtual.Codigo == empregadoSupervisor.Supervisor.Codigo) || empregadoAtual.Codigo == empregadoSupervisor.Codigo)
                {

                    return true;
                }

                if (empregadoSupervisor.Supervisor.Supervisor != null)
                {
                   // return this.VerificarSupervisor(empregadoSupervisor.Supervisor, empregadoSupervisor.Supervisor.Supervisor);
                }
                //else
                //{
                //    verificar = true;
                //}
            }
            else
            {
                if (empregadoAtual.Codigo == empregadoSupervisor.Codigo)
                {
                    return true;
                }
            }

            return verificar;
        }*/

        private bool VerificarSupervisor(Empregado empregadoAtual, Empregado empregadoSupervisor)
        {
            bool verificar = false;
            if (empregadoSupervisor.Supervisor != null)
            {
                if ((empregadoAtual.Codigo == empregadoSupervisor.Supervisor.Codigo) || empregadoAtual.Codigo == empregadoSupervisor.Codigo)
                {

                    return true;
                }

                if (empregadoSupervisor.Supervisor.Supervisor != null)
                {
                    return this.VerificarSupervisor(empregadoAtual, empregadoSupervisor.Supervisor.Supervisor);
                }

            }
            else
            {
                if (empregadoAtual.Codigo == empregadoSupervisor.Codigo)
                {
                    return true;
                }
            }

            return verificar;

        }
       
        //private void AjustarSupervisor()
        //{
        //    for (int i = 0; i < supervisores.Count; i++ )
        //    {
        //       if (((Empregado)supervisores[i]).Codigo == empregadoAtual.Codigo)
        //        {
        //            MessageBox.Show(((Empregado)supervisores[i]).Codigo + "  " + empregadoAtual.Codigo);
        //            supervisores.RemoveAt(i);
        //            MessageBox.Show(supervisores.Count + "  ");
        //            cmbSupervisor.DataSource = null;
        //            cmbSupervisor.DataSource = supervisores;  
        //        }
        //    }
        //}

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
            if (supervisores.Count > 0)
            {
                cmbSupervisor.DataSource = supervisores;
                cmbSupervisor.DisplayMember = "Nome";
                cmbSupervisor.ValueMember = "Codigo";
                lstSupervisor.DisplayMember = "Nome";
                lstSupervisor.ValueMember = "Codigo"; 
            }

            departamentosAlocados = controlador.DepartamentoConsultarTodos();
            if (departamentosAlocados.Count > 0)
            {
                cmbAlocar.DataSource = departamentosAlocados;
                cmbAlocar.DisplayMember = "Nome";
                cmbAlocar.ValueMember = "Codigo";
                lstAlocar.DisplayMember = "Nome";
                lstAlocar.ValueMember = "Codigo";
            }

            departamentosChefiados = controlador.DepartamentoConsultarTodos();
            if (departamentosChefiados.Count > 0)
            {
                cmbChefiar.DataSource = departamentosChefiados;
                cmbChefiar.DisplayMember = "Nome";
                cmbChefiar.ValueMember = "Codigo";
                lstChefiar.DisplayMember = "Nome";
                lstChefiar.ValueMember = "Codigo";
            }

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
                            if (empregadoAtual.DataNascimento != Convert.ToDateTime("01/01/0001") )
                            {
                                mskDataNascimento.Text = empregadoAtual.DataNascimento + "";
                            }
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
                                if (empregadoAtual.DataAlocação != Convert.ToDateTime("01/01/0001"))
                                {
                                    mskDataAlocacao.Text = empregadoAtual.DataAlocação + "";  
                                }
	                        }

                            if (empregadoAtual.DepartamentoChefiado != null)
                            {
                                lstChefiar.Items.Add( empregadoAtual.DepartamentoChefiado);
                                if (empregadoAtual.DataInicio != Convert.ToDateTime("01/01/0001"))
                                {
                                    mskDataInicio.Text = empregadoAtual.DataInicio + "";
                                }
                                if (empregadoAtual.DataFinal != Convert.ToDateTime("01/01/0001"))
                                {
                                    mskDataFinal.Text = empregadoAtual.DataFinal + "";
                                }
                            }
                            //AjustarSupervisor();
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
            AjustaBotoes();
            if(bsEmpregado.Count > 0)
            status.Navegando();
            else
            status.Inativa();
            AjustaBotoes();

        }

        private void btnAdicionarSupervisor_Click(object sender, EventArgs e)
        {
            bool achou = false;

            if (status.StatusAtual().Equals("Alteração")/* || status.StatusAtual().Equals("Inclusão")*/)
            {
                //if (cmbSupervisor.Items.Count > 0 )
                //{
                    Empregado sup = ((Empregado)cmbSupervisor.Items[cmbSupervisor.SelectedIndex]);
                       
                    achou = this.VerificarSupervisor(empregadoAtual,sup);
                //}
            }

            if (achou == false)
            {
                lstSupervisor.Items.Add(cmbSupervisor.Items[cmbSupervisor.SelectedIndex]);
                AdicionarSupervisor();
                RemoverSupervisor();
            }
            else
            {
                tlMensagem.ToolTipTitle = "Valor Inválido";
                tlMensagem.Show("Supervisor Inválido", lstSupervisor);
            }
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

            if ((!mskRg.MaskCompleted) && (validacao == true))
            {
                validacao = false;
                tlMensagem.ToolTipTitle = "Campo inválido";
                tlMensagem.Show("O Rg deve ser informado", mskRg);
                mskRg.Focus();
                mskRg.SelectAll();
            }

            if ((!mskCpf.MaskCompleted) && (validacao == true))
            {
                validacao = false;
                tlMensagem.ToolTipTitle = "Campo inválido";
                tlMensagem.Show("O Cpf deve ser informado", mskCpf);
                mskCpf.Focus();
                mskCpf.SelectAll();
            }

            if ((Convert.ToDouble(txtSalario.Text) <= 0) && (validacao == true))
            {
                validacao = false;
                tlMensagem.ToolTipTitle = "Campo inválido";
                tlMensagem.Show("O salário deve ser informado com um valor maior que zero", txtSalario);
                txtSalario.Focus();
                txtSalario.SelectAll();
            }

            if ((!mskCep.MaskCompleted) && (validacao == true))
            {
                validacao = false;
                tlMensagem.ToolTipTitle = "Campo inválido";
                tlMensagem.Show("O Cep deve ser informado", mskCep);
                mskCep.Focus();
                mskCep.SelectAll();
            }           

           

            if (validacao)
            {
                switch (status.StatusAtual())
                {
                    case "Alteração":
                        {
                            empregadoAtual.Endereco.Bairro = txtBairro.Text;
                            empregadoAtual.Endereco.Cep = Convert.ToInt32(mskCep.Text);
                            empregadoAtual.Endereco.Cidade = txtCidade.Text;
                            empregadoAtual.Endereco.Complemento = txtComplemento.Text;
                            empregadoAtual.Endereco.Logradouro = txtLogradouro.Text;
                            empregadoAtual.Endereco.Numero = txtNumero.Text;
                            empregadoAtual.Endereco.Pais = txtPais.Text;
                            empregadoAtual.Endereco.Uf = (cmbUf.Text);

                            empregadoAtual.Nome = txtNome.Text;
                            empregadoAtual.Nome = txtNome.Text;
                            empregadoAtual.Rg = mskRg.Text;
                            empregadoAtual.Salario = Convert.ToDouble(txtSalario.Text);

                            empregadoAtual.Supervisor = null;
                            empregadoAtual.DepartamentoAlocado = null;
                            empregadoAtual.DepartamentoChefiado = null;

                            if (rdSexoMasculino.Checked)
                            {
                                empregadoAtual.Sexo = 'M';
                            }
                            else
                            {
                                empregadoAtual.Sexo = 'F';
                            }

                            if (lstSupervisor.Items.Count > 0)
                            {
                                empregadoAtual.Supervisor = (Empregado)lstSupervisor.Items[0];
                            }   

                            empregadoAtual.Telefone = mskTelefone.Text;
                            empregadoAtual.Cpf = mskCpf.Text;

                            if (mskDataNascimento.MaskCompleted)
                            {
                                empregadoAtual.DataNascimento = Convert.ToDateTime(mskDataNascimento.Text);
                            }
                            else
                            {
                                empregadoAtual.DataNascimento = Convert.ToDateTime("01/01/0001");
                            }

                            if (lstAlocar.Items.Count > 0)
                            {
                                empregadoAtual.DepartamentoAlocado = (Departamento)lstAlocar.Items[0];

                                if (mskDataAlocacao.MaskCompleted)
                                {
                                    empregadoAtual.DataAlocação = Convert.ToDateTime(mskDataAlocacao.Text);
                                }
                                else
                                {
                                    empregadoAtual.DataAlocação = Convert.ToDateTime("01/01/0001");
                                }
                            }

                            if (lstChefiar.Items.Count > 0)
                            {
                                empregadoAtual.DepartamentoChefiado = (Departamento)lstChefiar.Items[0];

                                if (mskDataInicio.MaskCompleted)
                                {
                                    empregadoAtual.DataInicio = Convert.ToDateTime(mskDataInicio.Text);
                                }
                                else
                                {
                                    empregadoAtual.DataInicio = Convert.ToDateTime("01/01/0001");
                                }

                                if (mskDataFinal.MaskCompleted)
                                {
                                    empregadoAtual.DataFinal = Convert.ToDateTime(mskDataFinal.Text);
                                }
                                else
                                {
                                    empregadoAtual.DataFinal = Convert.ToDateTime("01/01/0001");
                                }
                            }
                            controlador.EmpregadoAlterarEmpregado(empregadoAtual);
                            break;
                        }

                    case "Inclusão":
                        {
                            Empregado emp = new Empregado();
                            Endereco endereco = new Endereco();

                            endereco.Bairro = txtBairro.Text;
                            endereco.Cep = Convert.ToInt32(mskCep.Text);
                            endereco.Cidade = txtCidade.Text;
                            endereco.Complemento = txtComplemento.Text;
                            endereco.Logradouro = txtLogradouro.Text;
                            endereco.Numero = txtNumero.Text;
                            endereco.Pais = txtPais.Text;
                            endereco.Uf = (cmbSupervisor.Text);

                            emp.Endereco = endereco;
                            emp.Nome = txtNome.Text;
                            emp.Rg = mskRg.Text;
                            emp.Salario = Convert.ToDouble(txtSalario.Text);

                            emp.Supervisor = null;
                            emp.DepartamentoAlocado = null;
                            emp.DepartamentoChefiado = null;

                            if (rdSexoMasculino.Checked)
                            {
                                emp.Sexo = 'M';
                            }
                            else
                            {
                                emp.Sexo = 'F';
                            }

                            if (lstSupervisor.Items.Count > 0)
                            {
                                emp.Supervisor = (Empregado)lstSupervisor.Items[0];
                            }

                            emp.Telefone = mskTelefone.Text;
                            emp.Cpf = mskCpf.Text;

                            if (mskDataNascimento.MaskCompleted)
                            {
                                emp.DataNascimento = Convert.ToDateTime(mskDataNascimento.Text);
                            }
                            else
                            {
                                emp.DataNascimento = Convert.ToDateTime("01/01/0001");
                            }

                            if (lstAlocar.Items.Count > 0)
                            {
                                emp.DepartamentoAlocado = (Departamento)lstAlocar.Items[0];

                                if (mskDataAlocacao.MaskCompleted)
                                {
                                    emp.DataAlocação = Convert.ToDateTime(mskDataAlocacao.Text);
                                }
                                else
                                {
                                    emp.DataAlocação = Convert.ToDateTime("01/01/0001");
                                }
                            }

                            if (lstChefiar.Items.Count > 0)
                            {
                                emp.DepartamentoChefiado = (Departamento)lstChefiar.Items[0];

                                if (mskDataInicio.MaskCompleted)
                                {
                                    emp.DataInicio = Convert.ToDateTime(mskDataInicio.Text);
                                }
                                else
                                {
                                    emp.DataInicio = Convert.ToDateTime("01/01/0001");
                                }

                                if (mskDataFinal.MaskCompleted)
                                {
                                    emp.DataFinal = Convert.ToDateTime(mskDataFinal.Text);
                                }
                                else
                                {
                                    emp.DataFinal = Convert.ToDateTime("01/01/0001");
                                }
                            }
                            controlador.EmpregadoInserirEmpregado(emp);
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

        private void mskDataNascimento_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!status.StatusAtual().Equals("Navegação") && !status.StatusAtual().Equals("Inativa"))
                {
                   Convert.ToDateTime(mskDataNascimento.Text);
                }
            }
            catch (Exception)
            {               
                tlMensagem.ToolTipTitle = "Data Inválida";
                tlMensagem.Show("O campo deve conter uma data válida", mskDataNascimento);
                mskDataNascimento.Clear();
            }

               
        }

        private void mskDataNascimento_Enter(object sender, EventArgs e)
        {
            this.mskDataNascimento.Focus();
            this.mskDataNascimento.SelectAll();
        }

        private void mskDataNascimento_MouseClick(object sender, MouseEventArgs e)
        {
            this.mskDataNascimento.Focus();
            this.mskDataNascimento.SelectAll();
        }

        private void mskDataAlocacao_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!status.StatusAtual().Equals("Navegação") && !status.StatusAtual().Equals("Inativa"))
                {
                   Convert.ToDateTime(mskDataAlocacao.Text);                  
                }
            }
            catch (Exception)
            {
                tlMensagem.ToolTipTitle = "Data Inválida";
                tlMensagem.Show("O campo deve conter uma data válida", mskDataAlocacao);
                mskDataAlocacao.Clear();
            }
        }

        private void mskDataAlocacao_Enter(object sender, EventArgs e)
        {
            this.mskDataAlocacao.Focus();
            this.mskDataAlocacao.SelectAll();
        }

        private void mskDataAlocacao_Click(object sender, EventArgs e)
        {
            this.mskDataAlocacao.Focus();
            this.mskDataAlocacao.SelectAll();
        }

        private void mskDataInicio_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!status.StatusAtual().Equals("Navegação") && !status.StatusAtual().Equals("Inativa"))
                {
                    Convert.ToDateTime(mskDataInicio.Text);
                }
            }
            catch (Exception)
            {
                tlMensagem.ToolTipTitle = "Data Inválida";
                tlMensagem.Show("O campo deve conter uma data válida", mskDataInicio);
                mskDataInicio.Clear();
            }
        }

        private void mskDataInicio_Enter(object sender, EventArgs e)
        {
            this.mskDataInicio.Focus();
            this.mskDataInicio.SelectAll();
        }

        private void mskDataInicio_Click(object sender, EventArgs e)
        {
            this.mskDataInicio.Focus();
            this.mskDataInicio.SelectAll();
        }

        private void mskDataFinal_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!status.StatusAtual().Equals("Navegação") && !status.StatusAtual().Equals("Inativa"))
                {
                    Convert.ToDateTime(mskDataFinal.Text);
                }
            }
            catch (Exception)
            {
                tlMensagem.ToolTipTitle = "Data Inválida";
                tlMensagem.Show("O campo deve conter uma data válida", mskDataFinal);
                mskDataFinal.Clear();
            }
        }

        private void mskDataFinal_Enter(object sender, EventArgs e)
        {
            this.mskDataFinal.Focus();
            this.mskDataFinal.SelectAll();
        }

        private void mskDataFinal_Click(object sender, EventArgs e)
        {
            this.mskDataFinal.Focus();
            this.mskDataFinal.SelectAll();
        }

        private void txtSalario_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!status.StatusAtual().Equals("Navegação") && !status.StatusAtual().Equals("Inativa"))
                {
                    if (Convert.ToDouble(txtSalario.Text) < 0)
                    {
                       throw new Exception();
                    }
                }
            }
            catch (Exception)
            {                
                tlMensagem.ToolTipTitle = "Campo inválido";
                tlMensagem.Show("O campo deve conter um valor númerico maior que zero", txtSalario);
                txtSalario.Text = "0";
            }
        }

        
    }
    
}

