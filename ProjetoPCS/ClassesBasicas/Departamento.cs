using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassesBasicas
{
    public class Departamento
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

        private ArrayList localidades;
        public ArrayList Localidades
        {
            get { return localidades; }
            set { localidades = value; }
        }

        public Departamento()
        {
        }

        public Departamento(int codigo, string nome)
        {
            this.codigo = codigo;
            this.nome = nome;
        }

        public Departamento(int codigo, string nome, ArrayList localidades)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.localidades = localidades;
        }
    }
}
