using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.AppUser
{
    public abstract class AppUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
