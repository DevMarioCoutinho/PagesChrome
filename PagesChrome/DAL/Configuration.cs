using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace PagesChrome.DAL
{
    class Configuration
    {
        #region Coletando Dados para Popular Objeto do tipo Usuario
        public DataSet getDados(int Acesso)
        {
            //conexão com banco de dados
            SqlConnection conexao = new SqlConnection(Properties.Settings.Default.Conn.ToString());
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            comando.Connection = conexao;
            comando.CommandText = "SELECT LoginUser, LoginSenha, PagesUrl FROM Login WITH(NOLOCK)" +
                                  "INNER JOIN Pages WITH(NOLOCK) ON (LoginCodigo = PagesCodLogin)" +
                                  "WHERE PagesCodigo = @ACESSO";
            comando.Parameters.Add("@ACESSO", SqlDbType.Int).Value = Acesso;
            comando.CommandTimeout = 3000;

            //popula a variavel do tipo Dataset com retorno do select
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();
            return ds;
        }
        #endregion
    }
}
