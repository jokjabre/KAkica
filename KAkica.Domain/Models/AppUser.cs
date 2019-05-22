using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Domain.Models
{
    public class AppUser
    {
        public AppUser()
        {
            AppUserPoopers = new List<AppUserPooper>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set;}
        public string Password { get; set; }

        public virtual ICollection<AppUserPooper> AppUserPoopers { get; set; }
    }

    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Username).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(20);

            builder.HasIndex(e => e.Username).IsUnique();
            builder.HasIndex(e => e.Email).IsUnique();

            builder.HasData(new[] {
                    new AppUser() {Id = 1, Username = "user1", Email = "mail1@test.com", Password= "test"},
                    new AppUser() {Id = 2, Username = "user2", Email = "mail2@test.com", Password= "test"},
            });
        }
    }
}
