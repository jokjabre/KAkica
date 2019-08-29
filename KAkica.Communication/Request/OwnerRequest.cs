using JokJaBre.Core.API;
using JokJaBre.Core.Objects;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.Request
{
    public class OwnerRequest : JokJaBreRequest<Owner>
    {
        public override void SetTo(Owner obj)
        {
        }
    }
}
