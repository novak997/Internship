using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Controllers.DTO
{
    public class ChangePasswordDTO
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
        public int ID { get; set; }
    }
}
