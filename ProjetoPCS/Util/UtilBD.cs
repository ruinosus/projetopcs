using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Excecoes;

namespace Util
{
    public class UtilBD
    {
       
        private static  string conexao = "uid=root; password=12345678; database=projetopcs";
        private  MySqlConnection ConexaoSQL = new MySqlConnection(conexao);

        public  MySqlConnection ObterConexao()
        {
            try
            {
                return ConexaoSQL;
            }
            catch (MySqlException e)
            {
                throw new ErroBanco(e.Message);
            }
        }

        public  void FecharConexao(MySqlConnection con)
        {
            if (con != null)
            {
                try
                {
                    con.Close();
                }
                catch (MySqlException e)
                {
                    throw new ErroBanco(e.Message);
                }
            }
        }

    }
}
