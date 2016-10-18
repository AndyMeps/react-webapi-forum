using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mepham.Forum.Dtos.User
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string PasswordOne { get; set; }
        public string PasswordTwo { get; set; }
    }
}
