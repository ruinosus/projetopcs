using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;
using System.Collections;

namespace Repositorio.interfaces
{
    public interface IRepositorioLocalidade
    {
        void InserirLocalidade(Localidade localidade);
        Localidade ConsultarPorCodigo(int codLocalidade);
        ArrayList ConsultarPorNome(String nomeLocalidade);
        void RemoverLocalidade(int codLocalidade);
        ArrayList ConsultarTodos();
    }
}
