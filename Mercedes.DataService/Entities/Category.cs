using Mercedes.DataService.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mercedes.DataService.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Status Status { get; set; }

        public List<Car> Cars { get; set; }
    }
}
