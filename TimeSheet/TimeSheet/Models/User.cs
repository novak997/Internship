using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Weekly { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
    }
}
