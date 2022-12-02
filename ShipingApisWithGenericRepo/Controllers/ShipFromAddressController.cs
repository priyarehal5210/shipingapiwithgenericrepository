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
    [Route("api/shipfromaddress")]
    [ApiController]
    public class ShipFromAddressController : Controller
    {
        private readonly Iunitofwork _iunitofwork;
        public ShipFromAddressController(Iunitofwork iunitofwork)
        {
            _iunitofwork = iunitofwork;
        }
        [HttpGet]
        public IActionResult GetShipFromAddress()
        {
            return Ok(_iunitofwork.IshipFromAddress.GetAll());
        }
        [HttpPost]
        public IActionResult AddShipFromAddress([FromBody] ShipFromAddress shipFromAddress)
        {
            if(ModelState.IsValid && shipFromAddress.ID == 0)
            {
                _iunitofwork.IshipFromAddress.Add(shipFromAddress);
                _iunitofwork.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateShipFromAddress([FromBody] ShipFromAddress shipFromAddress)
        {
            if(ModelState.IsValid && shipFromAddress.ID != 0)
            {
                _iunitofwork.IshipFromAddress.Update(shipFromAddress);
                _iunitofwork.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteShipFromAddress(int id)
        {
            var ShipFromAddressInDb = _iunitofwork.IshipFromAddress.Get(id);
            if (ShipFromAddressInDb == null) return NotFound();
            else
            {
                _iunitofwork.IshipFromAddress.Remove(ShipFromAddressInDb);
                _iunitofwork.save();
                return Ok();
            }
        }
    }
}
