using Account.Domain.Seedwork;

namespace Account.Domain.AggregatesModel
{
    public class User : Entity, IAggregateRoot
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string HashPassword { get; set; }
        public string Phone { get; set; }

        public List<UserRole> UserRoles { get; set; }

    }
}
