using KAkica.Communication.AppUser;
using KAkica.Communication.Pooper;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.AppUserPooper
{
    public class AppUserPooperResponse : AppUserPooperDto
    {
        public AppUserDto AppUser { get; set; }
        public PooperDto Pooper { get; set; }
    }
}
