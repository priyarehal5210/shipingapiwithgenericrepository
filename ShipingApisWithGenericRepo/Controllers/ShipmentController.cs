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
    [Route("api/shipment")]
    [ApiController]
    public class ShipmentController : Controller
    {
        private readonly Iunitofwork _iunitofwork;
        public ShipmentController(Iunitofwork iunitofwork)
        {
            _iunitofwork = iunitofwork;
        }
        [HttpGet]
        public IActionResult GetShipment()
        {
            var shiplist = _iunitofwork.ishipment.GetAll(IncludeProperties: "client,ShipFromAddress,shipToAddress");
            return Ok(shiplist);
        }

        [HttpPost]
        public IActionResult Addshipment([FromBody] Shipment shipment)
        {
            if (ModelState.IsValid && shipment.Id== 0)
            {
                _iunitofwork.ishipment.Add(shipment);
                _iunitofwork.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Updateshipmentpackage([FromBody] Shipment shipments)
        {
            if (ModelState.IsValid && shipments.Id != 0)
            {
                _iunitofwork.ishipment.Update(shipments);
                _iunitofwork.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Deleteshipmentpackage(int id)
        {
            var shimpmentIndb = _iunitofwork.ishipment.Get(id);
            if (shimpmentIndb == null) return NotFound();
            else
            {
                _iunitofwork.ishipment.Remove(shimpmentIndb);
                _iunitofwork.save();
                return Ok();
            }
        }
    }
}
