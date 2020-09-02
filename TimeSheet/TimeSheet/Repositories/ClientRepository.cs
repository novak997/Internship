using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Context;

namespace TimeSheet.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DatabaseContext _context;
        public ClientRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void AddClient(Client client)
        {
            _context.Database.ExecuteSqlRaw("exec uspAddClient {0}, {1}, {2}, {3}, {4}", client.Name,
                client.Address, client.City, client.Zip, client.CountryID);
        }

        public void DeleteClientLogically(int id)
        {
            _context.Database.ExecuteSqlRaw("exec uspDeleteClientLogically {0}", id);
        }

        public void DeleteClientPhysically(int id)
        {
            _context.Database.ExecuteSqlRaw("exec uspDeleteClientPhysically {0}", id);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients.FromSqlRaw("exec uspGetAllClients").ToList();
        }

        public Client GetClientById(int id)
        {
            return _context.Clients.FromSqlRaw("exec uspGetClientById {0}", id).FirstOrDefault();
        }
        /*
        public IEnumerable<string> GetClientsFirstLetters()
        {
            List<string> letters = new List<string>();
            using SqlConnection connection = new SqlConnection(_connection);
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
        */
        public IEnumerable<Client> SearchClients(string name)
        {
            return _context.Clients.FromSqlRaw("exec uspSearchClients {0}", name).ToList();
        }

        public void UpdateClient(Client client)
        {
            _context.Database.ExecuteSqlRaw("exec uspUpdateClient {0}, {1}, {2}, {3}, {4}, {5}", client.Name,
                client.Address, client.City, client.Zip, client.CountryID, client.ID);
        }
    }
}
