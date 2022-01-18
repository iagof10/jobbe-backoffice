using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.DTOs
{
    public class ResponseBase<T>
    {
        public T Data { get; set; }
        public bool Sucess { get; set; }
        public string ErrorMessage { get; set; }

        public ResponseBase()
        {
            Sucess = true;
        }

    }
}
