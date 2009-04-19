using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;

namespace Repositorio.implementacoes
{
    public class RepositorioEmpregado : IRepositorioEmpregado
    {
        #region IRepositorioEmpregado Members

        public void InserirEmpregado(ClassesBasicas.Empregado empregado)
        {
            throw new NotImplementedException();
        }

        public ClassesBasicas.Empregado ConsultarPorCodigo(int codEmpregado)
        {
            throw new NotImplementedException();
        }

        public System.Collections.ArrayList ConsultarPorNome(string nomeEmpregado)
        {
            throw new NotImplementedException();
        }

        public void RemoverEmpregado(int codEmpregado)
        {
            throw new NotImplementedException();
        }

        public System.Collections.ArrayList ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
