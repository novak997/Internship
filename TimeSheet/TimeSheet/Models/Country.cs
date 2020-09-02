using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Short { get; set; }
        public bool IsActive { get; set; }
    }
}
