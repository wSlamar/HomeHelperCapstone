using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Reminder
    {

        
        public string Type { get; set; }
        public int? ApplianceId { get; set; }
        public int? RepairId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public bool Completed { get; set; }

    }
    public class ReminderHome
    {

        public Home Home { get; set; } = new Home();
        public string Type { get; set; }
        public int? ApplianceId { get; set; }
        public int? RepairId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public bool Completed { get; set; }

    }
}
