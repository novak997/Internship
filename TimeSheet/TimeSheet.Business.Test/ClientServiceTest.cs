using Moq;
using System;
using System.Net.WebSockets;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.Business.Exceptions;
using TimeSheet.Business.Services;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;
using Xunit;

namespace TimeSheet.Business.Test
{
    public class ClientServiceTest
    {
        [Fact]
        public void AddClientTestEmptyField()
        {
            Client client = new Client
            {
                Name = "",
                Address = "some address",
                City = "some city",
                Zip = "123",
                CountryID = 1
            };
            var clientRepositoryMock = new Mock<IClientRepository>();
            var clientService = new ClientService(clientRepositoryMock.Object);
            var exception = Assert.Throws<BusinessLayerException>(() => clientService.AddClient(client));
            Assert.Equal("Client name, address, city and zip cannot be empty", exception.Message);
        }

        [Fact]
        public void AddClientTestSuccessful()
        {
            Client client = new Client
            {
                Name = "some name",
                Address = "some address",
                City = "some city",
                Zip = "123",
                CountryID = 1
            };
            var clientRepositoryMock = new Mock<IClientRepository>();
            var clientService = new ClientService(clientRepositoryMock.Object);
            var result = clientService.AddClient(client);
            Assert.Equal("Client successfully added", result);
        }
    }
}
