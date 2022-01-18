using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Domain.DTOs.User
{
    public class UserDtoInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string KeyUser { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
