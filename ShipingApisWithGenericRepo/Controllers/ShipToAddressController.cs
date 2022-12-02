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
    [Route("api/shiptoaddress")]
    [ApiController]
    public class ShipToAddressController : Controller
    {
        private readonly Iunitofwork _iunitofwork;
        public ShipToAddressController(Iunitofwork iunitofwork)
        {
            _iunitofwork = iunitofwork;
        }
        [HttpGet]
        public IActionResult GetShiptoaddress()
        {
            return Ok(_iunitofwork.ishipToAddress.GetAll());
        }
        [HttpPost]
        public IActionResult AddShiptoaddress([FromBody] ShipToAddress shipToAddress)
        {
            if (ModelState.IsValid && shipToAddress.ID == 0)
            {
                _iunitofwork.ishipToAddress.Add(shipToAddress);
                _iunitofwork.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Updateshiptoaddress([FromBody] ShipToAddress shipToAddress)
        {
            if(ModelState.IsValid && shipToAddress.ID != 0)
            {
                _iunitofwork.ishipToAddress.Update(shipToAddress);
                _iunitofwork.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Deleteshiptoaddress(int id)
        {
            var shiptoaddressindb = _iunitofwork.ishipToAddress.Get(id);
            if (shiptoaddressindb == null) return NotFound();
            else
            {
                _iunitofwork.ishipToAddress.Remove(shiptoaddressindb);
                _iunitofwork.save();
                return Ok();
            }
        }
    }
}
