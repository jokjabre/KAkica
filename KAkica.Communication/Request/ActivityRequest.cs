using JokJaBre.Core.API;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.Request
{
    public class ActivityRequest : JokJaBreRequest<Activity>
    {
        public bool Poop { get; set; }
        public bool Whizz { get; set; }

        public long PooperId { get; set; }

        public override void SetTo(Activity obj)
        {
            
        }

    }
}
