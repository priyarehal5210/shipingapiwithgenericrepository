using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipingApisWithGenericRepo.Models;
using ShipingApisWithGenericRepo.Repository.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithGenericRepo.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly Iunitofwork _iunitofwork;
        public ClientController(Iunitofwork iunitofwork)
        {
            _iunitofwork = iunitofwork;
        }
        [HttpGet]
        public IActionResult GetClient()
        {
            return Ok(_iunitofwork.iclient.GetAll());
        }
        [HttpPost]
        public IActionResult Addclient([FromBody] Client client)
        {
            if(ModelState.IsValid && client.id == 0)
            {
                _iunitofwork.iclient.Add(client);
                _iunitofwork.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateClient([FromBody] Client client)
        {
            if(ModelState.IsValid && client.id != 0)
            {
                _iunitofwork.iclient.Update(client);
                _iunitofwork.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            var ClientIndb = _iunitofwork.iclient.Get(id);
            if (ClientIndb == null) return NotFound();
            else
            {
                _iunitofwork.iclient.Remove(ClientIndb);
                _iunitofwork.save();
                return Ok();
            }
        }
    }
}
