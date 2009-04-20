using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using MySql.Data.MySqlClient;
using Util;
using System.Windows.Forms;
using ClassesBasicas;

namespace Repositorio.implementacoes
{
    public class RepositorioEmpregado : IRepositorioEmpregado
    {
        private IRepositorioDependente repDependente = new RepositorioDependente();

        private static String QUERY_INSERT = "INSERT INTO EMPREGADO (COD_ENDERECO,NOME_EMPREGADO,SALARIO,CPF,DATA_NASCIMENTO,RG,SEXO,TELEFONE) VALUES (?codEndereco,?nomeEmpregado,?salario,?cpf,?dataNascimento,?rg,?sexo,?telefone)";
        private static String QUERY_INSERT_SUPERVISOR = "INSERT INTO EMPREGADO (COD_EMPREGADO_SUPERVISOR,COD_ENDERECO,NOME_EMPREGADO,SALARIO,CPF,DATA_NASCIMENTO,RG,SEXO,TELEFONE) VALUES (?codEmpregadoSupervisor,?codEndereco,?nomeEmpregado,?salario,?cpf,?dataNascimento,?rg,?sexo,?telefone)";
        private static String QUERY_SELECT_ALL = "SELECT * FROM EMPREGADO ORDER BY NOME_EMPREGADO";
        private static String QUERY_SELECT_CODIGO = "SELECT * FROM EMPREGADO WHERE COD_EMPREGADO = ?codEmpregado";
        private static String QUERY_SELECT_NOME = "SELECT * FROM EMPREGADO WHERE NOME_EMPREGADO LIKE ?nomeEmpregado ORDER BY NOME_EMPREGADO" ;
        private static String QUERY_DELETE = "DELETE FROM EMPREGADO WHERE COD_EMPREGADO = ?codEmpregado";


        #region IRepositorioEmpregado Members

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
            throw new NotImplementedException();
        }

        public System.Collections.ArrayList ConsultarPorNome(string nomeEmpregado)
        {
            throw new NotImplementedException();
        }

        public void RemoverEmpregado(int codEmpregado)
        {
            throw new NotImplementedException();
        }

        public System.Collections.ArrayList ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        #endregion

        private Empregado CriarEmpregado(MySqlDataReader resultado)
        {
            int codDependente = resultado.GetInt32("COD_DEPENDENTE");
            string nome = resultado.GetString("NOME_DEPENDENTE");
            string grauParentesco = resultado.GetString("GRAU_PARENTESCO");
            DateTime dataNascimento = resultado.GetDateTime("DATA_NASCIMENTO");
            char sexo = resultado.GetChar("SEXO");

            return new Dependente(codDependente, nome, dataNascimento, sexo, grauParentesco);
        }
    }
}
