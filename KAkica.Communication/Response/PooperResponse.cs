using JokJaBre.Core.API.Dto;
using JokJaBre.Core.Objects;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.Response
{
    public class PooperResponse : JokJaBreResponse<Pooper>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Activity> Activities { get; set; } = Array.Empty<Activity>();

        public override void SetFrom(IJokJaBreModel model)
        {
            
        }
    }
}
