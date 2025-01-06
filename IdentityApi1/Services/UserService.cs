using IdentityApi1.Model;

namespace IdentityApi1.Services
{
    public class UserService
    {
        private readonly UserContext _context;

        public UserService(UserContext context)
        {
            _context = context;
        }

        public void AddUser(string email, string password)
        {
            // Model doğrulaması
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Email ve şifre boş olamaz.");
                return;
            }

            // Şifreyi güvenli bir şekilde şifrele
            var hashedPassword = PasswordHelper.HashPassword(password);

            // Yeni kullanıcıyı oluştur
            var user = new User
            {
                Email = email,
                Password = hashedPassword
            };

            // Kullanıcıyı veritabanına ekle
            _context.Users.Add(user);
            _context.SaveChanges();

            Console.WriteLine("Kullanıcı başarıyla eklendi.");
        }
    }
}