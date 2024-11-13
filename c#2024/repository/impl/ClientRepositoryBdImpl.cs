using Cours.Models;
using MySqlConnector;

namespace Cours.Repository{
    public class ClientRepositoryBdImpl : IClientRepository{
        private static string connectionString = "Server=localhost;Port=3306;Database=gestion_dette;Uid=root;Pwd=";

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Client? FindBySurnam(string surnam)
        {
            throw new NotImplementedException(); Client? client = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
          {
                conn.Open();

                string query = "SELECT * FROM client WHERE surnam = @surnom";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@surnom", surnam);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                        client=new()
                        {
                        Id = reader.GetInt32("id"),
                        Surnom = reader.GetString("surnom"),
                        Telephone = reader.GetString("telephone"),
                        Adresse = reader.GetString("adresse"),
                        };

                    }

                   }
            }
           
        }
         return client;
        }

        public void Insert(Client entity)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO clients (surnom, telephone, adresse, create_at, update_at) VALUES (@surnom, @telephone, @adresse, @createAt, @updateAt)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@surnom", entity.Surnom);
                    cmd.Parameters.AddWithValue("@telephone", entity.Telephone);
                    cmd.Parameters.AddWithValue("@adresse", entity.Adresse);
                    cmd.Parameters.AddWithValue("@createAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Client ajouté!");
                }
            }
        }

       public List<Client> SelectAll()
{
    List<Client> clients = new List<Client>();

    using (MySqlConnection conn = new MySqlConnection(connectionString))
    {
        conn.Open();

        string query = "SELECT * FROM clients";

        using (MySqlCommand cmd = new MySqlCommand(query, conn))
        {
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    clients.Add(new(){
                    Id = reader.GetInt32("id"),
                    Surnom = reader.GetString("surnom"),
                    Telephone = reader.GetString("telephone"),
                    Adresse = reader.GetString("adresse"),
                    });

                   }
            }
        }
    }

    return clients;
}

        public Client? SelectById(int id)
        {
            Client? client = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
          {
                conn.Open();

                string query = "SELECT * FROM client WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                        client=new()
                        {
                        Id = reader.GetInt32("id"),
                        Surnom = reader.GetString("surnom"),
                        Telephone = reader.GetString("telephone"),
                        Adresse = reader.GetString("adresse"),
                        };

                    }

                   }
            }
           
        }
         return client;
    }
        

        public void Update(Client entity)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE client SET surnom=@surnom,SET telephone=@telephone,SET adresse=@adresse,SET update_at=@updateAt WHERE clientid=@id;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", entity.Id);
                    cmd.Parameters.AddWithValue("@surnom", entity.Surnom);
                    cmd.Parameters.AddWithValue("@telephone", entity.Telephone);
                    cmd.Parameters.AddWithValue("@adresse", entity.Adresse);
                     cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);


                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Client  modifié!");
                }
            }
        }
    }
}