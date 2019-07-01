using JokJaBre.Core.Objects;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.PooperViewModels
{
    public class PooperRequest : JokJaBreRequest<Pooper>
    {
        public string Name { get; set; }
        public override void SetTo(IJokJaBreModel obj)
        {

        }
    }
}
