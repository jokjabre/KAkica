using KAkica.Communication.Pooper;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.AppUser
{
    public class AppUserResponse
    {
        public ICollection<PooperResponse> Poopers { get; set; }
    }
}
