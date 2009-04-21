using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;
using System.Collections;

namespace Repositorio.interfaces
{
    public interface IRepositorioDependente
    {
        #region Tabela DEPENDENTE

        void InserirDependente(int codEmpregado, Dependente dependente);
        void AlterarDependente(int codEmpregado, Dependente dependente);
        Dependente ConsultarPorCodigo(int codDependente);
        ArrayList ConsultarPorEmpregado(int codEmpregado);
        ArrayList ConsultarPorNome(String nomeDependente);
        void RemoverDependente(int codDependente);
        ArrayList ConsultarTodos(); 

        #endregion

    }
}
