using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Repair
    {
        public int RepairId { get; set; }
        public int HomeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal ProjectedCost { get; set; }
        public decimal Cost { get; set; }
        public string LastRepairDate { get; set; }
        public int ExpectedLife { get; set; }
        public string PotentialReplacementDate { get; set; }
        public string Description { get; set; }

        public string ServiceZip { get; set; }
    }
    public class RepairDate
    {
        public int RepairId { get; set; }
        public int HomeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal ProjectedCost { get; set; }
        public decimal Cost { get; set; }
        public string LastRepairDate { get; set; }
        public int ExpectedLife { get; set; }
        public string PotentialReplacementDate { get; set; }
        public string Description { get; set; }
    }

}
