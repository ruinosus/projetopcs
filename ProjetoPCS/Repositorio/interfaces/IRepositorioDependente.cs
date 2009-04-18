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
        void InserirDependente(int codEmpregado,Dependente dependente);
        Dependente ConsultarPorCodigo(int codDependente);
        ArrayList ConsultarPorNome(String nomeDependente);
        void RemoverDependente(int codDependente);
        ArrayList ConsultarTodos();
    }
}
