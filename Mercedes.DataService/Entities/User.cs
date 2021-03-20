using Mercedes.DataService.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mercedes.DataService.Entities
{
    public class User
    {
        public string UserID { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string RoleID { get; set; }
        public int Status { get; set; }

        public Role Role { get; set; }
        public List<Order> Orders { get; set; }
    }
}
