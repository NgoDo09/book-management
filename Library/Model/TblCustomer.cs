using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Library.Model
{
    public partial class TblCustomer
    {
        public TblCustomer()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public virtual TblAccount UsernameNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
