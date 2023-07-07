using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO
{
    public class CustomerRequest
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }    
        public string Email { get; set; }
        public string Contact { get; set; }
    }
}
