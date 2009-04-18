using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    public class Pessoa
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

        private DateTime dataNascimento;
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        private char sexo;
        public char Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public Pessoa()
        {
        }

        public Pessoa(int codigo, string nome, DateTime dataNascimento, char sexo)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.dataNascimento = dataNascimento;
            this.sexo = sexo;
        }
    }
}
