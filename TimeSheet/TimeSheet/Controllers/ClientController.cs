using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Models;
using TimeSheet.Repositories;
using TimeSheet.Services;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly ClientService _clientService = new ClientService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddClient([FromBody] Client client)
        {
            return Json(_clientService.AddClient(client));
        }

        [HttpPut("{id}")]
        public void DeleteClientLogically(int id)
        {
            _clientService.DeleteClientLogically(id);
        }

        [HttpGet]
        public JsonResult GetAllClients()
        {
            return Json(_clientService.GetAllClients());
        }

        [HttpGet("{id}")]
        public JsonResult GetClientById(int id)
        {
            return Json(_clientService.GetClientById(id));
        }

        [HttpGet("letters")]
        public JsonResult GetClientsFirstLetters()
        {
            return Json(_clientService.GetClientsFirstLetters());
        }

        [HttpPost("{name}")]
        public JsonResult SearchClients([FromBody] string name)
        {
            return Json(_clientService.SearchClients(name));
        }

        [HttpPut]
        public JsonResult UpdateClient([FromBody] Client client)
        {
            return Json(_clientService.UpdateClient(client));
        }
    }
}
