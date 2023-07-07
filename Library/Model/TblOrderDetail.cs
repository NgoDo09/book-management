using System;
using System.Collections.Generic;

namespace Library.Model
{
    public partial class TblOrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Quantity { get; set; }

        public virtual TblOrder Order { get; set; }
        public virtual TblProduct Product { get; set; }
    }
}
