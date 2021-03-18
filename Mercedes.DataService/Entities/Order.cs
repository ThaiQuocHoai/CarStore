using Mercedes.DataService.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mercedes.DataService.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime DateOrder { get; set; }
        public float Total { get; set; }
        public string UserID { get; set; }
        public Status Status { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public User User { get; set; }
    }
}
