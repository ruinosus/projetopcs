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

                        cmbSupervisor.Enabled = false;
                        lstSupervisor.Enabled = false;
                        

                        break;
                    }

                case "Inclusão":
                    {
                        //txtNome.ReadOnly = false;
                        //txtNome.Clear();
                        //lstLocalidades.Enabled = true;
                        //cmbLocalidades.Enabled = true;
                        ////AjustaLista();
                        //localidadesDepartamento = new ArrayList();

                        //LimparLista();

                        break;
                    }
                case "Alteração":
                    {
                        //txtNome.ReadOnly = false;
                        //lstLocalidades.Enabled = true;
                        //cmbLocalidades.Enabled = true;
                        //if (localidadesDepartamento.Count > 0)
                        //{
                        //    LimparLista();
                        //    CarregarLista();
                        //}
                        break;
                    }
                case "Navegação":
                    {
                        txtNome.ReadOnly = true;
                        //lstLocalidades.Enabled = false;
                        //cmbLocalidades.Enabled = false;
                        if (bsEmpregado.Count > 0)
                        {
                            empregadoAtual = (Empregado)empregados[bsEmpregado.Position];
                            txtNome.Text = empregadoAtual.Nome;
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
            status.Incluindo();
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



    }
}
