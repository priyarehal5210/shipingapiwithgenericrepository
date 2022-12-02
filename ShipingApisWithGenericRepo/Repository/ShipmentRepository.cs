using ShipingApisWithGenericRepo.Models;
using ShipingApisWithGenericRepo.Repository.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithGenericRepo.Repository
{
    public class ShipmentRepository:Repository<Shipment>,Ishipment
    {
        private readonly ApplicationDbContext con;
        public ShipmentRepository(ApplicationDbContext conn):base(conn)
        {
            con = conn;
        }
    }
}
