using Microsoft.EntityFrameworkCore;
using Survivor.Data.Entities;

namespace Survivor
{
    public class SurvivorContext : DbContext
    {
        public SurvivorContext(DbContextOptions<SurvivorContext> options)
            : base(options)
        {
        }

        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Seed verileri ekleme
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Kategoriler
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Survivor" },
                new Category { Id = 2, Name = "Celebrity" }
            );

            // Yarışmacılar
            modelBuilder.Entity<Competitor>().HasData(
                new Competitor { Id = 1, Name = "John Doe", Age = "30", CategoryId = 1 },
                new Competitor { Id = 2, Name = "Jane Smith", Age = "28", CategoryId = 2 },
                new Competitor { Id = 3, Name = "Alice Johnson", Age = "35", CategoryId = 1 },
                new Competitor { Id = 4, Name = "Bob Brown", Age = "27", CategoryId = 2 }
            );
        }
    }
}
