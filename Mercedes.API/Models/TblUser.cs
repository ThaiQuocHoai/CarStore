using System;
using System.Collections.Generic;

#nullable disable

namespace Mercedes.API.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string RoleId { get; set; }
        public bool? Status { get; set; }

        public virtual TblRole Role { get; set; }
        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
