using JokJaBre.Core.Objects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Domain.Models
{
    public class Owner : IJokJaBreModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string KakicaUserRef { get; set; }
        public KakicaUser KakicaUser { get; set; }


        public ICollection<OwnerPooper> OwnerPoopers { get; set; }
    }

    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();


        }
    }
}
