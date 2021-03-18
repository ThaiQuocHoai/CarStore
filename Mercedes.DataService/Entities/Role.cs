using Mercedes.DataService.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mercedes.DataService.Entities
{
    public class Role
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public Status Status { get; set; }

        public List<User> Users { get; set; }
    }
}
