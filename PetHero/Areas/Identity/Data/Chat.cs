namespace PetHero.Areas.Identity.Data
{
    public class Chat
    {
        public int Id { get; set; }
        public User User1 { get; set; }
        public User User2 { get;set; }
        public IEnumerable<Message> MessageList { get; set; }
    }
}
