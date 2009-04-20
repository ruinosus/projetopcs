using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;
using System.Collections;

namespace Repositorio.interfaces
{
    public interface IRepositorioEndereco
    {
        #region Tabela ENDERECO
        void InserirEndereco(Endereco endereco);
        Endereco ConsultarPorCodigo(int codEndereco);
        void RemoverEndereco(int codEndereco);
        ArrayList ConsultarTodos(); 
        #endregion
    }
}
