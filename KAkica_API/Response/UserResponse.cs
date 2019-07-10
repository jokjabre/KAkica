using JokJaBre.Core.Identity;
using KAkica.Domain.Models;

namespace KAkica.API.Response
{
    public class UserResponse : JokJaBreIdentityResponse<KakicaUser>
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public long? OwnerId { get; set; }

        public override void SetFrom(KakicaUser obj)
        {
            OwnerId = obj.Owner?.Id;
        }
    }
}
