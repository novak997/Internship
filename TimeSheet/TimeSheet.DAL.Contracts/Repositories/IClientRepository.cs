﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.DAL.Entities;

namespace TimeSheet.DAL.Contracts.Repositories
{
    public interface IClientRepository
    {
        public int AddClient(Client client);
        public IEnumerable<Client> GetAllClients();
        public Client GetClientById(int id);
        public void UpdateClient(Client client);
        public void DeleteClientPhysically(int id);
        public void DeleteClientLogically(int id);
        public IEnumerable<Client> SearchClients(string name, int page, int number);
        public IEnumerable<string> GetClientsFirstLetters();
        public Client GetClientByNameAndAddress(string name, string address);
        public int GetNumberOfClients();
        public int GetNumberOfFilteredClients(string name);
        public IEnumerable<Client> GetClientsByPage(int page, int number);
    }
}
