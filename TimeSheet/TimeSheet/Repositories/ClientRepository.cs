using System;
using System.Collections.Generic;
using TimeSheet.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace TimeSheet.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=timesheet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void AddClient(Client client)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspAddClient", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@name", client.Name);
            command.Parameters.AddWithValue("@address", client.Address);
            command.Parameters.AddWithValue("@city", client.City);
            command.Parameters.AddWithValue("@zip", client.Zip);
            command.Parameters.AddWithValue("@country", client.CountryID);
            command.ExecuteNonQuery();
        }

        public void DeleteClientLogically(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspDeleteClientLogically", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public void DeleteClientPhysically(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspDeleteClientPhysically", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public IEnumerable<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspGetAllClients", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Client client = new Client()
                {
                    ID = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString(),
                    Address = reader["address"].ToString(),
                    City = reader["city"].ToString(),
                    Zip = reader["zip"].ToString(),
                    CountryID = Convert.ToInt32(reader["countryID"]),
                    IsDeleted = Convert.ToBoolean(reader["isDeleted"])
                };
                clients.Add(client);
            }
            return clients;
        }

        public Client GetClientById(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspGetClientById", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Client client = new Client();
            while (reader.Read())
            {
                client.ID = Convert.ToInt32(reader["id"]);
                client.Name = reader["name"].ToString();
                client.Address = reader["address"].ToString();
                client.City = reader["city"].ToString();
                client.Zip = reader["zip"].ToString();
                client.CountryID = Convert.ToInt32(reader["countryID"]);
                client.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
            }
            return client;
        }
        
        public IEnumerable<string> GetClientsFirstLetters()
        {
            List<string> letters = new List<string>();
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("uspGetClientsFirstLetters", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                letters.Add(reader["letter"].ToString());
            }
            return letters;
        }
        
        public IEnumerable<Client> SearchClients(string name)
        {
            List<Client> clients = new List<Client>();
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspSearchClients", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@name", name);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Client client = new Client()
                {
                    ID = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString(),
                    Address = reader["address"].ToString(),
                    City = reader["city"].ToString(),
                    Zip = reader["zip"].ToString(),
                    CountryID = Convert.ToInt32(reader["countryID"]),
                    IsDeleted = Convert.ToBoolean(reader["isDeleted"])
                };
                clients.Add(client);
            }
            return clients;
        }

        public void UpdateClient(Client client)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspUpdateClient", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@name", client.Name);
            command.Parameters.AddWithValue("@address", client.Address);
            command.Parameters.AddWithValue("@city", client.City);
            command.Parameters.AddWithValue("@zip", client.Zip);
            command.Parameters.AddWithValue("@country", client.CountryID);
            command.Parameters.AddWithValue("@id", client.ID);
            command.ExecuteNonQuery();
        }

        public Client GetClientByNameAndAddress(string name, string address)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("dbo.uspGetClientByNameAndAddress", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@address", address);
            SqlDataReader reader = command.ExecuteReader();
            Client client = new Client();
            while (reader.Read())
            {
                client.ID = Convert.ToInt32(reader["id"]);
                client.Name = reader["name"].ToString();
                client.Address = reader["address"].ToString();
                client.City = reader["city"].ToString();
                client.Zip = reader["zip"].ToString();
                client.CountryID = Convert.ToInt32(reader["countryID"]);
                client.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
            }
            return client;
        }
    }
}
