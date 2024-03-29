﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;
using System.Collections;

namespace Repositorio.interfaces
{
    public interface IRepositorioDepartamento
    {
        #region Tabela DEPARTAMENTO

        void InserirDepartamento(Departamento departamento);
        void AlterarDepartamento(Departamento departamento);
        Departamento ConsultarPorCodigo(int codDepartamento);
        ArrayList ConsultarPorNome(String nomeDepartamento);
        void RemoverDepartamento(int codDepartamento);
        ArrayList ConsultarTodos(); 

        #endregion

        #region Tabela DEPARTAMENTO_LOCALIDADE

        void InserirDepartamentoLocalidade(Departamento departamento);
        void RemoverDepartamentoLocalidade(int codDepartamento);
        void RemoverDepartamentoLocalidade(int codDepartamento, int codLocalidade);
        int ObterMaximoCodigo(); 

        #endregion
    }
}
