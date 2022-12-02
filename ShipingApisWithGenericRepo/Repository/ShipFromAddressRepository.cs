
using ShipingApisWithGenericRepo.Models;
using ShipingApisWithGenericRepo.Repository.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithGenericRepo.Repository
{
    public class ShipFromAddressRepository:Repository<ShipFromAddress>, IshipFromAddress
    {
        private readonly ApplicationDbContext con;
        public ShipFromAddressRepository(ApplicationDbContext conn):base(conn)
        {
            con = conn;
        }
    }
}
