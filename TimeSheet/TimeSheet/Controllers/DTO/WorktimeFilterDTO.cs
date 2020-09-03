using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Controllers.DTO
{
    public class WorktimeFilterDTO
    {
        public int UserID { get; set; }
        public int ClientID { get; set; }
        public int ProjectID { get; set; }
        public int CategoryID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
