using IdentityApi1.Model;
using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    // DbContextOptions parametresi ile yapıcı
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    // Veritabanı yapılandırmasını burada yapabilirsiniz
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=UserDb;Username=postgres;Password=7777");
        }
    }
}
