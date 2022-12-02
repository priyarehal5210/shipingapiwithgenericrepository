using ShipingApisWithGenericRepo.Models;
using ShipingApisWithGenericRepo.Repository.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithGenericRepo.Repository
{
    public class ShipToAddressRepository:Repository<ShipToAddress>,IshipToAddress
    {
        private readonly ApplicationDbContext con;
        public ShipToAddressRepository(ApplicationDbContext conn):base(conn)
        {
            con = conn;
        }
    }
}
