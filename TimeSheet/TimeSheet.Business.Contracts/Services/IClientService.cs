﻿using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.DAL.Entities;

namespace TimeSheet.Business.Contracts.Services
{
    public interface IClientService
    {
        public string AddClient(Client client);
        public IEnumerable<Client> GetAllClients();
        public Client GetClientById(int id);
        public string UpdateClient(Client client);
        public string DeleteClientLogically(int id);
        public IEnumerable<Client> SearchClients(string name);
        public IEnumerable<string> GetClientsFirstLetters();
    }
}
