using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class Worktime
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public double Hours { get; set; }
        public double Overtime { get; set; }
        public DateTime Date { get; set; }
        public int ClientID { get; set; }
        public int ProjectID { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }

    }
}
