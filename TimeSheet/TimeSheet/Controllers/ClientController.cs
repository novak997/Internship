using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.Business.Services;
using TimeSheet.DAL.Entities;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddClient([FromBody] Client client)
        {
            try
            {
                return Json(_clientService.AddClient(client));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public JsonResult DeleteClientLogically(int id)
        {
            try
            {
                return Json(_clientService.DeleteClientLogically(id));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpGet]
        public JsonResult GetAllClients()
        {
            try
            {
                return Json(_clientService.GetAllClients());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public JsonResult GetClientById(int id)
        {
            try
            {
                return Json(_clientService.GetClientById(id));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpGet("letters")]
        public JsonResult GetClientsFirstLetters()
        {
            try
            {
                return Json(_clientService.GetClientsFirstLetters());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpPost("{name}")]
        public JsonResult SearchClients([FromBody] string name)
        {
            try
            {
                return Json(_clientService.SearchClients(name));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        [HttpPut]
        public JsonResult UpdateClient([FromBody] Client client)
        {
            try
            {
                return Json(_clientService.UpdateClient(client));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }
    }
}
