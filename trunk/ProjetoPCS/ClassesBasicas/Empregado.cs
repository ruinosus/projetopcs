using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassesBasicas
{
    public class Empregado : Pessoa
    {
        private double salario;
        public double Salario
        {
            get { return salario; }
            set { salario = value; }
        }

        private string cpf;
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        private string rg;
        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }

        private string telefone;
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }        

        private Endereco endereco;
        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        #region Alocado em um Departamento
        private Departamento departamentoAlocado;
        public Departamento DepartamentoAlocado
        {
            get { return departamentoAlocado; }
            set { departamentoAlocado = value; }
        }
        private DateTime dataAlocação;
        public DateTime DataAlocação
        {
            get { return dataAlocação; }
            set { dataAlocação = value; }
        } 
        #endregion

        #region Chefiar Departamento

        private Departamento departamentoChefiado;
        public Departamento DepartamentoChefiado
        {
            get { return departamentoChefiado; }
            set { departamentoChefiado = value; }
        }

        private DateTime dataInicio;
        public DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }

        private DateTime dataFinal;
        public DateTime DataFinal
        {
            get { return dataFinal; }
            set { dataFinal = value; }
        }

        #endregion

        private ArrayList dependentes;
        public ArrayList Dependentes
        {
            get { return dependentes; }
            set { dependentes = value; }
        }

        private Empregado supervisor;
        public Empregado Supervisor
        {
            get { return supervisor; }
            set { supervisor = value; }
        }

        public Empregado()
            : base()
        { 
        }

        public Empregado(int codigo, string nome, DateTime dataNascimento, char sexo, double salario, string cpf, string rg, string telefone, Endereco endereco, Departamento departamentoAlocado, DateTime dataAlocacao, Departamento departamentoChefiado, DateTime dataInicio, DateTime dataFinal, ArrayList dependentes, Empregado supervisor)
            : base(codigo, nome, dataNascimento, sexo)
        {
            this.salario = salario;
            this.cpf = cpf;
            this.rg = rg;
            this.telefone = telefone;
            this.endereco = endereco;
            this.departamentoAlocado = departamentoAlocado;
            this.dataAlocação = dataAlocacao;
            this.departamentoChefiado = departamentoChefiado;
            this.dataInicio = dataInicio;
            this.dataFinal = dataFinal;
            this.dependentes = dependentes;
            this.supervisor = supervisor;

        }


    }
}
