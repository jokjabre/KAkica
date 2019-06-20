using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Domain.Models
{
    public class OwnerPooper
    {
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        public int PooperId { get; set; }
        public virtual Pooper Pooper { get; set; }
    }

    public class OwnerPooperConfiguration : IEntityTypeConfiguration<OwnerPooper>
    {
        public void Configure(EntityTypeBuilder<OwnerPooper> builder)
        {
            builder.HasKey(e => new { e.PooperId, e.OwnerId });

            builder.HasOne(sc => sc.Pooper)
                .WithMany(s => s.OwnerPoopers)
                .HasForeignKey(sc => sc.PooperId);

            builder.HasOne(sc => sc.Owner)
                .WithMany(s => s.OwnerPoopers)
                .HasForeignKey(sc => sc.OwnerId);


            //builder.HasData(new[] {
            //        new AppUserPooper() { AppUserId = 1, PooperId = 1},

            //        new AppUserPooper() { AppUserId = 2, PooperId = 1},
            //        new AppUserPooper() { AppUserId = 2, PooperId = 2},
            //});
        }
    }
}
