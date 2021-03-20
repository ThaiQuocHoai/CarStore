using Mercedes.DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mercedes.Application.System
{
    public interface IUserService
    {
        User Authencate(string Username, string Password);
    }
}
