using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.DAL.Entities
{
    public class Project
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(60)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Client is required")]
        public int ClientID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Status is required")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Lead is required")]
        public int LeadID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
