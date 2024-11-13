using Cours.Core;
using Cours.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Cours.Repository
{
    public class ClientRepositoryDapperImpl : IClientRepository
    {
        private readonly IDataAcess dataAcess;

        public ClientRepositoryDapperImpl(IDataAcess dataAcess)
        {
            this.dataAcess = dataAcess;
        }

        public void Delete(int id)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "DELETE FROM client WHERE id = @id;";
                conn.Execute(query, new { id });
                Console.WriteLine("Client deleted successfully.");
            }
        }

        public Client? FindBySurnam(string surnam)
        {
           using (var conn = dataAcess.getConnection())
            {
                string query = "SELECT * FROM client WHERE surname = @surname";
                var client = conn.QueryFirstOrDefault<Client>(query, new { surnam });
                return client;
            }
        }

       

        public void Insert(Client entity)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "INSERT INTO client (surname, telephone, adresse, create_at, update_at) " +
                               "VALUES (@surnom, @telephone, @adresse, @createAt, @updateAt);";
                var parameters = new 
                {
                    surnom = entity.Surnom,
                    telephone = entity.Telephone,
                    adresse = entity.Adresse,
                    createAt = DateTime.Now,
                    updateAt = DateTime.Now
                };
                conn.Execute(query, parameters);
                entity.Id = conn.QuerySingle<int>("SELECT LAST_INSERT_ID();");
                Console.WriteLine("Client added successfully.");
            }
        }

        public List<Client> SelectAll()
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "SELECT * FROM client";
                var clients = conn.Query<Client>(query).AsList();
                return clients;
            }
        }

        public Client? SelectById(int id)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "SELECT * FROM client WHERE id = @id";
                var client = conn.QueryFirstOrDefault<Client>(query, new { id });
                return client;
            }
        }

        public void Update(Client entity)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "UPDATE client SET adresse = @adresse, surname = @surname, telephone = @telephone WHERE id = @id;";
                var parameters = new 
                {
                    id = entity.Id,
                    surname = entity.Surnom,
                    telephone = entity.Telephone,
                    adresse = entity.Adresse
                };
                conn.Execute(query, parameters);
                Console.WriteLine("Client updated successfully.");
            }
        }
    }
}
