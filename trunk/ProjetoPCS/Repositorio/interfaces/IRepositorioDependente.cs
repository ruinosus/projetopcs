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

        void InserirDependente(Dependente dependente);
        void AlterarDependente(Dependente dependente);
        Dependente ConsultarPorCodigo(int codDependente);
        ArrayList ConsultarPorNome(String nomeDependente);
        void RemoverDependente(int codDependente);
        ArrayList ConsultarTodos(); 

        #endregion

    }
}
