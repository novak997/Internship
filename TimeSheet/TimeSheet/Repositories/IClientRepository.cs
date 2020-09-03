using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Repositories
{
    interface IClientRepository
    {
        public void AddClient(Client client);
        public IEnumerable<Client> GetAllClients();
        public Client GetClientById(int id);
        public void UpdateClient(Client client);
        public void DeleteClientPhysically(int id);
        public void DeleteClientLogically(int id);
        public IEnumerable<Client> SearchClients(string name);
        //public IEnumerable<string> GetClientsFirstLetters();
    }
}
