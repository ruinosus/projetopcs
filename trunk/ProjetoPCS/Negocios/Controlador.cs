using System;
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

    }
}
