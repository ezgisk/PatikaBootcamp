namespace Relational.Data.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        // İlişki
        public ICollection<Post> Posts { get; set; }
    }
}
