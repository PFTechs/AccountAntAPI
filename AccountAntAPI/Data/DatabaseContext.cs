using AccountAntAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountAntAPI.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Collection> Collections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
            .Property(i => i.ContainingCollectionId)
            .IsRequired();

            modelBuilder.Entity<Collection>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Collection)
                .HasForeignKey(i => i.ContainingCollectionId);
        }

    }
}
