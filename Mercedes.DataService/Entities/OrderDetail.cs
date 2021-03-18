using Mercedes.DataService.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mercedes.DataService.Entities
{
    public class OrderDetail
    {
        public int CarID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public Status Status { get; set; }
        public Car Car { get; set; }
        public Order Order { get; set; }
    }
}
