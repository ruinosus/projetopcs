﻿using System;
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
        private Localidade localidade;
        private ArrayList localidades;

        private void AjustaBotoes()
        {

            localidades = controlador.LocalidadeConsultarTodos();

            bsLocalidade.DataSource = localidades;
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

            AjustaEdits();
        }

        private void AjustaEdits()
        {
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
                            localidade = (Localidade)localidades[bsLocalidade.Position] ;
                            txtNome.Text = localidade.Nome;
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
            //localidades.Add(new Localidade(1, "Goiana"));
            //localidades.Add(new Localidade(2, "tambau"));
            //localidades.Add(new Localidade(3, "bla bla bla"));

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
                        controlador.LocalidadeAlterarLocalidade(localidade);
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
            controlador.LocalidadeRemoverLocalidade(localidade.Codigo);
            System.Windows.Forms.MessageBox.Show("Localidade Removida com sucesso.");
            status.Navegando();
            AjustaBotoes();

        }


    }
}