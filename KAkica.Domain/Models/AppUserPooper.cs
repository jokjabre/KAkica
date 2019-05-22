using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Domain.Models
{
    public class AppUserPooper
    {
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public int PooperId { get; set; }
        public virtual Pooper Pooper { get; set; }
    }


    public class AppUserPooperConfiguration : IEntityTypeConfiguration<AppUserPooper>
    {
        public void Configure(EntityTypeBuilder<AppUserPooper> builder)
        {
            builder.HasKey(e => new { e.PooperId, e.AppUserId });

            builder.HasOne(sc => sc.Pooper)
                .WithMany(s => s.AppUserPoopers)
                .HasForeignKey(sc => sc.PooperId);

            builder.HasOne(sc => sc.AppUser)
                .WithMany(s => s.AppUserPoopers)
                .HasForeignKey(sc => sc.AppUserId);


            builder.HasData(new[] {
                    new AppUserPooper() { AppUserId = 1, PooperId = 1},

                    new AppUserPooper() { AppUserId = 2, PooperId = 1},
                    new AppUserPooper() { AppUserId = 2, PooperId = 2},
            });
        }
    }
}
