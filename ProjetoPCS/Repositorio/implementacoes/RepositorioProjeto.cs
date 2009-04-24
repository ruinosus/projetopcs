using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using System.Collections;
using MySql.Data.MySqlClient;
using Util;
using System.Windows.Forms;
using ClassesBasicas;
using Excecoes;

namespace Repositorio.implementacoes
{
    public class RepositorioProjeto : IRepositorioProjeto
    {
        private IRepositorioEmpregado repEmpregado = new RepositorioEmpregado();
        private IRepositorioDepartamento repDepartamento = new RepositorioDepartamento();
        private IRepositorioLocalidade repLocalidade = new RepositorioLocalidade();

        #region Sql da tabela PROJETO

        private static String QUERY_INSERT = "INSERT INTO PROJETO(COD_DEPARTAMENTO,COD_LOCALIDADE,NOME_PROJETO) VALUES(?codDepartamento,?codLocalidade,?nomeProjeto)";
        private static String QUERY_UPDATE = "UPDATE PROJETO SET COD_DEPARTAMENTO = ?codDepartamento, COD_LOCALIDADE = ?codLocalidade, NOME_PROJETO = ?nomeProjeto WHERE COD_PROJETO = ?codProjeto";
        private static String QUERY_SELECT_ALL = "SELECT * FROM PROJETO  ORDER BY NOME_PROJETO";
        private static String QUERY_SELECT_CODIGO = "SELECT * FROM PROJETO WHERE COD_PROJETO = ?codProjeto";
        private static String QUERY_SELECT_NOME = "SELECT * FROM PROJETO  WHERE NOME_PROJETO LIKE ?nomeProjeto";
        private static String QUERY_DELETE = "DELETE FROM PROJETO WHERE COD_PROJETO = ?codProjeto";
        private static String QUERY_MAX_CODIGO = "SELECT MAX(COD_PROJETO) MAXCOD FROM PROJETO";

        #endregion

        #region Sql da tabela EMPREGADO_PROJETO

        private static String QUERY_INSERT_EMPREGADO_PROJETO = "INSERT INTO EMPREGADO_PROJETO (COD_PROJETO,COD_EMPREGADO) VALUES (?codProjeto,?codEmpregado)";
        private static String QUERY_SELECT_CODIGO_PROJETO = "SELECT * FROM EMPREGADO_PROJETO WHERE COD_PROJETO = ?codProjeto";
        private static String QUERY_DELETE_EMPREGADO_PROJETO_1 = "DELETE FROM EMPREGADO_PROJETO WHERE COD_PROJETO = ?codProjeto ";
        private static String QUERY_DELETE_EMPREGADO_PROJETO_2 = "DELETE FROM EMPREGADO_PROJETO WHERE COD_PROJETO = ?codProjeto AND COD_EMPREGADO = ?codEmpregado";

        #endregion

        #region IRepositorioProjeto - Tabela PROJETO

        public void InserirProjeto(ClassesBasicas.Projeto projeto)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_INSERT, conexao);

                comando.Parameters.AddWithValue("?codDepartamento", projeto.Departamento.Codigo);
                comando.Parameters.AddWithValue("?codLocalidade", projeto.Localidade.Codigo);
                comando.Parameters.AddWithValue("?nomeprojeto", projeto.Nome);

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

        public void AlterarProjeto(ClassesBasicas.Projeto projeto)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_UPDATE, conexao);

                comando.Parameters.AddWithValue("?codDepartamento", projeto.Departamento.Codigo);
                comando.Parameters.AddWithValue("?codLocalidade", projeto.Localidade.Codigo);
                comando.Parameters.AddWithValue("?nomeprojeto", projeto.Nome);
                comando.Parameters.AddWithValue("?codProjeto", projeto.Codigo);

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

        public Projeto ConsultarPorCodigo(int codProjeto)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            Projeto projeto = null;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?codProjeto", codProjeto);
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
                    projeto = this.CriarProjeto(resultado);
                }
                else
                {
                  //  throw new ObjetoNaoExistente();
                }
                resultado.Close();
            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum projeto encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return projeto;
        }

        public ArrayList ConsultarPorNome(string nomeProjeto)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            ArrayList projetos = new ArrayList();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_NOME, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue( "?nomeProjeto" ,"%" + nomeProjeto+ "%");

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
                        projetos.Add(this.CriarProjeto(resultado));
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
                MessageBox.Show("Nenhum projeto encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
            return projetos;
        }

        public void RemoverProjeto(int codProjeto)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE, conexao);
                comando.Parameters.AddWithValue("?codProjeto", codProjeto);

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
                MessageBox.Show("Nenhum projeto encontrado.");
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

            ArrayList projetos = new ArrayList();
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
                        projetos.Add(this.CriarProjeto(resultado));
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
                MessageBox.Show("Nenhum projeto encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return projetos;
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

        #region IRepositorioProjeto - Tabela EMPREGADO_PROJETO

        public void InserirEmpregadoProjeto(ClassesBasicas.Projeto projeto)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {

                for (int i = 0; i < projeto.Empregados.Count; i++)
                {
                    MySqlCommand comando = new MySqlCommand(QUERY_INSERT_EMPREGADO_PROJETO, conexao);
                    comando.Parameters.AddWithValue("?codProjeto", projeto.Codigo);
                    Empregado empregado = (Empregado)projeto.Empregados[i];
                    comando.Parameters.AddWithValue("?codEmpregado", empregado.Codigo);

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

        public ArrayList ConsultarPorCodigoProjeto(Projeto projeto)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            ArrayList empregados = projeto.Empregados;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO_PROJETO, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?codProjeto", projeto.Codigo);

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
                        int codigo = resultado.GetInt32("COD_EMPREGADO");
                        empregados.Add(this.repEmpregado.ConsultarPorCodigo(codigo));
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
                MessageBox.Show("Nenhum projeto encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
            return empregados;
        }

        public void RemoverEmpregadoProjeto(int codProjeto)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE_EMPREGADO_PROJETO_1, conexao);
                comando.Parameters.AddWithValue("?codProjeto", codProjeto);


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
                MessageBox.Show("Nenhum projeto encontrado.");
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

        public void RemoverEmpregadoProjeto(int codProjeto, int codEmpregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE_EMPREGADO_PROJETO_2, conexao);
                comando.Parameters.AddWithValue("?codProjeto", codProjeto);
                comando.Parameters.AddWithValue("?codEmpregado", codEmpregado);

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
                MessageBox.Show("Nenhum projeto encontrado.");
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

        private Projeto CriarProjeto(MySqlDataReader resultado)
        {
            Projeto projeto = new Projeto();
            int codProjeto = resultado.GetInt32("COD_PROJETO");
            int codDepartamento = resultado.GetInt32("COD_DEPARTAMENTO");
            int codLocalidade = resultado.GetInt32("COD_LOCALIDADE");
            string nome = resultado.GetString("NOME_PROJETO");

            projeto.Codigo = codProjeto;
            projeto.Nome = nome;

            projeto.Departamento = this.repDepartamento.ConsultarPorCodigo(codDepartamento);
            projeto.Localidade = this.repLocalidade.ConsultarPorCodigo(codLocalidade);
            projeto.Empregados = this.ConsultarPorCodigoProjeto(projeto);

            return projeto;

        }
    }
}
