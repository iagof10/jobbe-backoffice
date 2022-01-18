using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.DTOs.User
{
    public class UserLoginDtoInput
    {
        public string KeyUser { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
