﻿using JokJaBre.Core.Objects;
using KAkica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Communication.OwnerViewModels
{
    public class OwnerResponse : JokJaBreResponse<Owner>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        //public OwnerResponse(Owner model) : base(model)
        //{
        //    Id = model.Id;
        //    Name = model.Name;
        //}

        public override void SetFrom(IJokJaBreModel model)
        {
            
        }
    }
}
