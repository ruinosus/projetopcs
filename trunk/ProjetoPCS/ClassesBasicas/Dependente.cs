using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    public class Dependente : Pessoa
    {
        private string grauParentesco;
        public string GrauParentesco
        {
            get { return grauParentesco; }
            set { grauParentesco = value; }
        }

        private Empregado empregado;
        public Empregado Empregado
        {
            get { return empregado; }
            set { empregado = value; }
        }

        public Dependente()
            : base()
        {
        }
        public Dependente(int codigo, string nome, DateTime dataNascimento, char sexo, string grauParentesco, Empregado empregado)
            : base(codigo, nome, dataNascimento, sexo)
        {
            this.grauParentesco = grauParentesco;
            this.Empregado = empregado;
        }
    }
}
