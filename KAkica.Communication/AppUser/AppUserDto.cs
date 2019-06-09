using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KAkica.Communication.AppUser
{
    public class AppUserDto
    { 
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
