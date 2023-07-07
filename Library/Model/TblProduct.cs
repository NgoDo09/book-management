using System;
using System.Collections.Generic;

namespace Library.Model
{
    public partial class TblProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }
    }
}
