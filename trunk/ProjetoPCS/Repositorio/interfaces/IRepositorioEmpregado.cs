using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;
using System.Collections;

namespace Repositorio.interfaces
{
    public class IRepositorioEmpregado
    {
        void InserirEmpregado(Empregado empregado);
        Empregado ConsultarPorCodigo(int codEmpregado);
        ArrayList ConsultarPorNome(String nomeEmpregado);
        void RemoverEmpregado(int codEmpregado);
        ArrayList ConsultarTodos();
    }
}
