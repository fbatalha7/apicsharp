using apicsharp.Models;
using Npgsql;
using System.ComponentModel;
using System.Configuration;

namespace apicsharp.Controllers
{
    public class ClientDB
    {

        private const string GetAllClients = "select * from clients order by id asc";
        private const string SqlDelete = "delete from clients where id = :p_id";
        private const string SqlUpdate = "update clients set nome = ':p_nome' where id = :p_id";
        public static List<Clients> GetClients()
        {
            List<Clients> clients = new List<Clients>();
            try
            {

                NpgsqlCommand cmd = new NpgsqlCommand(GetAllClients, Connection.GetConnection());
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Int32 id = (Int32)dr["id"];
                    string name = (String)dr["nome"];

                    var cl = new Clients()
                    {
                        Id = id,
                        Nome = name,
                    };

                    clients.Add(cl);

                }


            }
            catch (Exception e)
            {

                throw new Exception("Erro 'GETCLIENTS' >> " + e.Message);
            }

            return clients;
        }

        public static void DeleteClient(string id)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(SqlDelete.Replace(string.Format(":p_{0}", nameof(id)), id), Connection.GetConnection());
                var dr = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Deletar Dados >>" + ex.Message);
            }


        }

        public static void UpdateClient(Clients obj)
        {
            var sql = string.Empty;
            sql = SqlUpdate.Replace(string.Format(":p_{0}", nameof(obj.Id).ToLower()), obj.Id.ToString());
            sql = SqlUpdate.Replace(string.Format(":p_{0}", nameof(obj.Nome).ToLower()), obj.Nome);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection.GetConnection());
            var dr = cmd.ExecuteNonQuery();

        }


    }
}
