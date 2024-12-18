using CodeFirst.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Video.Data.Entities;

namespace CodeFirst.Data
{
    public class PatikaFirstDbContext : DbContext 
    {
        public PatikaFirstDbContext( DbContextOptions<PatikaFirstDbContext> options) : base(options) { }
        public DbSet<Game> Games { get; set; }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movies");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.ReleaseYear).HasColumnName("ReleaseYear");
                entity.Property(e => e.Genre).HasColumnName("Genre");
                entity.HasIndex(e => e.Id);


            });
            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Games");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Platform).HasColumnName("Platform");
                entity.Property(e => e.Rating).HasColumnName("Rating");
                entity.HasIndex(e => e.Id);


            });

        }

    }
}
