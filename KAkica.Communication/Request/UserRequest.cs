﻿using JokJaBre.Core.Identity;
using JokJaBre.Core.Objects;
using KAkica.Domain.Models;

namespace KAkica.Communication.Request
{
    public class UserRequest : JokJaBreIdentityRequest<KakicaUser>
    {
        public override void SetTo(KakicaUser obj)
        {
            obj.Owner = new Owner()
            {
                Id = 0,
                KakicaUserRef = obj.Username,
                Name = obj.Username
            };
        }
    }
}
