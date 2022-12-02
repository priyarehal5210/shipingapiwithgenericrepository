using Microsoft.EntityFrameworkCore;
using ShipingApisWithGenericRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithGenericRepo
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<ShipFromAddress> shipFromAddresses { get; set; }
        public DbSet<ShipToAddress>shipToAddresses { get; set; }
        public DbSet<ShipmentPackages> shipmentPackages { get; set; }
        public DbSet<Shipment>shipments { get; set; }
        public DbSet<Client>clients { get; set; }
    }

}
