namespace PetHero.Models
{
    public class CreateHelpRequestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LastLocation { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
