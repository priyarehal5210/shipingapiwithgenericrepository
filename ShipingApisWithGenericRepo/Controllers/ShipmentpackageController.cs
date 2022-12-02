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
    [Route("api/shipmentpackage")]
    [ApiController]
    public class ShipmentpackageController : Controller
    {
        private readonly Iunitofwork _iunitofwork;
        public ShipmentpackageController(Iunitofwork iunitofwork)
        {
            _iunitofwork = iunitofwork;
        }
        [HttpGet]
        public IActionResult GetShipmentpackage()
        {
            return Ok(_iunitofwork.IshipmentPackages.GetAll(IncludeProperties: "Shipment"));
        }
        [HttpPost]
        public IActionResult Addshipmentpackage([FromBody] ShipmentPackages shipmentPackages)
        {
            if (ModelState.IsValid && shipmentPackages.ID == 0)
            {
                _iunitofwork.IshipmentPackages.Add(shipmentPackages);
                _iunitofwork.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Updateshipmentpackage([FromBody] ShipmentPackages shipmentPackages)
        {
            if (ModelState.IsValid && shipmentPackages.ID != 0)
            {
                _iunitofwork.IshipmentPackages.Update(shipmentPackages);
                _iunitofwork.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Deleteshipmentpackage(int id)
        {
            var shimpmentpackageIndb = _iunitofwork.IshipmentPackages.Get(id);
            if (shimpmentpackageIndb== null) return NotFound();
            else
            {
                _iunitofwork.IshipmentPackages.Remove(shimpmentpackageIndb);
                _iunitofwork.save();
                return Ok();
            }
        }
    }
}
 