using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Domain.Models
{
    public class KAkicaDbContext : DbContext
    {

        public KAkicaDbContext(DbContextOptions<KAkicaDbContext> options) : base(options)
        {
            
        }

        public DbSet<Pooper> Poopers { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<OwnerPooper> OwnerPoopers { get; set; }
        public DbSet<KakicaUser> Users { get; set; }


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
            modelBuilder.ApplyConfiguration(new KakicaUserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
