using JokJaBre.Core.Identity;
using KAkica.Domain.Models;

namespace KAkica.API.Request
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
