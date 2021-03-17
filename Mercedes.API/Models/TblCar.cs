using System;
using System.Collections.Generic;

#nullable disable

namespace Mercedes.API.Models
{
    public partial class TblCar
    {
        public TblCar()
        {
            TblOrderDetails = new HashSet<TblOrderDetail>();
        }

        public int CarId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public bool? Status { get; set; }

        public TblCar(int carId, string name, string color, double? price, int? quantity, string image, string description, int? categoryId, bool? status, TblCategory category, ICollection<TblOrderDetail> tblOrderDetails)
        {
            CarId = carId;
            Name = name;
            Color = color;
            Price = price;
            Quantity = quantity;
            Image = image;
            Description = description;
            CategoryId = categoryId;
            Status = status;
            Category = category;
            TblOrderDetails = tblOrderDetails;
        }

        public virtual TblCategory Category { get; set; }
        public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
    }
}
