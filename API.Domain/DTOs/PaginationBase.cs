using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.DTOs
{
    public class PaginationBase
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 100;
    }
}
