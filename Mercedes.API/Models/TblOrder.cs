using System;
using System.Collections.Generic;

#nullable disable

namespace Mercedes.API.Models
{
    public partial class TblOrder
    {
        public TblOrder()
        {
            TblOrderDetails = new HashSet<TblOrderDetail>();
        }

        public int OrderId { get; set; }
        public DateTime? DateOrder { get; set; }
        public double? Total { get; set; }
        public string UserId { get; set; }
        public bool? Status { get; set; }

        public virtual TblUser User { get; set; }
        public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
    }
}
