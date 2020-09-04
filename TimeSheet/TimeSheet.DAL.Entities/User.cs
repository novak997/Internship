using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.DAL.Entities
{
    public class User
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Hours is required")]
        [StringLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Weekly hours are required")]
        [Range(0, 112, ErrorMessage = "Weekly hours must be between 0 and 112")]
        public double Weekly { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [StringLength(20)]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(30)]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Status is required")]
        public bool IsActive { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Role is required")]
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
    }
}
