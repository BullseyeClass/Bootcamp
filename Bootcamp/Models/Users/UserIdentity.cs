namespace Bootcamp.Models.Users
{
    public class UserIdentity
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string NormalizedUsername { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }

        public string PasswordHash { get; set; }
    }
}
