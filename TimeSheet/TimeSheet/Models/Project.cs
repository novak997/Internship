using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ClientID { get; set; }
        public string Status { get; set; }
        public int LeadID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
