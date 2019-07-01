using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.Auth
{
    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
