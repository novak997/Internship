using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.DAL.Entities
{
    public class Worktime
    {
        public int ID { get; set; }
        [StringLength(60)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Hours is required")]
        [Range(0, 16, ErrorMessage = "Hours must be between 0 and 16")]
        public double Hours { get; set; }
        public double Overtime { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [Range(0, 8, ErrorMessage = "Overtime hours must be between 0 and 8")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Client is required")]
        public int ClientID { get; set; }
        [Required(ErrorMessage = "Project is required")]
        public int ProjectID { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "User is required")]
        public int UserID { get; set; }

    }
}
