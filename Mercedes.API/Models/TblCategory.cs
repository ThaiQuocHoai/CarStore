using System;
using System.Collections.Generic;

#nullable disable

namespace Mercedes.API.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblCars = new HashSet<TblCar>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<TblCar> TblCars { get; set; }
    }
}
