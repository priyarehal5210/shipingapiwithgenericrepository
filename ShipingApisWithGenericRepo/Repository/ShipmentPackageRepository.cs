using ShipingApisWithGenericRepo.Models;
using ShipingApisWithGenericRepo.Repository.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithGenericRepo.Repository
{
    public class ShipmentPackageRepository:Repository<ShipmentPackages>,IshipmentPackages
    {
        private readonly ApplicationDbContext con;
        public ShipmentPackageRepository(ApplicationDbContext conn):base(conn)
        {
            con = conn;
        }
    }
}
