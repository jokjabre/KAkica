using KAkica.Communication.Pooper;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.AppUser
{
    public class AppUserResponse : AppUserDto
    {
        public int Id { get; set; }
        public ICollection<PooperDto> Poopers { get; set; }
    }
}
