namespace PetHero.Areas.Identity.Data
{
    public class HelpRequest
    {
        public HelpRequest(int id, string title, string description, string imagePath)
        {
            Id = id;
            Title = title;
            Description = description;
            ImagePath = imagePath;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string LastLocation { get; set; }
        //public User User { get; set; }


    }
}
