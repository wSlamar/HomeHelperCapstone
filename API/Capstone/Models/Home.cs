using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Home
    {
        public int HomeId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string TypeOfHome { get; set; }
        public string Nickname { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int BuildYear { get; set; }
        public int PurchaseYear { get; set; }
        public string PicUrl { get; set; }
        public string VendorName { get; set; }
        public string VendorEmail { get; set; }
        public string VendorPhone { get; set; }
        public string VendorNotes { get; set; }
        public string VendorSpecialty { get; set; }
        public string StoreName { get; set; }
        public string StoreNotes { get; set; }
        public string StorePhone { get; set; }


    }

    public class HomeReminder
    {
        public int HomeId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string TypeOfHome { get; set; }
        public string Nickname { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int BuildYear { get; set; }
        public int PurchaseYear { get; set; }
        public string PicUrl { get; set; }
        public List<Reminder> Reminders { get; set; } = new List<Reminder>();
    }

}
