using Microsoft.EntityFrameworkCore;

namespace PetHero.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.HelpRequests)
            //    .WithOne();

            //modelBuilder.Entity <HelpRequest>()
            //    .HasOne(u)
            //    .WithOne();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<HelpRequest> HelpRequests { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Message { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IEnumerable<HelpRequest> HelpRequests { get; set; }

        public User(int id, string name, string username, string password)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
        }
    }

    public class HelpRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
        public User User { get; set; }
    }

    public class Message
    {
        public int Id { get; set; }
        public User Sender { get; set; }
        public string MessageText { get; set; }
        public DateTime Time { get; set; }
    }

    public class Chat
    {
        public User User1 { get; set; }
        public User User2 { get; set; }
        public IEnumerable<Message> MessageList { get; set; }
    }
}
