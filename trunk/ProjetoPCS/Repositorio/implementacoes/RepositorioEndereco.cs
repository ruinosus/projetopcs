using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using MySql.Data.MySqlClient;
using Util;
using Excecoes;
using ClassesBasicas;
using System.Collections;
using System.Windows.Forms;

namespace Repositorio.implementacoes
{
    public class RepositorioEndereco : IRepositorioEndereco
    {
        #region Sql Tabela ENDERECO

        private static String QUERY_INSERT = "INSERT INTO ENDERECO (LOGRADOURO,BAIRRO,COMPLEMENTO,CEP,NUMERO,UF,CIDADE,PAIS) VALUES (?logradouro,?bairro,?complemento,?cep,?numero,?uf,?cidade,?pais)";
        private static String QUERY_SELECT_CODIGO = "SELECT * FROM ENDERECO WHERE COD_ENDERECO = ?codEndereco";
        private static String QUERY_DELETE = "DELETE FROM ENDERECO WHERE COD_ENDERECO = ?codEndereco";
        private static String QUERY_SELECT_ALL = "SELECT * FROM ENDERECO"; 

        #endregion

        #region IRepositorioEndereco - Tabela ENDERECO

        public void InserirEndereco(ClassesBasicas.Endereco endereco)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_INSERT, conexao);
                comando.Parameters.AddWithValue("?logradouro", endereco.Logradouro);
                comando.Parameters.AddWithValue("?bairro", endereco.Bairro);
                comando.Parameters.AddWithValue("?complemento", endereco.Complemento);
                comando.Parameters.AddWithValue("?cep", endereco.Cep);
                comando.Parameters.AddWithValue("?numero", endereco.Numero);
                comando.Parameters.AddWithValue("?uf", endereco.Uf);
                comando.Parameters.AddWithValue("?cidade", endereco.Cidade);
                comando.Parameters.AddWithValue("?pais", endereco.Pais);

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

        public ClassesBasicas.Endereco ConsultarPorCodigo(int codEndereco)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            Endereco endereco = null;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?codEndereco", codEndereco);
                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows)
                {
                    endereco = this.CriarEndereco(resultado);
                }
                else
                {
                  //  throw new ObjetoNaoExistente();
                }
                resultado.Close();
            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum endereço encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }

            return endereco;
        }

        public void RemoverEndereco(int codEndereco)
        {
            MySqlConnection conexao = UtilBD.ObterConexao();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE, conexao);
                comando.Parameters.AddWithValue("?codEndereco", codEndereco);

                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();

                if (regitrosAfetados == 0)
                {
                   // throw new ObjetoNaoExistente();
                }

            }
            catch (ObjetoNaoExistente e)
            {
                MessageBox.Show("Nenhum endereço encontrado.");
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
            ArrayList enderecos = new ArrayList();
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
                        enderecos.Add(this.CriarEndereco(resultado));
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
                MessageBox.Show("Nenhum endereço encontrado.");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                UtilBD.FecharConexao(conexao);
            }

            return enderecos;
        }

        #endregion

        private Endereco CriarEndereco(MySqlDataReader resultado)
        {
            int codEndereco = resultado.GetInt32("COD_ENDERECO");
            string logradouro = resultado.GetString("LOGRADOURO");
            string bairro = resultado.GetString("BAIRRO");
            string complemento = resultado.GetString("COMPLEMENTO");
            int cep = resultado.GetInt32("CEP");
            string numero = resultado.GetString("NUMERO");
            string uf = resultado.GetString("UF");
            string cidade = resultado.GetString("CIDADE");
            string pais = resultado.GetString("PAIS");
            return new Endereco(codEndereco,logradouro,bairro,complemento,cep,numero,uf,cidade,pais);       
        }
    }
}
