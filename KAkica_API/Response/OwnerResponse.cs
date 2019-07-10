using JokJaBre.Core.API.Dto;
using JokJaBre.Core.Objects;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.API.Response
{
    public class OwnerResponse : JokJaBreResponse<Owner>
    {
        public long Id { get; set; }
        public string Name { get; set; }


        public override void SetFrom(IJokJaBreModel model)
        {
            
        }
    }
}
