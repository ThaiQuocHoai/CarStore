using System;
using System.Collections.Generic;
using System.Text;

namespace Mercedes.Application.Catalog.Cars.Dtos
{
    public class CreateCarRequest
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public string Decription { get; set; }
        public int CategoryID { get; set; }

    }
}
