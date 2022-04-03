namespace PetHero.Areas.Identity.Data
{
    public class Chat
    {
        public int Id { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Message> MessageList { get; set; }
    }
}
