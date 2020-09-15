using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.DAL.Entities
{
    public class Client
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(30)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is required")]
        [StringLength(50)]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required")]
        [StringLength(20)]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Zip code is required")]
        [StringLength(15)]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public int CountryID { get; set; }
        public bool IsDeleted { get; set; }
        [Timestamp]
        public byte[] Concurrency { get; set; }


    }
}
