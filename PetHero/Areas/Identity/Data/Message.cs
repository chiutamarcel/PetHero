namespace PetHero.Areas.Identity.Data
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public User MessageSender { get; set; }
        public User MessageReceiver { get; set; }
    }
}
