using System;
using System.Collections.Generic;

namespace Library.Model
{
    public partial class TblOrder
    {
        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public int CustomerId { get; set; }
        public int Status { get; set; }
        public decimal? Total { get; set; }

        public virtual TblCustomer Customer { get; set; }
    }
}
