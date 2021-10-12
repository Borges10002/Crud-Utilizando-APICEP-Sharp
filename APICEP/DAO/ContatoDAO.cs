using APICEP.Classes;
using System;
using System.Data;
using System.Data.Common;

namespace APICEP.DAO
{
    public class ContatoDAO
    {
        public DataTable GetContatos()
        {
            try
            {
                DbConnection conexao = DAOUtils.GetConexao();
                DbCommand comando = DAOUtils.GetComando(conexao);
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT ID, NOME, EMAIL, TELEFONE, CEP, RUA, CIDADE, BAIRRO, ESTADO FROM CONTATOS ";

                DbDataReader reader = DAOUtils.GetDataReader(comando);
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                return dataTable;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
           

        }

        public void Excluir(int id)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM CONTATOS WHERE ID = @id";
            //   comando.Parameters.Add(new SqlParameter("@id", id));
            comando.Parameters.Add(DAOUtils.GetParameter("@id", id));
            comando.ExecuteNonQuery();
        }

        public void Inserir(Contato contato)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO CONTATOS(NOME, EMAIL, TELEFONE, CEP, RUA, CIDADE, BAIRRO, ESTADO) VALUES(@nome, @email, @telefone, @cep, @rua, @cidade, @bairro, @estado)";
            comando.Parameters.Add(DAOUtils.GetParameter("@nome", contato.Nome));
            comando.Parameters.Add(DAOUtils.GetParameter("@email", contato.Email));
            comando.Parameters.Add(DAOUtils.GetParameter("@telefone", contato.Telefone));

            comando.Parameters.Add(DAOUtils.GetParameter("@cep", contato.Cep));
            comando.Parameters.Add(DAOUtils.GetParameter("@rua", contato.Rua));
            comando.Parameters.Add(DAOUtils.GetParameter("@cidade", contato.Cidade));
            comando.Parameters.Add(DAOUtils.GetParameter("@bairro", contato.Bairro));
            comando.Parameters.Add(DAOUtils.GetParameter("@estado", contato.Estado));

            comando.ExecuteNonQuery();

        }


        public void Atualizar(Contato contato)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE CONTATOS SET NOME = @nome, EMAIL = @email, TELEFONE = @telefone, CEP = @cep, RUA = @rua, CIDADE = @cidade, BAIRRO = @bairro, ESTADO = @estado WHERE ID = @id";
            comando.Parameters.Add(DAOUtils.GetParameter("@nome", contato.Nome));
            comando.Parameters.Add(DAOUtils.GetParameter("@email", contato.Email));
            comando.Parameters.Add(DAOUtils.GetParameter("@telefone", contato.Telefone));
            comando.Parameters.Add(DAOUtils.GetParameter("@id", contato.Id));

            comando.Parameters.Add(DAOUtils.GetParameter("@cep", contato.Cep));
            comando.Parameters.Add(DAOUtils.GetParameter("@rua", contato.Rua));
            comando.Parameters.Add(DAOUtils.GetParameter("@cidade", contato.Cidade));
            comando.Parameters.Add(DAOUtils.GetParameter("@bairro", contato.Bairro));
            comando.Parameters.Add(DAOUtils.GetParameter("@estado", contato.Estado));

            comando.ExecuteNonQuery();

        }

        public string ContarUsuarios()
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT COUNT(*) FROM CONTATOS";
            return comando.ExecuteScalar().ToString();
        }
    }
}
