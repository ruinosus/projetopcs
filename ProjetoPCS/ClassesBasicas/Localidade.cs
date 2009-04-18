using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    public class Localidade
    {
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public Localidade()
        { 
        }

        public Localidade(int codigo, string nome)
        {
            this.codigo = codigo;
            this.nome = nome;
        }
    }
}
