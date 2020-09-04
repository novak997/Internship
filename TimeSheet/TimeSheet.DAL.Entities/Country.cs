using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.DAL.Entities
{
    public class Country
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(40)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Short name is required")]
        [StringLength(3)]
        public string Short { get; set; }
        public bool IsActive { get; set; }
    }
}
