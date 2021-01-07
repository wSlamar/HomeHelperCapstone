using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public int HomeId { get; set; }
        public string VendorName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Specialty { get; set; }
        public string Notes { get; set; }
        public int Zip { get; set; }
        public string Name { get; set; }
    }
}
