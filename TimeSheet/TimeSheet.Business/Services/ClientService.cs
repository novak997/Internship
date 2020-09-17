using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.Business.Exceptions;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Exceptions;
using TimeSheet.DAL.SQLClient.Repositories;

namespace TimeSheet.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public string AddClient(Client client)
        {
            try
            {
                if (client.Name == "" || client.Name == null || client.Address == "" || client.Address == null || client.City == "" || client.City == null || client.Zip == "" || client.Zip == null)
                {
                    throw new BusinessLayerException("Client name, address, city and zip cannot be empty");
                }
                if (_clientRepository.GetClientByNameAndAddress(client.Name, client.Address).Name != null)
                {
                    throw new BusinessLayerException("A client with that name and address already exists");
                }
                _clientRepository.AddClient(client);
                return "Client successfully added";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public IEnumerable<Client> GetAllClients()
        {
            try
            {
                return _clientRepository.GetAllClients();
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public Client GetClientById(int id)
        {
            try
            {
                return _clientRepository.GetClientById(id);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public string UpdateClient(Client client)
        {
            try
            {
                if (client.Name == "" || client.Name == null || client.Address == "" || client.Address == null || client.City == "" || client.City == null || client.Zip == "" || client.Zip == null)
                {
                    throw new BusinessLayerException("Client name, address, city and zip cannot be empty");
                }
                Client clientCheck = _clientRepository.GetClientByNameAndAddress(client.Name, client.Address);
                if (clientCheck.Name != null && clientCheck.ID != client.ID)
                {
                    throw new BusinessLayerException("A client with that name and address already exists");
                }
                _clientRepository.UpdateClient(client);
                return "Client successfully updated";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public string DeleteClientLogically(int id)
        {
            try
            {
                _clientRepository.DeleteClientLogically(id);
                return "Client successfully deleted";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public IEnumerable<Client> SearchClients(string name, int page, int number)
        {
            try
            {
                return _clientRepository.SearchClients(name, page, number);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public IEnumerable<string> GetClientsFirstLetters()
        {
            try
            {
                return _clientRepository.GetClientsFirstLetters();
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }

        public int GetNumberOfClients()
        {
            try
            {
                return _clientRepository.GetNumberOfClients();
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
        }

        public int GetNumberOfFilteredClients(string name)
        {
            try
            {
                return _clientRepository.GetNumberOfFilteredClients(name);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Client> GetClientsByPage(int page, int number)
        {
            try
            {
                return _clientRepository.GetClientsByPage(page, number);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
        }
    }
}
