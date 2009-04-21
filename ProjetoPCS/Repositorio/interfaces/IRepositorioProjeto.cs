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
        void AlterarProjeto(Projeto projeto);
        Projeto ConsultarPorCodigo(int codProjeto);
        ArrayList ConsultarPorNome(String nomeProjeto);
        void RemoverProjeto(int codProjeto);
        ArrayList ConsultarTodos();
        int ObterMaximoCodigo();

        #endregion

        #region Tabela EMPREGADO_PROJETO

        void InserirEmpregadoProjeto(Projeto projeto);
        ArrayList ConsultarPorCodigoProjeto(Projeto projeto);
        void RemoverEmpregadoProjeto(int codProjeto,int codEmpregado);
        
        #endregion
    }
}
