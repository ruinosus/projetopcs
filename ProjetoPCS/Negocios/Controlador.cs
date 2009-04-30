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
            if ((departamento.Localidades != null) && (departamento.Localidades.Count > 0))
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

        public void DepartamentoAlterarDepartamento(Departamento departamento)
        {
            if ((departamento.Localidades != null)&&(departamento.Localidades.Count > 0))
            {
                this.repDepartamento.AlterarDepartamento(departamento);
                this.repDepartamento.RemoverDepartamentoLocalidade(departamento.Codigo);
                this.repDepartamento.InserirDepartamentoLocalidade(departamento);
            }
            else
            {
                this.repDepartamento.RemoverDepartamentoLocalidade(departamento.Codigo);
                this.repDepartamento.AlterarDepartamento(departamento);
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

        public void DepartamentoLocalidadeRemoverDepartamentoLocalidade(int codDepartamento, int codLocalidade)
        {
            this.repDepartamento.RemoverDepartamentoLocalidade(codDepartamento, codLocalidade);
        }

        #endregion

        #region IRepositorioDependente Tabela DEPENDENTE

        public void DependenteInserirDependente(Dependente dependente)
        {
            this.repDependente.InserirDependente(dependente);
        }

        public void DependenteAlterarDependente(Dependente dependente)
        {
            this.repDependente.AlterarDependente(dependente);
        }

        public Dependente DependenteConsultarPorCodigo(int codDependente)
        {
            return this.repDependente.ConsultarPorCodigo(codDependente);
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
            empregado.Endereco.Codigo = this.repEndereco.ObterMaximoCodigo();
            this.repEmpregado.InserirEmpregado(empregado);
            empregado.Codigo = this.repEmpregado.ObterMaximoCodigo();

            if (empregado.DepartamentoAlocado != null)
            {
                this.repEmpregado.InserirAlocar(empregado);
            }            

            if (empregado.DepartamentoChefiado != null)
            {
                this.repEmpregado.InserirChefiar(empregado);
            }
            
        }

        public void EmpregadoAlterarEmpregado(Empregado empregado)
        {
            this.repEndereco.AlterarEndereco(empregado.Endereco);
            this.repEmpregado.AlterarEmpregado(empregado);

            if (empregado.DepartamentoAlocado != null)
            {
                this.repEmpregado.RemoverAlocar(empregado.Codigo);
                this.repEmpregado.InserirAlocar(empregado);
            }
            else
            {
                this.repEmpregado.RemoverAlocar(empregado.Codigo);
            }

            if (empregado.DepartamentoChefiado != null)
            {
                this.repEmpregado.RemoverChefiar(empregado.Codigo);
                this.repEmpregado.InserirChefiar(empregado);
            }
            else
            {
                this.repEmpregado.RemoverChefiar(empregado.Codigo);
            }
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

        //public void ChefiarInserirChefiar(Empregado empregado)
        //{
        //    this.repEmpregado.InserirChefiar(empregado);
        //}

        public Empregado ChefiarConsultarPorCodigoEmpregadoChefiar(Empregado empregado)
        {
            return this.repEmpregado.ConsultarPorCodigoEmpregadoChefiar(empregado);
        }

        //public void ChefiarRemoverChefiar(int codEmpregado)
        //{
        //    this.repEmpregado.RemoverChefiar(codEmpregado);
        //}

        #endregion

        #region IRepositorioEmpregado Tabela ALOCAR

        //public void AlocarInserirAlocar(Empregado empregado)
        //{
        //    this.repEmpregado.InserirAlocar(empregado);
        //}

        public Empregado AlocarConsultarPorCodigoEmpregadoAlocar(Empregado empregado)
        {
            return this.repEmpregado.ConsultarPorCodigoEmpregadoAlocar(empregado);
        }

        //public void AlocarRemoverAlocar(int codEmpregado)
        //{
        //    this.repEmpregado.RemoverAlocar(codEmpregado);
        //}

        #endregion

        #region IRepositorioLocalidade Tabela LOCALIDADE

        public void LocalidadeInserirLocalidade(Localidade localidade)
        {
            this.repLocalidade.InserirLocalidade(localidade);
        }

        public void LocalidadeAlterarLocalidade(Localidade localidade)
        {
            this.repLocalidade.AlterarLocalidade(localidade);
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
            if ((projeto.Empregados != null) && (projeto.Empregados.Count > 0))
            {
                this.repProjeto.InserirProjeto(projeto);
                projeto.Codigo = this.repProjeto.ObterMaximoCodigo();
                this.repProjeto.InserirEmpregadoProjeto(projeto);
            }
            else
            {
                this.repProjeto.InserirProjeto(projeto);
            }
        }

        public void ProjetoAlterarProjeto(Projeto projeto)
        {
            if ((projeto.Empregados != null) && (projeto.Empregados.Count > 0))
            {
                this.repProjeto.AlterarProjeto(projeto);
                this.repProjeto.RemoverEmpregadoProjeto(projeto.Codigo);
                this.repProjeto.InserirEmpregadoProjeto(projeto);
            }
            else
            {
                this.repProjeto.AlterarProjeto(projeto);
                this.repProjeto.RemoverEmpregadoProjeto(projeto.Codigo);
            }

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
