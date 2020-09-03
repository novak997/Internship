using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;
using TimeSheet.Repositories;

namespace TimeSheet.Services
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository = new ClientRepository();
        public string AddClient(Client client)
        {
            if (_clientRepository.GetClientByNameAndAddress(client.Name, client.Address).Name != null)
            {
                return "A client with that name and address already exists";
            }
            _clientRepository.AddClient(client);
            return "Client successfully added";
        }
        public IEnumerable<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }
        public Client GetClientById(int id)
        {
            return _clientRepository.GetClientById(id);
        }
        public string UpdateClient(Client client)
        {
            if (_clientRepository.GetClientByNameAndAddress(client.Name, client.Address).Name != null)
            {
                return "A client with that name and address already exists";
            }
            _clientRepository.UpdateClient(client);
            return "Client successfully updated";
        }
        public void DeleteClientLogically(int id)
        {
            _clientRepository.DeleteClientLogically(id);
        }
        public IEnumerable<Client> SearchClients(string name)
        {
            return _clientRepository.SearchClients(name);
        }
        public IEnumerable<string> GetClientsFirstLetters()
        {
            return _clientRepository.GetClientsFirstLetters();
        }
    }
}
