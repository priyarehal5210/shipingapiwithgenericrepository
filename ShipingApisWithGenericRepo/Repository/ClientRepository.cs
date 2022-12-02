using ShipingApisWithGenericRepo.Models;
using ShipingApisWithGenericRepo.Repository.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithGenericRepo.Repository
{
    public class ClientRepository:Repository<Client>,Iclient
    {
        private readonly ApplicationDbContext con;
        public ClientRepository(ApplicationDbContext conn):base(conn)
        {
            con = conn;
        }
    }
}
