﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using MySql.Data.MySqlClient;
using Util;
using System.Windows.Forms;
using ClassesBasicas;
using System.Collections;
using Excecoes;

namespace Repositorio.implementacoes
{
    public class RepositorioEmpregado : IRepositorioEmpregado
    {
        private IRepositorioDependente repDependente = new RepositorioDependente();
        private IRepositorioEndereco repEndereco = new RepositorioEndereco();
        private IRepositorioDepartamento repDepartamento = new RepositorioDepartamento();

        //private static String QUERY_SELECT_PADRAO = "SELECT E.COD_EMPREGADO CODIGO, E.COD_EMPREGADO_SUPERVISOR SUPERVISOR, E.COD_ENDERECO ENDERECO, E.NOME_EMPREGADO NOME, E.SALARIO, E.CPF, E.DATA_NASCIMENTO, E.RG, E.SEXO, E.TELEFONE, A.COD_DEPARTAMENTO ALOCADO, A.DATA_ALOCACAO DATA_ALOCACAO, C.COD_DEPARTAMENTO CHEFIADO, C.DATA_INICIO DATA_INICIO, C.DATA_FINAL DATA_FINAL  FROM EMPREGADO E INNER JOIN CHEFIAR C  ON C.COD_EMPREGADO = E.COD_EMPREGADO INNER JOIN ALOCAR A ON A.COD_EMPREGADO= E.COD_EMPREGADO WHERE E.COD_EMPREGADO IN (?codEmpregado) ";
   
        #region Sql da tabela EMPREGADO

        private static String QUERY_INSERT = "INSERT INTO EMPREGADO (COD_ENDERECO,NOME_EMPREGADO,SALARIO,CPF,DATA_NASCIMENTO,RG,SEXO,TELEFONE) VALUES (?codEndereco,?nomeEmpregado,?salario,?cpf,?dataNascimento,?rg,?sexo,?telefone)";
        private static String QUERY_INSERT_SUPERVISOR = "INSERT INTO EMPREGADO (COD_EMPREGADO_SUPERVISOR,COD_ENDERECO,NOME_EMPREGADO,SALARIO,CPF,DATA_NASCIMENTO,RG,SEXO,TELEFONE) VALUES (?codEmpregadoSupervisor,?codEndereco,?nomeEmpregado,?salario,?cpf,?dataNascimento,?rg,?sexo,?telefone)";
        private static String QUERY_SELECT_ALL = "SELECT E.COD_EMPREGADO CODIGO, E.COD_EMPREGADO_SUPERVISOR SUPERVISOR, E.COD_ENDERECO ENDERECO, E.NOME_EMPREGADO NOME, E.SALARIO, E.CPF, E.DATA_NASCIMENTO, E.RG, E.SEXO, E.TELEFONE, A.COD_DEPARTAMENTO ALOCADO, A.DATA_ALOCACAO DATA_ALOCACAO, C.COD_DEPARTAMENTO CHEFIADO, C.DATA_INICIO DATA_INICIO, C.DATA_FINAL DATA_FINAL  FROM EMPREGADO E INNER JOIN CHEFIAR C  ON C.COD_EMPREGADO = E.COD_EMPREGADO INNER JOIN ALOCAR A ON A.COD_EMPREGADO= E.COD_EMPREGADO ORDER BY NOME_EMPREGADO";
        private static String QUERY_SELECT_CODIGO = "SELECT E.COD_EMPREGADO CODIGO, E.COD_EMPREGADO_SUPERVISOR SUPERVISOR, E.COD_ENDERECO ENDERECO, E.NOME_EMPREGADO NOME, E.SALARIO, E.CPF, E.DATA_NASCIMENTO, E.RG, E.SEXO, E.TELEFONE, A.COD_DEPARTAMENTO ALOCADO, A.DATA_ALOCACAO DATA_ALOCACAO, C.COD_DEPARTAMENTO CHEFIADO, C.DATA_INICIO DATA_INICIO, C.DATA_FINAL DATA_FINAL  FROM EMPREGADO E INNER JOIN CHEFIAR C  ON C.COD_EMPREGADO = E.COD_EMPREGADO INNER JOIN ALOCAR A ON A.COD_EMPREGADO= E.COD_EMPREGADO WHERE E.COD_EMPREGADO IN (?codEmpregado)";
        private static String QUERY_SELECT_NOME = "SELECT E.COD_EMPREGADO CODIGO, E.COD_EMPREGADO_SUPERVISOR SUPERVISOR, E.COD_ENDERECO ENDERECO, E.NOME_EMPREGADO NOME, E.SALARIO, E.CPF, E.DATA_NASCIMENTO, E.RG, E.SEXO, E.TELEFONE, A.COD_DEPARTAMENTO ALOCADO, A.DATA_ALOCACAO DATA_ALOCACAO, C.COD_DEPARTAMENTO CHEFIADO, C.DATA_INICIO DATA_INICIO, C.DATA_FINAL DATA_FINAL  FROM EMPREGADO E INNER JOIN CHEFIAR C  ON C.COD_EMPREGADO = E.COD_EMPREGADO INNER JOIN ALOCAR A ON A.COD_EMPREGADO= E.COD_EMPREGADO WHERE NOME_EMPREGADO LIKE ?nomeEmpregado ORDER BY NOME_EMPREGADO";
        private static String QUERY_DELETE = "DELETE FROM EMPREGADO WHERE COD_EMPREGADO = ?codEmpregado";

        #endregion

        #region Sql da tabela CHEFIAR

        private static String QUERY_INSERT_CHEFIAR = "INSERT INTO CHEFIAR (COD_EMPREGADO,COD_DEPARTAMENTO,DATA_INICIO,DATA_FINAL) VALUES (?codEmpregado,?codDepartamento,?dataInicio,?dataFinal)";
        private static String QUERY_SELECT_CODIGO_EMPREGADO_CHEFIAR = "SELECT * FROM CHEFIAR WHERE COD_EMPREGADO = ?codEmpregado";
        private static String QUERY_DELETE_CHEFIAR = "DELETE FROM CHEFIAR WHERE COD_EMPREGADO = ?codEmpregado";
 
        #endregion

        #region Sql da tabela ALOCAR

        private static String QUERY_INSERT_ALOCAR = "INSERT INTO ALOCAR (COD_EMPREGADO,COD_DEPARTAMENTO,DATA_ALOCACAO) VALUES (?codEmpregado,?codDepartamento,?dataAlocacao)";
        private static String QUERY_SELECT_CODIGO_EMPREGADO_ALOCAR = "SELECT * FROM ALOCAR WHERE COD_EMPREGADO = ?codEmpregado";
        private static String QUERY_DELETE_ALOCAR = "DELETE FROM ALOCAR WHERE COD_EMPREGADO = ?codEmpregado";

        #endregion
       
        #region IRepositorioEmpregado - Tabela EMPREGADO

        public void InserirEmpregado(ClassesBasicas.Empregado empregado)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();

            try
            {
                MySqlCommand comando;

                if (empregado.Codigo == 0)
                {
                     comando = new MySqlCommand(QUERY_INSERT, conexao);
                }
                else
                {
                     comando = new MySqlCommand(QUERY_INSERT_SUPERVISOR, conexao);
                     comando.Parameters.AddWithValue("?codEmpregadoSupervisor", empregado.Supervisor.Codigo);
                }

                comando.Parameters.AddWithValue("?codEndereco", empregado.Endereco.Codigo);
                comando.Parameters.AddWithValue("?nomeEmpregado", empregado.Nome);
                comando.Parameters.AddWithValue("?salario", empregado.Salario);                
                comando.Parameters.AddWithValue("?cpf", empregado.Cpf);
                comando.Parameters.AddWithValue("?dataNascimento", empregado.DataNascimento);
                comando.Parameters.AddWithValue("?rg", empregado.Rg);
                comando.Parameters.AddWithValue("?sexo", empregado.Sexo);
                comando.Parameters.AddWithValue("?telefone", empregado.Telefone);

                conexao.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }
        }

        public ClassesBasicas.Empregado ConsultarPorCodigo(int codEmpregado)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            Empregado empregado = null;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?codEmpregado", codEmpregado);
                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows)
                {
                    empregado = this.CriarEmpregado(resultado);
                }
                else
                {
                    throw new ObjetoNaoExistente();
                }
                resultado.Close();
            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum empregado encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }

            return empregado;
        }

        public System.Collections.ArrayList ConsultarPorNome(string nomeEmpregado)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            ArrayList empregados = new ArrayList();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_NOME, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("%" + "?nomeEmpregado" + "%", nomeEmpregado);

                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        empregados.Add(this.CriarEmpregado(resultado));
                    }
                }
                else
                {
                    throw new ObjetoNaoExistente();
                }
                resultado.Close();
            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum empregado encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }
            return empregados;
        }

        public void RemoverEmpregado(int codEmpregado)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE, conexao);
                comando.Parameters.AddWithValue("?codEmpregado", codEmpregado);

                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();

                if (regitrosAfetados == 0)
                {
                    throw new ObjetoNaoExistente();
                }

            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum empregado encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }
        }

        public System.Collections.ArrayList ConsultarTodos()
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            ArrayList empregados = new ArrayList();
            try
            {

                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_ALL, conexao);
                MySqlDataReader resultado;

                conexao.Open();
                resultado = comando.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        empregados.Add(this.CriarEmpregado(resultado));
                    }
                }
                else
                {
                    throw new ObjetoNaoExistente();
                }
                resultado.Close();
            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum empregado encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }

            return empregados;
        }

        #endregion       

        #region IRepositorioEmpregado - Tabela CHEFIAR

        public void InserirChefiar(Empregado empregado)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_INSERT_CHEFIAR, conexao);

                comando.Parameters.AddWithValue("?codEmpregado", empregado.Codigo);
                comando.Parameters.AddWithValue("?codDepartamento", empregado.DepartamentoChefiado.Codigo);
                comando.Parameters.AddWithValue("?dataInicio", empregado.DataInicio);
                comando.Parameters.AddWithValue("?dataFinal", empregado.DataFinal);

                conexao.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }
        }

        public Empregado ConsultarPorCodigoEmpregadoChefiar(int codEmpregado)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            Empregado empregado = null;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO_EMPREGADO_CHEFIAR, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?codEmpregado", codEmpregado);
                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows)
                {
                    empregado = this.CriarEmpregado(resultado);
                }
                else
                {
                    throw new ObjetoNaoExistente();
                }
                resultado.Close();
            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum empregado encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }

            return empregado;
        }

        public void RemoverChefiar(int codEmpregado)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE_CHEFIAR, conexao);
                comando.Parameters.AddWithValue("?codEmpregado", codEmpregado);

                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();

                if (regitrosAfetados == 0)
                {
                    throw new ObjetoNaoExistente();
                }

            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum empregado encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }
        }

        #endregion

        #region IRepositorioEmpregado - Tabela ALOCAR

        public void InserirAlocar(Empregado empregado)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_INSERT_ALOCAR, conexao);

                comando.Parameters.AddWithValue("?codEmpregado", empregado.Codigo);
                comando.Parameters.AddWithValue("?codDepartamento", empregado.DepartamentoAlocado.Codigo);
                comando.Parameters.AddWithValue("?dataAlocacao", empregado.DataAlocação);

                conexao.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }
        }

        public Empregado ConsultarPorCodigoEmpregadoAlocar(int codEmpregado)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            Empregado empregado = null;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO_EMPREGADO_ALOCAR, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?codEmpregado", codEmpregado);
                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows)
                {
                    empregado = this.CriarEmpregado(resultado);
                }
                else
                {
                    throw new ObjetoNaoExistente();
                }
                resultado.Close();
            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum empregado encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }

            return empregado;
        }

        public void RemoverAlocar(int codEmpregado)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE_ALOCAR, conexao);
                comando.Parameters.AddWithValue("?codEmpregado", codEmpregado);

                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();

                if (regitrosAfetados == 0)
                {
                    throw new ObjetoNaoExistente();
                }

            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum empregado encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }
        } 
        #endregion

        private Empregado CriarEmpregado(MySqlDataReader resultado)
        {
            int codEmpregado = resultado.GetInt32("CODIGO");
            int codEmpregadoSupervisor = resultado.GetInt32("SUPERVISOR");
            int codEndereco = resultado.GetInt32("ENDERECO");
            int cpf = resultado.GetInt32("CPF");
            int rg = resultado.GetInt32("RG");
            int telefone = resultado.GetInt32("TELEFONE");
            string nome = resultado.GetString("NOME");
            double salario = resultado.GetDouble("SALARIO");
            char sexo = resultado.GetChar("SEXO");
            DateTime dataNascimento = resultado.GetDateTime("DATA_NASCIMENTO");

            ArrayList dependentes = this.repDependente.ConsultarPorEmpregado(codEmpregado);

            int codDepartamentoAlocado = resultado.GetInt32("ALOCADO");
            DateTime dataAlocacao = resultado.GetDateTime("DATA_ALOCACAO");

            int codDepartamentoChefiado = resultado.GetInt32("CHEFIADO");
            DateTime dataInicio = resultado.GetDateTime("DATA_INICIO");
            DateTime dataFinal = resultado.GetDateTime("DATA_FINAL");

            Departamento departamentoAlocado = this.repDepartamento.ConsultarPorCodigo(codDepartamentoAlocado);
           
            Departamento departamentoChefiado = this.repDepartamento.ConsultarPorCodigo(codDepartamentoChefiado);

            Empregado supervisor = this.ConsultarPorCodigo(codEmpregadoSupervisor);

            Endereco endereco = this.repEndereco.ConsultarPorCodigo(codEndereco);

            return new Empregado(codEmpregado, nome, dataNascimento, sexo, salario, cpf, rg, telefone, endereco, departamentoAlocado, dataAlocacao, departamentoChefiado, dataInicio, dataFinal, dependentes, supervisor);

        }
    }
}
