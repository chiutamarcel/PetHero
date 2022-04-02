namespace PetHero.Data
{
    public static class ApplicationDbSeed
    {
        public static void Seed(ApplicationDbContext db)
        {
            User user = new User(0, "Bababui", "username321", "password123");
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
