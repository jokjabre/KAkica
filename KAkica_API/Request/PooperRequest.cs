using JokJaBre.Core.API;
using JokJaBre.Core.Objects;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.API.Request
{
    public class PooperRequest : JokJaBreRequest<Pooper>
    {
        public string Name { get; set; }
        public override void SetTo(Pooper obj)
        {

        }
    }
}
