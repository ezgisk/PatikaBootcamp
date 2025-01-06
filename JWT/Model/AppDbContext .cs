using Microsoft.EntityFrameworkCore;

namespace JWT.Model
{
    public class AppDbContext : DbContext
    {
        // Kullanıcılar tablosu
        public DbSet<User> Users { get; set; }

        // Constructor: DbContextOptions parametresi alır
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
