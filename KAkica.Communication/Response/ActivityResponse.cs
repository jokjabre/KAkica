using JokJaBre.Core.API.Dto;
using JokJaBre.Core.Objects;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.Response
{
    public class ActivityResponse : JokJaBreResponse<Activity>
    {
        public long Id { get; set; }
        public bool Poop { get; set; }
        public bool Whizz { get; set; }

        public long PooperId { get; set; }

        public override void SetFrom(IJokJaBreModel obj)
        {
        }
    }
}
