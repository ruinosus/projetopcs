using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;
using System.Collections;

namespace Repositorio.interfaces
{
    public interface IRepositorioDepartamento
    {
        void InserirDepartamento(Departamento departamento);
        Departamento ConsultarPorCodigo(int codDepartamento);
        ArrayList ConsultarPorNome(String nomeDepartamento);
        void RemoverDepartamento(int codDepartamento);
        ArrayList ConsultarTodos();
        void InserirDepartamentoLocalidade(Departamento departamento);
        void RemoverDepartamentoLocalidade(int codDepartamento);
        int ObterMaximoCodigo();
    }
}
