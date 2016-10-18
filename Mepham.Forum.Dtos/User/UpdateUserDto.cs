using System;

namespace Mepham.Forum.Dtos.User
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordOne { get; set; }
        public string PasswordTwo { get; set; }
    }
}
