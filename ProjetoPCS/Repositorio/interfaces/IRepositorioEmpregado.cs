using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;
using System.Collections;

namespace Repositorio.interfaces
{
    public interface IRepositorioEmpregado
    {
        #region Tabela EMPREGADO
        void InserirEmpregado(Empregado empregado);
        Empregado ConsultarPorCodigo(int codEmpregado);
        ArrayList ConsultarPorNome(String nomeEmpregado);
        void RemoverEmpregado(int codEmpregado);
        ArrayList ConsultarTodos(); 
        #endregion

        #region Tabela CHEFIAR
        void InserirChefiar(Empregado empregado);
        Empregado ConsultarPorCodigoEmpregadoChefiar(int codEmpregado);
        void RemoverChefiar(int codEmpregado); 
        #endregion

        #region Tabela ALOCAR
        void InserirAlocar(Empregado empregado);
        Empregado ConsultarPorCodigoEmpregadoAlocar(int codEmpregado);
        void RemoverAlocar(int codEmpregado); 
        #endregion

    }
}
