using Microsoft.EntityFrameworkCore;

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
        public DbSet<Activity> Activities { get; set; }


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
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
