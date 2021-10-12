using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace APICEP.DAO
{
    class DAOUtils
    {

        public static DbConnection GetConexao()
        {
            string server = ConfigurationManager.AppSettings["server"].ToString();
            string database = ConfigurationManager.AppSettings["database"].ToString();
            string user = ConfigurationManager.AppSettings["user"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();

            DbConnection conexao = null;
            string connectionString = "";

            if (ConfigurationManager.AppSettings["server"].ToString().Equals("MSSQL"))
            {
                connectionString = @"Server=" + server + "; Database=" + database + "; Uid=" + user + "; Pwd=" + password + ";;Encrypt=true;";
                conexao = new SqlConnection(connectionString);
            }
            else
            {
                connectionString = @"Server=" + server + "; Database=" + database + "; Uid=" + user + "; Pwd=" + password + ";";
                conexao = new MySqlConnection(connectionString);
            }
            conexao.Open();
            return conexao;
        }

        public static DbCommand GetComando(DbConnection conexao)
        {
            DbCommand comando = conexao.CreateCommand();
            return comando;
        }

        public static DbDataReader GetDataReader(DbCommand comando)
        {
            return comando.ExecuteReader();
        }

        public static DbParameter GetParameter(string nome, object valor)
        {
            DbParameter parametro = null;

            if (ConfigurationManager.AppSettings["server"].ToString().Equals("MSSQL"))
            {
                parametro = new SqlParameter(nome, valor);
            }
            else
            {
                parametro = new MySqlParameter(nome, valor);
            }

            return parametro;
        }

    }
}
