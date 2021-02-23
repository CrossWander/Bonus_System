using BonusSystem.WebServer.Models;
using Microsoft.EntityFrameworkCore;

namespace BonusSystem.WebServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<BonusCard> BonusCards { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

         /*   builder.Entity<Client>()
                           .HasOne(a => a.BonusCard)
                           .WithOne(b => b.Client)
                           .HasForeignKey<BonusCard>(b => b.ClientId);*/
            builder.Entity<BonusCard>().ToTable("BonusCard");
            builder.Entity<Client>()
                     .ToTable("Client");
        }
    }
}
