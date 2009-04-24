using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using Util;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using ClassesBasicas;
using System.Collections;
using Excecoes;

namespace Repositorio.implementacoes
{
    public class RepositorioDepartamento : IRepositorioDepartamento
    {
        private IRepositorioLocalidade repLocalidade = new RepositorioLocalidade();

        #region Sql da tabela DEPARTAMENTO

        private static String QUERY_INSERT = "INSERT INTO DEPARTAMENTO (NOME_DEPARTAMENTO) VALUES (?nomeDepartamento)";
        private static String QUERY_UPDATE = "UPDATE DEPARTAMENTO SET NOME_DEPARTAMENTO = ?nomeDepartamento WHERE COD_DEPARTAMENTO = ?codDepartamento ";
        private static String QUERY_SELECT_ALL = "SELECT * FROM DEPARTAMENTO ORDER BY NOME_DEPARTAMENTO";
        private static String QUERY_SELECT_CODIGO = "SELECT * FROM DEPARTAMENTO WHERE COD_DEPARTAMENTO = ?codDepartamento";
        private static String QUERY_SELECT_NOME = "SELECT * FROM DEPARTAMENTO WHERE NOME_DEPARTAMENTO LIKE ?nomeDepartamento";
        private static String QUERY_DELETE = "DELETE FROM DEPARTAMENTO WHERE COD_DEPARTAMENTO = ?codDepartamento";
        private static String QUERY_MAX_CODIGO = "SELECT MAX(COD_DEPARTAMENTO) MAXCOD FROM DEPARTAMENTO";

        #endregion

        #region Sql da tabela DEPARTAMENTO_LOCALIDADE

        private static String QUERY_INSERT_DEPARTAMENTO_LOCALIDADE = "INSERT INTO DEPARTAMENTO_LOCALIDADE (COD_DEPARTAMENTO,COD_LOCALIDADE) VALUES (?codDepartamento,?codLocalidade)";
        private static String QUERY_SELECT_CODIGO_DEPARTAMENTO = "SELECT * FROM DEPARTAMENTO_LOCALIDADE WHERE  COD_DEPARTAMENTO = ?codDepartamento";
        private static String QUERY_DELETE_DEPARTAMENTO_LOCALIDADE_1 = "DELETE FROM DEPARTAMENTO_LOCALIDADE WHERE COD_DEPARTAMENTO = ?codDepartamento";
        private static String QUERY_DELETE_DEPARTAMENTO_LOCALIDADE_2 = "DELETE FROM DEPARTAMENTO_LOCALIDADE WHERE COD_DEPARTAMENTO = ?codDepartamento AND COD_LOCALIDADE = ?codLocalidade";
        //private static String QUERY_SELECT_CODIGO_LOCALIDADE = "SELECT * FROM DEPARTAMENTO_LOCALIDADE WHERE  COD_LOCALIDADE = ?codLocalidade";

        #endregion

        #region IRepositorioDepartamento - Tabela DEPARTAMENTO

        public void InserirDepartamento(ClassesBasicas.Departamento departamento)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_INSERT, conexao);
                comando.Parameters.AddWithValue("?nomeDepartamento", departamento.Nome);

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

        public void AlterarDepartamento(Departamento departamento)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_UPDATE, conexao);
                comando.Parameters.AddWithValue("?nomeDepartamento", departamento.Nome);
                comando.Parameters.AddWithValue("?codDepartamento", departamento.Codigo);

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

        public Departamento ConsultarPorCodigo(int codDepartamento)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            Departamento departamento = null;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?codDepartamento", codDepartamento);
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
                    departamento = this.CriarDepartamento(resultado);
                }
                else
                {
                   // throw new ObjetoNaoExistente();
                }
                resultado.Close();
            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum departamento encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return departamento;
        }

        public ArrayList ConsultarPorNome(string nomeDepartamento)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            ArrayList departamentos = new ArrayList();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_NOME, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?nomeDepartamento" ,"%" +  nomeDepartamento+ "%");

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
                        departamentos.Add(this.CriarDepartamento(resultado));
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
                MessageBox.Show("Nenhum departamento encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
            return departamentos;
        }

        public void RemoverDepartamento(int codDepartamento)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE, conexao);
                comando.Parameters.AddWithValue("?codDepartamento", codDepartamento);

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
                MessageBox.Show("Nenhum departamento encontrado.");
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

        public ArrayList ConsultarTodos()
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            ArrayList departamentos = new ArrayList();
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
                        departamentos.Add(this.CriarDepartamento(resultado));
                    }
                }
                else
                {
                    //throw new ObjetoNaoExistente();
                }
                resultado.Close();
            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum departamento encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return departamentos;
        }

        #endregion

        #region IRepositorioDepartamento - Tabela DEPARTAMENTO_LOCALIDADE

        public void InserirDepartamentoLocalidade(Departamento departamento)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {

                for (int i = 0; i < departamento.Localidades.Count; i++)
                {
                    MySqlCommand comando = new MySqlCommand(QUERY_INSERT_DEPARTAMENTO_LOCALIDADE, conexao);
                    comando.Parameters.AddWithValue("?codDepartamento", departamento.Codigo);
                    Localidade localidade = (Localidade)departamento.Localidades[i];
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
                }
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

        public void RemoverDepartamentoLocalidade(int codDepartamento)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE_DEPARTAMENTO_LOCALIDADE_1, conexao);
                comando.Parameters.AddWithValue("?codDepartamento", codDepartamento);

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
                MessageBox.Show("Nenhum departamento encontrado.");
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

        public void RemoverDepartamentoLocalidade(int codDepartamento, int codLocalidade)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE_DEPARTAMENTO_LOCALIDADE_2, conexao);
                comando.Parameters.AddWithValue("?codDepartamento", codDepartamento);
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
                MessageBox.Show("Nenhum departamento encontrado.");
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

        public int ObterMaximoCodigo()
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();
            int codigo = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_MAX_CODIGO, conexao);
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
                resultado.Read();

                if (resultado.HasRows)
                {
                    codigo = resultado.GetInt32("MAXCOD");
                }
                resultado.Close();
                banco.FecharConexao(conexao);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return codigo;
        }

        #endregion

        private Departamento CriarDepartamento(MySqlDataReader resultado)
        {
            int CodDepartamento = resultado.GetInt32("COD_DEPARTAMENTO");
            String nome = resultado.GetString("NOME_DEPARTAMENTO");
            ArrayList localidades = this.ConsultarPorDepartamento(CodDepartamento);
            return new Departamento(CodDepartamento, nome,localidades);
        }

        private ArrayList ConsultarPorDepartamento(int codDepartamento)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            ArrayList localidades = new ArrayList();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO_DEPARTAMENTO, conexao);
                MySqlDataReader resultado;

                comando.Parameters.AddWithValue("?codDepartamento", codDepartamento);

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
                        int codLocalidade = resultado.GetInt32("COD_LOCALIDADE");
                        localidades.Add(repLocalidade.ConsultarPorCodigo(codLocalidade));
                      }
                }
                resultado.Close();
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

        

        

    }
}
