using Account.Domain.Seedwork;

namespace Account.Domain.AggregatesModel
{
    public class UserRole : Entity
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
