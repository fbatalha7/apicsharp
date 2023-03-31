using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Npgsql;

namespace apicsharp.Controllers
{
    public class Connection
    {

        public static NpgsqlConnection GetConnection()
        {

            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=123;Database=empresax;Pooling=true;");
                conexao.Open();
            }
            catch (Exception e)
            {

                throw new Exception("Erro ao Inciar a conexão com o BD: " + e.Message);
            }


            return conexao;

        }

        public static void ExitConnection(NpgsqlConnection con)
        {
            if (con != null)
            {
                try
                {
                    con.Close();

                }
                catch (Exception ex)
                {

                    throw new Exception("Erro Ao Encerrar a Conexao >> " + ex.Message);
                }

            }


        }

    }
}
