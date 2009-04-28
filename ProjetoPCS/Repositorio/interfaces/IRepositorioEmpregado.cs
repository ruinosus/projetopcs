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
        void AlterarEmpregado(Empregado empregado);
        Empregado ConsultarPorCodigo(int codEmpregado);
        ArrayList ConsultarPorNome(String nomeEmpregado);
        void RemoverEmpregado(int codEmpregado);
        ArrayList ConsultarTodos(); 
        int ObterMaximoCodigo();

        #endregion

        #region Tabela CHEFIAR

        void InserirChefiar(Empregado empregado);
        void AlterarChefiar(Empregado empregado);
        Empregado ConsultarPorCodigoEmpregadoChefiar(Empregado empregado);
        void RemoverChefiar(int codEmpregado); 

        #endregion

        #region Tabela ALOCAR

        void InserirAlocar(Empregado empregado);
        void AlterarAlocar(Empregado empregado);
        Empregado ConsultarPorCodigoEmpregadoAlocar(Empregado empregado);
        void RemoverAlocar(int codEmpregado); 

        #endregion

    }
}
