using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;
using System.Collections;

namespace Repositorio.interfaces
{
    public interface IRepositorioProjeto
    {
        #region Tabela PROJETO
        void InserirProjeto(Projeto projeto);
        Empregado ConsultarPorCodigo(int codProjeto);
        ArrayList ConsultarPorNome(String nomeProjeto);
        void RemoverProjeto(int codProjeto);
        ArrayList ConsultarTodos();
        #endregion

        #region Tabela EMPREGADO_PROJETO
        void InserirEmpregadoProjeto(Projeto projeto);
        Empregado ConsultarPorCodigoEmpregado(int codEmpregado);
        Empregado ConsultarPorCodigoProjeto(int codProjeto);
        void RemoverEmpregadoProjeto(int codProjeto,int codEmpregado);
        #endregion
    }
}
