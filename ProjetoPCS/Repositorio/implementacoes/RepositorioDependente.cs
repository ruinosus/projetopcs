using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using MySql.Data.MySqlClient;
using Util;
using Excecoes;
using ClassesBasicas;
using System.Windows.Forms;
using System.Collections;

namespace Repositorio.implementacoes
{
    public class RepositorioDependente : IRepositorioDependente
    {
        private static String QUERY_INSERT = "INSERT INTO DEPENDENTE (COD_EMPREGADO,NOME_DEPENDENTE,GRAU_PARENTESCO,DATA_NASCIMENTO,SEXO) VALUES (?codEmpregado,nomeDependente,grauParentesco,dataNascimento,sexo)";
        private static String QUERY_SELECT_ALL = "SELECT * FROM DEPENDENTE ORDER BY NOME_DEPENDENTE";
        private static String QUERY_SELECT_CODIGO = "SELECT * FROM DEPENDENTE WHERE COD_DEPENDENTE = ?codDependente";
        private static String QUERY_SELECT_NOME = "SELECT * FROM DEPENDENTE WHERE NOME_DEPENDENTE LIKE ?nomeDependente";
        private static String QUERY_DELETE = "DELETE FROM DEPENDENTE WHERE COD_DEPENDENTE = ?codDependente";

        #region IRepositorioDependente Members

        public void InserirDependente(int codEmpregado,ClassesBasicas.Dependente dependente)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_INSERT, conexao);
                comando.Parameters.AddWithValue("?codEmpregado", codEmpregado);
                comando.Parameters.AddWithValue("?nomeDependente", dependente.Nome);
                comando.Parameters.AddWithValue("?grauParentesco", dependente.GrauParentesco);
                comando.Parameters.AddWithValue("?dataNascimento", dependente.DataNascimento);
                comando.Parameters.AddWithValue("?sexo", dependente.Sexo);

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

        public ClassesBasicas.Dependente ConsultarPorCodigo(int codDependente)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            Dependente dependente = null;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?codDependente", codDependente);
                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows)
                {
                    dependente = this.CriarDependente(resultado);
                }
                else
                {
                    throw new ObjetoNaoExistente();
                }
                resultado.Close();
            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum dependente encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }

            return dependente;
        }

        public System.Collections.ArrayList ConsultarPorNome(string nomeDependente)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            ArrayList dependentes = new ArrayList();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_NOME, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("%" + "?nomeDependente" + "%", nomeDependente);

                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        dependentes.Add(this.CriarDependente(resultado));
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
                MessageBox.Show("Nenhum dependente encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }
            return dependentes;
        }

        public void RemoverDependente(int codDependente)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE, conexao);
                comando.Parameters.AddWithValue("?codDependente", codDependente);

                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();

                if (regitrosAfetados == 0)
                {
                    throw new ObjetoNaoExistente();
                }

            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum dependente encontrado.");
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
            ArrayList dependentes = new ArrayList();
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
                        dependentes.Add(this.CriarDependente(resultado));
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
                MessageBox.Show("Nenhum dependente encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }

            return dependentes;
        }

        #endregion

        private Dependente CriarDependente(MySqlDataReader resultado)
        {
            int codDependente = resultado.GetInt32("COD_DEPENDENTE");
            string nome = resultado.GetString("NOME_DEPENDENTE");
            string grauParentesco = resultado.GetString("GRAU_PARENTESCO");
            DateTime dataNascimento = resultado.GetDateTime("DATA_NASCIMENTO");
            char sexo = resultado.GetChar("SEXO");

            return new Dependente(codDependente,nome,dataNascimento,sexo,grauParentesco);
        }

    }
}
