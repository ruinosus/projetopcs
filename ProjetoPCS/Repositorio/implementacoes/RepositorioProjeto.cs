using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using System.Collections;

namespace Repositorio.implementacoes
{
    public class RepositorioProjeto : IRepositorioProjeto
    {
        private IRepositorioEmpregado repEmpregado = new RepositorioEmpregado();
        private IRepositorioDepartamento repDepartamento = new RepositorioDepartamento();

        #region Sql da tabela PROJETO

        private static String QUERY_INSERT = "INSERT INTO PROJETO(COD_DEPARTAMENTO,COD_LOCALIDADE,NOME_PROJETO) VALUES(?codDepartamento,?codLocalidade,?nomeProjeto)";       
        private static String QUERY_SELECT_ALL = "";
        private static String QUERY_SELECT_CODIGO = "";
        private static String QUERY_SELECT_NOME = "";
        private static String QUERY_DELETE = "DELETE FROM PROJETO WHERE COD_PROJETO = ?codProjeto";

        #endregion

        #region Sql da tabela EMPREGADO_PROJETO

        private static String QUERY_INSERT_EMPREGADO_PROJETO = "INSERT INTO EMPREGADO_PROJETO (COD_PROJETO,COD_EMPREGADO) VALUES (?codProjeto,?codEmpregado)";
        private static String QUERY_SELECT_CODIGO_EMPREGADO = "SELECT * FROM EMPREGADO_PROJETO WHERE COD_EMPREGADO = ?codEmpregado";
        private static String QUERY_SELECT_CODIGO_PROJETO = "SELECT * FROM EMPREGADO_PROJETO WHERE COD_PROJETO = ?codProjeto";
        private static String QUERY_DELETE_CHEFIAR = "DELETE FROM EMPREGADO_PROJETO WHERE COD_PROJETO = ?codProjeto AND COD_EMPREGADO = ?codEmpregado";

        #endregion

        #region IRepositorioProjeto - Tabela PROJETO

        public void InserirProjeto(ClassesBasicas.Projeto projeto)
        {
            throw new NotImplementedException();
        }

        public ClassesBasicas.Empregado ConsultarPorCodigo(int codProjeto)
        {
            throw new NotImplementedException();
        }

        public ArrayList ConsultarPorNome(string nomeProjeto)
        {
            throw new NotImplementedException();
        }

        public void RemoverProjeto(int codProjeto)
        {
            throw new NotImplementedException();
        }

        public ArrayList ConsultarTodos()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IRepositorioProjeto - Tabela EMPREGADO_PROJETO

        public void InserirEmpregadoProjeto(ClassesBasicas.Projeto projeto)
        {
            throw new NotImplementedException();
        }

        public ClassesBasicas.Empregado ConsultarPorCodigoEmpregado(int codEmpregado)
        {
            throw new NotImplementedException();
        }

        public ClassesBasicas.Empregado ConsultarPorCodigoProjeto(int codProjeto)
        {
            throw new NotImplementedException();
        }

        public void RemoverEmpregadoProjeto(int codProjeto, int codEmpregado)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
