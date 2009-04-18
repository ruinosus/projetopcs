using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    public class Endereco
    {
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string logradouro;
        public string Logradouro
        {
            get { return logradouro; }
            set { logradouro = value; }
        }

        private string bairro;
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        private string complemento;
        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        private int cep;
        public int Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        private string numero;
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private string uf;
        public string Uf
        {
            get { return uf; }
            set { uf = value; }
        }

        private string cidade;
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        private string pais;
        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        public Endereco()
        {
        }

        public Endereco(int codigo, string logradouro, string bairro, string complemento, int cep, string numero, string uf, string cidade, string pais)
        {
            this.codigo = codigo;
            this.logradouro = logradouro;
            this.bairro = bairro;
            this.complemento = complemento;
            this.cep = cep;
            this.numero = numero;
            this.uf = uf;
            this.cidade = cidade;
            this.pais = pais;

        }
    }
}
