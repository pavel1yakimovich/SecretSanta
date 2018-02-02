namespace AzureSecretSanta.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string GiftDescription { get; set; }
        public UserModel SantaOf { get; set; }
    }
}