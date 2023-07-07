﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO
{
    public class CustomerUpdateRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
    }
}