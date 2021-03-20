using Mercedes.DataService.Entities;
using Mercedes.DataService.EntityFramework;
using Mercedes.DataService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercedes.Application.System
{
    public class UserService : IUserService
    {
        private readonly MercedesDbContext _context;

        public UserService(MercedesDbContext context)
        {
            _context = context;
        }
        public User Authencate(string Username, string Password)
        {
            var result = _context.Users.Where(x=> x.UserID.Equals(Username) && x.Password.Equals(Password) && x.Status == 1);
            if (result == null) return null;
            var data = result.Select(x => new User
            {
                UserID = x.UserID,
                Fullname = x.Fullname,
                Password = x.Password,
                Phone = x.Phone,
                Address = x.Address,
                Email = x.Email,
                BirthDate = x.BirthDate,
                CreateDate = x.CreateDate,
                RoleID = x.RoleID,
                Status = x.Status
            }).FirstOrDefault();
            return data;
        }
    }
}
