using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using KAkica.Domain.Attributes;

namespace KAkica.Domain.Models
{
    public class Owner : IKakicaModel
    {
        [Shown(Dto.Response)]
        public int Id { get; set; }

        [Shown]
        public string Name { get; set; }



        public int LoginId { get; set; }
        public virtual IdentityUser Login { get; set; }


        public virtual ICollection<OwnerPooper> OwnerPoopers { get; set; }
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
