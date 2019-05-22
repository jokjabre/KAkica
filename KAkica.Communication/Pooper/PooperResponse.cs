using KAkica.Communication.AppUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.Pooper
{
    public class PooperResponse
    {
        public ICollection<AppUserResponse> Owners { get; set; }
    }
}
