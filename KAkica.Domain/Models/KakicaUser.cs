using JokJaBre.Core.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KAkica.Domain.Models
{
    public class KakicaUser : IJokJaBreIdentityModel, IJokJaBreModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Owner Owner { get; set; }
    }

    public class KakicaUserConfiguration : IEntityTypeConfiguration<KakicaUser>
    {
        public void Configure(EntityTypeBuilder<KakicaUser> builder)
        {
            builder.HasKey(e => e.Username);

            builder.HasIndex(e => e.Username).IsUnique();
            builder.HasIndex(e => e.Email).IsUnique();
            builder.HasOne(e => e.Owner).WithOne(e => e.KakicaUser).HasForeignKey<Owner>(e => e.KakicaUserRef);
        }
    }
}
