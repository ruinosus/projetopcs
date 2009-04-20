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
        private static String QUERY_SELECT_ALL = "SELECT P.COD_PROJETO PROJETO, P.COD_DEPARTAMENTO, P.COD_LOCALIDADE, P.NOME_PROJETO, EP.COD_EMPREGADO EMPREGADO FROM PROJETO P INNER JOIN EMPREGADO_PROJETO EP  ORDER BY NOME_PROJETO";
        private static String QUERY_SELECT_CODIGO = "SELECT P.COD_PROJETO PROJETO, P.COD_DEPARTAMENTO, P.COD_LOCALIDADE, P.NOME_PROJETO, EP.COD_EMPREGADO EMPREGADO FROM PROJETO P INNER JOIN EMPREGADO_PROJETO EP  WHERE P.COD_PROJETO = ?codProjeto";
        private static String QUERY_SELECT_NOME = "SELECT P.COD_PROJETO PROJETO, P.COD_DEPARTAMENTO, P.COD_LOCALIDADE, P.NOME_PROJETO, EP.COD_EMPREGADO EMPREGADO FROM PROJETO P INNER JOIN EMPREGADO_PROJETO EP  WHERE P.NOME_PROJETO LIKE ?nomeProjeto";
        private static String QUERY_DELETE = "DELETE FROM PROJETO WHERE COD_PROJETO = ?codProjeto";
        private static String QUERY_MAX_CODIGO = "SELECT MAX(COD_PROJETO) MAXCOD FROM PROJETO";

        #endregion

        #region Sql da tabela EMPREGADO_PROJETO

        private static String QUERY_INSERT_EMPREGADO_PROJETO = "INSERT INTO EMPREGADO_PROJETO (COD_PROJETO,COD_EMPREGADO) VALUES (?codProjeto,?codEmpregado)";
        private static String QUERY_SELECT_CODIGO_PROJETO = "SELECT * FROM EMPREGADO_PROJETO WHERE COD_PROJETO = ?codProjeto";
        private static String QUERY_DELETE_EMPREGADO_PROJETO = "DELETE FROM EMPREGADO_PROJETO WHERE COD_PROJETO = ?codProjeto AND COD_EMPREGADO = ?codEmpregado";

        #endregion

        #region IRepositorioProjeto - Tabela PROJETO

        public void InserirProjeto(ClassesBasicas.Projeto projeto)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_INSERT, conexao);

                comando.Parameters.AddWithValue("?codDepartamento", projeto.Departamento.Codigo);
                comando.Parameters.AddWithValue("?codLocalidade", projeto.Localidade.Codigo);
                comando.Parameters.AddWithValue("?nomeprojeto", projeto.Nome);

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

        public ClassesBasicas.Projeto ConsultarPorCodigo(int codProjeto)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            Projeto projeto = null;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?codProjeto", codProjeto);
                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows)
                {
                    projeto = this.CriarProjeto(resultado);
                }
                else
                {
                    throw new ObjetoNaoExistente();
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
                UtilBD.FecharConexao(conexao);
            }

            return projeto;
        }

        public ArrayList ConsultarPorNome(string nomeProjeto)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            ArrayList projetos = new ArrayList();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_NOME, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("%" + "?nomeProjeto" + "%", nomeProjeto);

                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        projetos.Add(this.CriarProjeto(resultado));
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
                MessageBox.Show("Nenhum projeto encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }
            return projetos;
        }

        public void RemoverProjeto(int codProjeto)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE, conexao);
                comando.Parameters.AddWithValue("?codProjeto", codProjeto);

                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();

                if (regitrosAfetados == 0)
                {
                    throw new ObjetoNaoExistente();
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
                UtilBD.FecharConexao(conexao);
            }
        }

        public ArrayList ConsultarTodos()
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            ArrayList projetos = new ArrayList();
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
                        projetos.Add(this.CriarProjeto(resultado));
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
                MessageBox.Show("Nenhum projeto encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }

            return projetos;
        }

        public int ObterMaximoCodigo()
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            int codigo = 0;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_MAX_CODIGO, conexao);
                MySqlDataReader resultado;
                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows)
                {
                    codigo = resultado.GetInt32("MAXCOD");
                }
                resultado.Close();
                UtilBD.FecharConexao(conexao);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }

            return codigo;
        }

        #endregion

        #region IRepositorioProjeto - Tabela EMPREGADO_PROJETO

        public void InserirEmpregadoProjeto(ClassesBasicas.Projeto projeto)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            try
            {

                for (int i = 0; i < projeto.Empregados.Count; i++)
                {
                    MySqlCommand comando = new MySqlCommand(QUERY_INSERT_EMPREGADO_PROJETO, conexao);
                    comando.Parameters.AddWithValue("?codProjeto", projeto.Codigo);
                    Empregado empregado = (Empregado)projeto.Empregados[i];
                    comando.Parameters.AddWithValue("?codEmpregado", empregado.Codigo);

                    conexao.Open();
                }
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

        public ArrayList ConsultarPorCodigoProjeto(int codProjeto)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            ArrayList empregados = new ArrayList();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO_PROJETO, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?codProjeto", codProjeto);

                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();

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
                    throw new ObjetoNaoExistente();
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
                UtilBD.FecharConexao(conexao);
            }
            return empregados;
        }

        public void RemoverEmpregadoProjeto(int codProjeto, int codEmpregado)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE_EMPREGADO_PROJETO, conexao);
                comando.Parameters.AddWithValue("?codProjeto", codProjeto);
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
                MessageBox.Show("Nenhum projeto encontrado.");
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

        private Projeto CriarProjeto(MySqlDataReader resultado)
        {
            int codProjeto = resultado.GetInt32("PROJETO");
            int codDepartamento = resultado.GetInt32("COD_DEPARTAMENTO");
            int codLocalidade = resultado.GetInt32("COD_LOCALIDADE");
            int codEmpregado = resultado.GetInt32("EMPREGADO");
            string nome = resultado.GetString("NOME_PROJETO");            

            Departamento departamento = this.repDepartamento.ConsultarPorCodigo(codDepartamento);
            Localidade localidade = this.repLocalidade.ConsultarPorCodigo(codLocalidade);
            ArrayList empregados = this.ConsultarPorCodigoProjeto(codProjeto);

            return new Projeto(codProjeto, nome, departamento, localidade, empregados);

        }
    }
}
