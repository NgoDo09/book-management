using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Library.Model
{
    public partial class TblAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        [JsonIgnore]
        public virtual TblCustomer TblCustomer { get; set; }
    }
}
