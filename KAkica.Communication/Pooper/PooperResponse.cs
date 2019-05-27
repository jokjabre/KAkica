using KAkica.Communication.AppUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.Pooper
{
    public class PooperResponse : PooperDto
    {
        public int Id { get; set; }
        public ICollection<AppUserDto> Owners { get; set; }
    }
}
