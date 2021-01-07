using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Appliance
    {
        public int ApplianceId { get; set; }
        public int HomeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public decimal Cost { get; set; }
        public string PurchaseDate { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public string WarrantyExpiration { get; set; }
        //{
        //    get
        //    {
        //        return Convert.ToDateTime(WarrantyExpirationDate).Date;
        //    }
        //}
        public string WarrantyExpirationDate { get; set; }
        public string Description { get; set; }
        public string EstimatedDelivery { get; set; }
        public string DeliveryDate { get; set; }
        public string ReceiptUrl { get; set; }

        public string DeliveryZip { get; set; }



    }
}
