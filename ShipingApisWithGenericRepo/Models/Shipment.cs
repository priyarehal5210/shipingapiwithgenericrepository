﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithGenericRepo.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime AlteredDate { get; set; }
      
        public int ClientID { get; set; }
        public Client client { get; set; }
        public int ServiceID { get; set; }
        public int ShipFromAddressID { get; set; }
        public ShipFromAddress ShipFromAddress { get; set; }
        public int ShipToAddressID { get; set; }
        public ShipToAddress shipToAddress { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPending { get; set; }
        public bool IsShipped { get; set; }
    }
}
