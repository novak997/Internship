using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Repositories;

namespace TimeSheet.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly ClientRepository _clientRepository = new ClientRepository();
        public string AddClient(Client client)
        {
            if (client.Name == "" || client.Name == null || client.Address == "" || client.Address == null || client.City == "" || client.City == null || client.Zip == "" || client.Zip == null)
            {
                return "Client name, address, city and zip cannot be empty";
            }
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
            if (client.Name == "" || client.Name == null || client.Address == "" || client.Address == null || client.City == "" || client.City == null || client.Zip == "" || client.Zip == null)
            {
                return "Client name, address, city and zip cannot be empty";
            }
            if (_clientRepository.GetClientByNameAndAddress(client.Name, client.Address).Name != null)
            {
                return "A client with that name and address already exists";
            }
            _clientRepository.UpdateClient(client);
            return "Client successfully updated";
        }
        public string DeleteClientLogically(int id)
        {
            _clientRepository.DeleteClientLogically(id);
            return "Client successfully deleted";
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
