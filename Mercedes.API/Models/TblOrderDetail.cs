using System;
using System.Collections.Generic;

#nullable disable

namespace Mercedes.API.Models
{
    public partial class TblOrderDetail
    {
        public int OrdDetailId { get; set; }
        public int? CarId { get; set; }
        public int? OrderId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public bool? Status { get; set; }

        public virtual TblCar Car { get; set; }
        public virtual TblOrder Order { get; set; }
    }
}
