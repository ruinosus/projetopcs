﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using Repositorio.implementacoes;
using ClassesBasicas;
using System.Collections;

namespace Negocios
{
    public class Controlador
    {
        private static Controlador controlador;

        private Controlador()
        {

        }

        public static Controlador GetInstancia()
        {
            if (controlador == null)
            {
                controlador = new Controlador();
            }
            return controlador;
        }

        private IRepositorioDepartamento repDepartamento = new RepositorioDepartamento();
        private IRepositorioDependente repDependente = new RepositorioDependente();
        private IRepositorioEmpregado repEmpregado = new RepositorioEmpregado();
        private IRepositorioEndereco repEndereco = new RepositorioEndereco();
        private IRepositorioLocalidade repLocalidade = new RepositorioLocalidade();
        private IRepositorioProjeto repProjeto = new RepositorioProjeto();

        #region IRepositorioDepartamento Tabela DEPARTAMENTO

        public void DepartamentoInserirDepartamento(Departamento departamento)
        {
            if ((departamento.Localidades.Count > 0) && (departamento.Localidades != null))
            {
                this.repDepartamento.InserirDepartamento(departamento);
                departamento.Codigo = this.repDepartamento.ObterMaximoCodigo();
                this.repDepartamento.InserirDepartamentoLocalidade(departamento);
            }
            else
            {
                this.repDepartamento.InserirDepartamento(departamento);
            }
        }

        public Departamento DepartamentoConsultarPorCodigo(int codDepartamento)
        {
            return this.repDepartamento.ConsultarPorCodigo(codDepartamento) ;
        }

        public ArrayList DepartamentoConsultarPorNome(String nomeDepartamento)
        {
            return this.repDepartamento.ConsultarPorNome(nomeDepartamento);
        }

        public void DepartamentoRemoverDepartamento(int codDepartamento)
        {
            this.repDepartamento.RemoverDepartamento(codDepartamento);
        }

        public ArrayList DepartamentoConsultarTodos()
        {
            return this.repDepartamento.ConsultarTodos();
        }

        #endregion

        #region IRepositorioDepartamento Tabela DEPARTAMENTO_LOCALIDADE

        public void DepartamentoLocalidadeRemoverDepartamentoLocalidade(int codDepartamento)
        {
            this.repDepartamento.RemoverDepartamentoLocalidade(codDepartamento);
        }

        #endregion

        #region IRepositorioDependente Tabela DEPENDENTE

        public void DependenteInserirDependente(int codEmpregado, Dependente dependente)
        {
            this.repDependente.InserirDependente(codEmpregado, dependente);
        }

        public Dependente DependenteConsultarPorCodigo(int codDependente)
        {
            return this.repDependente.ConsultarPorCodigo(codDependente);
        }

        public ArrayList DependenteConsultarPorEmpregado(int codEmpregado)
        {
            return this.repDependente.ConsultarPorEmpregado(codEmpregado);
        }

        public ArrayList DependenteConsultarPorNome(String nomeDependente)
        {
            return this.repDependente.ConsultarPorNome(nomeDependente);
        }

        public void DependenteRemoverDependente(int codDependente)
        {
            this.repDependente.RemoverDependente(codDependente);
        }

        public ArrayList DependenteConsultarTodos()
        {
            return this.repDependente.ConsultarTodos();
        }

        #endregion

        #region IRepositorioEmpregado Tabela EMPREGADO

        public void EmpregadoInserirEmpregado(Empregado empregado)
        {
            this.repEndereco.InserirEndereco(empregado.Endereco);
            this.repEmpregado.InserirEmpregado(empregado);
        }

        public Empregado EmpregadoConsultarPorCodigo(int codEmpregado)
        {
            return this.repEmpregado.ConsultarPorCodigo(codEmpregado);
        }

        public ArrayList EmpregadoConsultarPorNome(String nomeEmpregado)
        {
            return this.repEmpregado.ConsultarPorNome(nomeEmpregado);
        }

        public void EmpregadoRemoverEmpregado(int codEmpregado)
        {
            this.repEmpregado.RemoverEmpregado(codEmpregado);
        }

        public ArrayList EmpregadoConsultarTodos()
        {
            return this.repEmpregado.ConsultarTodos();
        }

        #endregion

        #region IRepositorioEmpregado Tabela CHEFIAR

        public void ChefiarInserirChefiar(Empregado empregado)
        {
            this.repEmpregado.InserirChefiar(empregado);
        }

        public Empregado ChefiarConsultarPorCodigoEmpregadoChefiar(Empregado empregado)
        {
            return this.repEmpregado.ConsultarPorCodigoEmpregadoChefiar(empregado);
        }

        public void ChefiarRemoverChefiar(int codEmpregado)
        {
            this.repEmpregado.RemoverChefiar(codEmpregado);
        }

        #endregion

        #region IRepositorioEmpregado Tabela ALOCAR

        public void AlocarInserirAlocar(Empregado empregado)
        {
            this.repEmpregado.InserirAlocar(empregado);
        }

        public Empregado AlocarConsultarPorCodigoEmpregadoAlocar(Empregado empregado)
        {
            return this.repEmpregado.ConsultarPorCodigoEmpregadoAlocar(empregado);
        }

        public void AlocarRemoverAlocar(int codEmpregado)
        {
            this.repEmpregado.RemoverAlocar(codEmpregado);
        }

        #endregion

        #region IRepositorioLocalidade Tabela LOCALIDADE

        public void LocalidadeInserirLocalidade(Localidade localidade)
        {
            this.repLocalidade.InserirLocalidade(localidade);
        }

        public Localidade LocalidadeConsultarPorCodigo(int codLocalidade)
        {
            return repLocalidade.ConsultarPorCodigo(codLocalidade);
        }

        public ArrayList LocalidadeConsultarPorNome(String nomeLocalidade)
        {
            return repLocalidade.ConsultarPorNome(nomeLocalidade);
        }

        public void LocalidadeRemoverLocalidade(int codLocalidade)
        {
            this.repLocalidade.RemoverLocalidade(codLocalidade);
        }

        public ArrayList LocalidadeConsultarTodos()
        {
            return this.repLocalidade.ConsultarTodos();
        }

        #endregion

        #region IRepositorioProjeto Tabela PROJETO

        public void ProjetoInserirProjeto(Projeto projeto)
        {
            this.repProjeto.InserirProjeto(projeto);
        }

        public Projeto ProjetoConsultarPorCodigo(int codProjeto)
        {
            return this.repProjeto.ConsultarPorCodigo(codProjeto);
        }

        public ArrayList ProjetoConsultarPorNome(String nomeProjeto)
        {
            return this.repProjeto.ConsultarPorNome(nomeProjeto);
        }

        public void ProjetoRemoverProjeto(int codProjeto)
        {
            this.repProjeto.RemoverProjeto(codProjeto);
        }

        public ArrayList ProjetoConsultarTodos()
        {
            return this.repProjeto.ConsultarTodos();
        }

        public int ProjetoObterMaximoCodigo()
        {
            return this.repProjeto.ObterMaximoCodigo();
        }

        #endregion

        #region IRepositorioProjeto Tabela EMPREGADO_PROJETO

        public void EmpregadoProjetoInserirEmpregadoProjeto(Projeto projeto)
        {
            this.repProjeto.InserirEmpregadoProjeto(projeto);
        }

        public ArrayList EmpregadoProjetoConsultarPorCodigoProjeto(Projeto projeto)
        {
            return this.repProjeto.ConsultarPorCodigoProjeto(projeto);
        }

        public void EmpregadoProjetoRemoverEmpregadoProjeto(int codProjeto, int codEmpregado)
        {
            this.repProjeto.RemoverEmpregadoProjeto(codProjeto, codEmpregado);
        }

        #endregion

    }
}
