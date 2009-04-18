using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassesBasicas
{
    public class Projeto
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

        private Departamento departamento;
        public Departamento Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        private Localidade localidade;
        public Localidade Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }

        private ArrayList funcionarios;
        public ArrayList Funcionarios
        {
            get { return funcionarios; }
            set { funcionarios = value; }
        }

        public Projeto()
        { 
        }
    }
}
