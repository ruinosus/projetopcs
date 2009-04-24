using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using MySql.Data.MySqlClient;
using Util;
using Excecoes;
using System.Collections;
using System.Windows.Forms;
using ClassesBasicas;

namespace Repositorio.implementacoes
{
    public class RepositorioLocalidade : IRepositorioLocalidade
    {

        #region Sql Tabela LOCALIDADE

        private static String QUERY_INSERT = "INSERT INTO LOCALIDADE (NOME_LOCALIDADE) VALUES (?nomeLocalidade)";
        private static String QUERY_UPDATE = "UPDATE LOCALIDADE SET NOME_LOCALIDADE = ?nomeLocalidade WHERE COD_LOCALIDADE = ?codLocalidade";
        private static String QUERY_SELECT_ALL = "SELECT * FROM LOCALIDADE ORDER BY NOME_LOCALIDADE";
        private static String QUERY_SELECT_CODIGO = "SELECT * FROM LOCALIDADE WHERE COD_LOCALIDADE = ?codLocalidade";
        private static String QUERY_SELECT_NOME = "SELECT * FROM LOCALIDADE WHERE NOME_LOCALIDADE LIKE ?nomeLocalidade";
        private static String QUERY_DELETE = "DELETE FROM LOCALIDADE WHERE COD_LOCALIDADE = ?codLocalidade";

        #endregion
       
        #region IRepositorioLocalidade - Tabela LOCALIDADE 

        public void InserirLocalidade(ClassesBasicas.Localidade localidade)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {                
                MySqlCommand comando = new MySqlCommand(QUERY_INSERT, conexao);
                comando.Parameters.AddWithValue("?nomeLocalidade", localidade.Nome);

                if (conexao.State == System.Data.ConnectionState.Closed)
                {
                    conexao.Open();
                }
                else
                {
                    conexao.Close();
                    conexao.Open();
                }
                int regitrosAfetados = comando.ExecuteNonQuery();                
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
        }

        public void AlterarLocalidade(ClassesBasicas.Localidade localidade)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_UPDATE, conexao);
                comando.Parameters.AddWithValue("?nomeLocalidade", localidade.Nome);
                comando.Parameters.AddWithValue("?codLocalidade", localidade.Codigo);

                if (conexao.State == System.Data.ConnectionState.Closed)
                {
                    conexao.Open();
                }
                else
                {
                    conexao.Close();
                    conexao.Open();
                }
                int regitrosAfetados = comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
        }

        public System.Collections.ArrayList ConsultarTodos()
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();
            ArrayList localidades = new ArrayList();
            try
            {

                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_ALL, conexao);
                MySqlDataReader resultado;

                if (conexao.State == System.Data.ConnectionState.Closed)
                {
                    conexao.Open();
                }
                else
                {
                    conexao.Close();
                    conexao.Open();
                }
                resultado = comando.ExecuteReader();
                //resultado.Read();
                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        localidades.Add(this.CriarLocalidade(resultado));
                    }
                }
                else
                {
                     // throw new ObjetoNaoExistente();
                }
                resultado.Close();
            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhuma localidade encontrada.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return localidades;
        }

        public ClassesBasicas.Localidade ConsultarPorCodigo(int codLocalidade)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            Localidade localidade = null;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?codLocalidade", codLocalidade);
                if (conexao.State == System.Data.ConnectionState.Closed)
                {
                    conexao.Open();
                }
                else
                {
                    conexao.Close();
                    conexao.Open();
                }

                resultado = comando.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows)
                {
                    localidade = this.CriarLocalidade(resultado);
                }
                else
                {
                    //  throw new ObjetoNaoExistente();
                }
                resultado.Close();
            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhuma localidade encontrada.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return localidade;
        }

        public System.Collections.ArrayList ConsultarPorNome(string nomeLocalidade)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            ArrayList localidades = new ArrayList();
            try
            {                
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_NOME, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?nomeLocalidade", "%" + nomeLocalidade + "%");

                if (conexao.State == System.Data.ConnectionState.Closed)
                {
                    conexao.Open();
                }
                else
                {
                    conexao.Close();
                    conexao.Open();
                }

                resultado = comando.ExecuteReader();
               // resultado.Read();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        localidades.Add(this.CriarLocalidade(resultado));
                    }
                }
                else
                {
                   //  throw new ObjetoNaoExistente();
                }
                resultado.Close();
            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhuma localidade encontrada.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
            return localidades;
        }

        public void RemoverLocalidade(int codLocalidade)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {                
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE, conexao);
                comando.Parameters.AddWithValue("?codLocalidade", codLocalidade);

                if (conexao.State == System.Data.ConnectionState.Closed)
                {
                    conexao.Open();
                }
                else
                {
                    conexao.Close();
                    conexao.Open();
                }
                int regitrosAfetados = comando.ExecuteNonQuery();                

                if (regitrosAfetados == 0)
                {
                    // throw new ObjetoNaoExistente();
                }

            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhuma localidade encontrada.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
        }

        #endregion                

        private Localidade CriarLocalidade(MySqlDataReader resultado)
        {
            int CodLocalidade = resultado.GetInt32("COD_LOCALIDADE");
            String nome = resultado.GetString("NOME_LOCALIDADE");

            return new Localidade(CodLocalidade, nome);
        }


    }
}
