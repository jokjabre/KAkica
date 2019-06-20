using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Domain.Models
{
    public class KAkicaDbContext : IdentityDbContext<IdentityUser>
    {

        public KAkicaDbContext(DbContextOptions<KAkicaDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Pooper> Poopers { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<OwnerPooper> OwnerPoopers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Database\\k_akica2.mdf;Integrated Security=True");
            //}
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PooperConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerPooperConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
