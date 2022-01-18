using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.DTOs.User
{
    public class UserDtoOutput
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string KeyUser { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
