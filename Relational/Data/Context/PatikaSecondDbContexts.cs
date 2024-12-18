using Microsoft.EntityFrameworkCore;
using Relational.Data.Entity;

namespace Relational.Data.Context
{
    public class PatikaSecondDbContexts : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // PostgreSQL bağlantı dizesi
            optionsBuilder.UseNpgsql("Host=localhost;Database=PatikaCodeFirstDb2;Username=postgres;Password=7777");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User-Post ilişkisi
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts) 
                .WithOne(p => p.User)  
                .HasForeignKey(p => p.UserId); 


            base.OnModelCreating(modelBuilder);
        }
    }
}