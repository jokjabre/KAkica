using JokJaBre.Core.Objects;
using KAkica.Communication.AppUser;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.PooperViewModels
{
    public class PooperResponse : JokJaBreResponse<Pooper>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public override void SetFrom(IJokJaBreModel model)
        {
            
        }
    }
}
