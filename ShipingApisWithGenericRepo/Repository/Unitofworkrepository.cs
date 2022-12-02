using ShipingApisWithGenericRepo.Repository.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithGenericRepo.Repository
{
    public class Unitofworkrepository : Iunitofwork
    {
        private readonly ApplicationDbContext con;
        public Unitofworkrepository(ApplicationDbContext conn)
        {
            con = conn;
            IshipFromAddress = new ShipFromAddressRepository(con);
            ishipToAddress = new ShipToAddressRepository(con);
            IshipmentPackages = new ShipmentPackageRepository(con);
            iclient = new ClientRepository(con);
            ishipment = new ShipmentRepository(con);
        }
        public IshipFromAddress IshipFromAddress { get; private set; }

        public IshipToAddress ishipToAddress { get; private set; }

        public IshipmentPackages IshipmentPackages { get; private set; }

        public Ishipment ishipment { get; private set; }

        public Iclient iclient { get; private set; }

        public void save()
        {
            con.SaveChanges();
        }
    }
}
