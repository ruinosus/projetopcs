using System;
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
using System.Data;

namespace Repositorio.implementacoes
{
    public class RepositorioEmpregado : IRepositorioEmpregado
    {
        private IRepositorioEndereco repEndereco = new RepositorioEndereco();
        private IRepositorioDepartamento repDepartamento = new RepositorioDepartamento();

        //private static String QUERY_SELECT_PADRAO = "SELECT E.COD_EMPREGADO CODIGO, E.COD_EMPREGADO_SUPERVISOR SUPERVISOR, E.COD_ENDERECO ENDERECO, E.NOME_EMPREGADO NOME, E.SALARIO, E.CPF, E.DATA_NASCIMENTO, E.RG, E.SEXO, E.TELEFONE, A.COD_DEPARTAMENTO ALOCADO, A.DATA_ALOCACAO DATA_ALOCACAO, C.COD_DEPARTAMENTO CHEFIADO, C.DATA_INICIO DATA_INICIO, C.DATA_FINAL DATA_FINAL  FROM EMPREGADO E INNER JOIN CHEFIAR C  ON C.COD_EMPREGADO = E.COD_EMPREGADO INNER JOIN ALOCAR A ON A.COD_EMPREGADO= E.COD_EMPREGADO WHERE E.COD_EMPREGADO IN (?codEmpregado) ";
   
        #region Sql da tabela EMPREGADO

        private static String QUERY_INSERT_1 = "INSERT INTO EMPREGADO (COD_ENDERECO,NOME_EMPREGADO,SALARIO,CPF,DATA_NASCIMENTO,RG,SEXO,TELEFONE) VALUES (?codEndereco,?nomeEmpregado,?salario,?cpf,?dataNascimento,?rg,?sexo,?telefone)";
        private static String QUERY_INSERT_2 = "INSERT INTO EMPREGADO (COD_EMPREGADO_SUPERVISOR,COD_ENDERECO,NOME_EMPREGADO,SALARIO,CPF,DATA_NASCIMENTO,RG,SEXO,TELEFONE) VALUES (?codEmpregadoSupervisor,?codEndereco,?nomeEmpregado,?salario,?cpf,?dataNascimento,?rg,?sexo,?telefone)";
        private static String QUERY_UPDATE_1 = "UPDATE EMPREGADO SET COD_ENDERECO = ?codEndereco ,NOME_EMPREGADO = ?nomeEmpregado, SALARIO = ?salario, CPF = ?cpf, DATA_NASCIMENTO = ?dataNascimento, RG = ?rg, SEXO = ?sexo, TELEFONE =?telefone WHERE COD_EMPREGADO = ?codEmpregado ";
        private static String QUERY_UPDATE_2 = "UPDATE EMPREGADO SET COD_EMPREGADO_SUPERVISOR = ?codEmpregadoSupervisor ,COD_ENDERECO = ?codEndereco ,NOME_EMPREGADO = ?nomeEmpregado, SALARIO = ?salario, CPF = ?cpf, DATA_NASCIMENTO = ?dataNascimento, RG = ?rg, SEXO = ?sexo, TELEFONE =?telefone WHERE COD_EMPREGADO = ?codEmpregado "; 
        private static String QUERY_SELECT_ALL = "SELECT * FROM EMPREGADO ORDER BY NOME_EMPREGADO";
        private static String QUERY_SELECT_CODIGO = "SELECT * FROM EMPREGADO WHERE COD_EMPREGADO = ?codEmpregado";
        private static String QUERY_SELECT_NOME = "SELECT * FROM EMPREGADO  WHERE NOME_EMPREGADO LIKE ?nomeEmpregado ORDER BY NOME_EMPREGADO";
        private static String QUERY_DELETE = "DELETE FROM EMPREGADO WHERE COD_EMPREGADO = ?codEmpregado";
        private static String QUERY_MAX_CODIGO = "SELECT MAX(COD_EMPREGADO) MAXCOD FROM EMPREGADO";

        #endregion

        #region Sql da tabela CHEFIAR

        private static String QUERY_INSERT_CHEFIAR = "INSERT INTO CHEFIAR (COD_EMPREGADO,COD_DEPARTAMENTO,DATA_INICIO,DATA_FINAL) VALUES (?codEmpregado,?codDepartamento,?dataInicio,?dataFinal)";
        private static String QUERY_UPDATE_CHEFIAR = "UPDATE CHEFIAR SET COD_DEPARTAMENTO = ?codDepartamento, DATA_INICIO = ?dataInicio, DATA_FINAL = ?dataFinal WHERE COD_EMPREGADO = ?codEmpregado"; 
        private static String QUERY_SELECT_CODIGO_EMPREGADO_CHEFIAR = "SELECT * FROM CHEFIAR WHERE COD_EMPREGADO = ?codEmpregado";
        private static String QUERY_DELETE_CHEFIAR = "DELETE FROM CHEFIAR WHERE COD_EMPREGADO = ?codEmpregado";
 
        #endregion

        #region Sql da tabela ALOCAR

        private static String QUERY_INSERT_ALOCAR = "INSERT INTO ALOCAR (COD_EMPREGADO,COD_DEPARTAMENTO,DATA_ALOCACAO) VALUES (?codEmpregado,?codDepartamento,?dataAlocacao)";
        private static String QUERY_UPDATE_ALOCAR = "UPDATE ALOCAR SET COD_DEPARTAMENTO = ?codDepartamento, DATA_ALOCACAO = ?dataAlocacao WHERE COD_EMPREGADO = ?codEmpregado";  
        private static String QUERY_SELECT_CODIGO_EMPREGADO_ALOCAR = "SELECT * FROM ALOCAR WHERE COD_EMPREGADO = ?codEmpregado";
        private static String QUERY_DELETE_ALOCAR = "DELETE FROM ALOCAR WHERE COD_EMPREGADO = ?codEmpregado";

        #endregion
       
        #region IRepositorioEmpregado - Tabela EMPREGADO

        public void InserirEmpregado(ClassesBasicas.Empregado empregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando;

                if (empregado.Supervisor == null)
                {
                     comando = new MySqlCommand(QUERY_INSERT_1, conexao);
                }
                else
                {
                     comando = new MySqlCommand(QUERY_INSERT_2, conexao);
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

        public void AlterarEmpregado(ClassesBasicas.Empregado empregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando;

                if (empregado.Supervisor == null)
                {
                    comando = new MySqlCommand(QUERY_UPDATE_1, conexao);
                }
                else
                {
                    comando = new MySqlCommand(QUERY_UPDATE_2, conexao);
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
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
        }

        public Empregado ConsultarPorCodigo(int codEmpregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            Empregado empregado = null;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO, conexao);

                MySqlDataReader resultado;
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

                resultado = comando.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows)
                {
                    empregado = this.CriarEmpregado(resultado);
                }
                else
                {
                   // throw new ObjetoNaoExistente();
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
                banco.FecharConexao(conexao);
            }

            return empregado;
        }

        public ArrayList ConsultarPorNome(string nomeEmpregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            ArrayList empregados = new ArrayList();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_NOME, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?nomeEmpregado","%" +  nomeEmpregado+ "%");

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
                        empregados.Add(this.CriarEmpregado(resultado));
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
                MessageBox.Show("Nenhum empregado encontrado.");
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

        public void RemoverEmpregado(int codEmpregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE, conexao);
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
                MessageBox.Show("Nenhum empregado encontrado.");
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

            ArrayList empregados = new ArrayList();
            
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

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        empregados.Add(this.CriarEmpregado(resultado));                       
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
                MessageBox.Show("Nenhum empregado encontrado.");
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

        #region IRepositorioEmpregado - Tabela CHEFIAR

        public void InserirChefiar(Empregado empregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_INSERT_CHEFIAR, conexao);

                comando.Parameters.AddWithValue("?codEmpregado", empregado.Codigo);
                comando.Parameters.AddWithValue("?codDepartamento", empregado.DepartamentoChefiado.Codigo);
                comando.Parameters.AddWithValue("?dataInicio", empregado.DataInicio);
                comando.Parameters.AddWithValue("?dataFinal", empregado.DataFinal);

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

        public void AlterarChefiar(Empregado empregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_UPDATE_CHEFIAR, conexao);

                comando.Parameters.AddWithValue("?codEmpregado", empregado.Codigo);
                comando.Parameters.AddWithValue("?codDepartamento", empregado.DepartamentoChefiado.Codigo);
                comando.Parameters.AddWithValue("?dataInicio", empregado.DataInicio);
                comando.Parameters.AddWithValue("?dataFinal", empregado.DataFinal);
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
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
        }

        public Empregado ConsultarPorCodigoEmpregadoChefiar(Empregado empregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            Empregado emp = empregado;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO_EMPREGADO_CHEFIAR, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?codEmpregado", emp.Codigo);
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
                    int codDepartamento = resultado.GetInt32("COD_DEPARTAMENTO");
                    DateTime dataInicio = resultado.GetDateTime("DATA_INICIO");
                    DateTime dataFinal = resultado.GetDateTime("DATA_FINAL");
                    Departamento departamento = this.repDepartamento.ConsultarPorCodigo(codDepartamento);
                    
                    emp.DepartamentoChefiado = departamento;
                    emp.DataInicio = dataInicio;
                    emp.DataFinal = dataFinal;
                }
                else
                {
                   // throw new ObjetoNaoExistente();
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
                banco.FecharConexao(conexao);
            }

            return emp;
        }

        public void RemoverChefiar(int codEmpregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE_CHEFIAR, conexao);
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
                  //  throw new ObjetoNaoExistente();
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
                banco.FecharConexao(conexao);
            }
        }

        #endregion

        #region IRepositorioEmpregado - Tabela ALOCAR

        public void InserirAlocar(Empregado empregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_INSERT_ALOCAR, conexao);

                comando.Parameters.AddWithValue("?codEmpregado", empregado.Codigo);
                comando.Parameters.AddWithValue("?codDepartamento", empregado.DepartamentoAlocado.Codigo);
                comando.Parameters.AddWithValue("?dataAlocacao", empregado.DataAlocação);

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

        public void AlterarAlocar(Empregado empregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_UPDATE_ALOCAR, conexao);

                comando.Parameters.AddWithValue("?codEmpregado", empregado.Codigo);
                comando.Parameters.AddWithValue("?codDepartamento", empregado.DepartamentoAlocado.Codigo);
                comando.Parameters.AddWithValue("?dataAlocacao", empregado.DataAlocação);

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

        public Empregado ConsultarPorCodigoEmpregadoAlocar(Empregado empregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();

            Empregado emp = empregado;
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_SELECT_CODIGO_EMPREGADO_ALOCAR, conexao);

                MySqlDataReader resultado;
                comando.Parameters.AddWithValue("?codEmpregado", emp.Codigo);
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
                    int codDepartamento = resultado.GetInt32("COD_DEPARTAMENTO");
                    DateTime dataAlocacao = resultado.GetDateTime("DATA_ALOCACAO");
                    Departamento departamento = this.repDepartamento.ConsultarPorCodigo(codDepartamento);

                    emp.DepartamentoAlocado = departamento;
                    emp.DataAlocação = dataAlocacao;
                }
                else
                {
                   // throw new ObjetoNaoExistente();
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
                banco.FecharConexao(conexao);
            }

            return emp;
        }

        public void RemoverAlocar(int codEmpregado)
        {
            UtilBD banco = new UtilBD();
            MySqlConnection conexao = banco.ObterConexao();
            try
            {
                MySqlCommand comando = new MySqlCommand(QUERY_DELETE_ALOCAR, conexao);
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
                  //  throw new ObjetoNaoExistente();
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
                banco.FecharConexao(conexao);
            }
        } 
        #endregion

        private Empregado CriarEmpregado(MySqlDataReader resultado)
        {
            Empregado empregado = new Empregado();

            int codEmpregado = resultado.GetInt32("COD_EMPREGADO");
            int codEmpregadoSupervisor;

            try
            {
                codEmpregadoSupervisor = resultado.GetInt32("COD_EMPREGADO_SUPERVISOR");
            }
            catch (Exception)
            {
                codEmpregadoSupervisor = 0;
            }

            int codEndereco = resultado.GetInt32("COD_ENDERECO");
            string cpf = resultado.GetString("CPF");
            string rg = resultado.GetString("RG");
            string telefone = resultado.GetString("TELEFONE");
            string nome = resultado.GetString("NOME_EMPREGADO");
            double salario = resultado.GetDouble("SALARIO");
            char sexo = resultado.GetChar("SEXO");
            DateTime dataNascimento = resultado.GetDateTime("DATA_NASCIMENTO");

            empregado.Codigo = codEmpregado;
            empregado.Cpf = cpf;
            empregado.DataNascimento = dataNascimento;
            empregado.Nome = nome;
            empregado.Rg = rg;
            empregado.Salario = salario;
            empregado.Sexo = sexo;
            empregado.Telefone = telefone;           

            if (codEmpregadoSupervisor != 0)
            {
                empregado.Supervisor = this.ConsultarPorCodigo(codEmpregadoSupervisor);
            }

            empregado.Endereco = this.repEndereco.ConsultarPorCodigo(codEndereco);

            empregado = this.ConsultarPorCodigoEmpregadoAlocar(empregado);
            empregado = this.ConsultarPorCodigoEmpregadoChefiar(empregado);

            return empregado;

        }
    }
}
