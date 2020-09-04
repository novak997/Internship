using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Exceptions;

namespace TimeSheet.DAL.SQLClient.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IConfiguration _configuration;

        public ClientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int AddClient(Client client)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
                command.Parameters.Add("@newId", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                return (Convert.ToInt32(command.Parameters["@newId"].Value));
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public void DeleteClientLogically(int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspDeleteClientLogically", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public void DeleteClientPhysically(int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
                SqlCommand command = new SqlCommand("dbo.uspDeleteClientPhysically", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public IEnumerable<Client> GetAllClients()
        {
            try
            {
                List<Client> clients = new List<Client>();
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public Client GetClientById(int id)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }
        
        public IEnumerable<string> GetClientsFirstLetters()
        {
            try
            {
                List<string> letters = new List<string>();
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }
        
        public IEnumerable<Client> SearchClients(string name)
        {
            try
            {
                List<Client> clients = new List<Client>();
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public void UpdateClient(Client client)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }

        public Client GetClientByNameAndAddress(string name, string address)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Database"));
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
            catch (SqlException)
            {
                throw new DatabaseException("A database related exception has occurred");
            }
            
        }
    }
}
