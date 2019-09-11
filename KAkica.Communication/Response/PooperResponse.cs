using JokJaBre.Core.API.Dto;
using JokJaBre.Core.Extensions;
using JokJaBre.Core.Objects;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KAkica.Communication.Response
{
    public class PooperResponse : JokJaBreResponse<Pooper>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<ActivityResponse> Activities { get; set; }

        public override void SetFrom(IJokJaBreModel model)
        {
            var pooper = model as Pooper;
            if (pooper == null) return;

            Activities = pooper.Activities.ToResponse<Activity, ActivityResponse>();
        }
    }
}
