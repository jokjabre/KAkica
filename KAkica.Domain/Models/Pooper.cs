using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Domain.Models
{
    public class Pooper
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<AppUserPooper> AppUserPoopers { get; set; }
    }

    public class PooperConfiguration : IEntityTypeConfiguration<Pooper>
    {
        public void Configure(EntityTypeBuilder<Pooper> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasData(new[] {
                    new Pooper() {Id = 1, Name = "pooper1"},
                    new Pooper() {Id = 2, Name = "pooper2"}
                });
        }
    }
}
