using Account.Domain.Seedwork;

namespace Account.Domain.AggregatesModel
{
    public class Role : Entity, IAggregateRoot
    {
        public string RoleName { get; set; }

        public List<UserRole> UserRoles { get; set; }

    }
}
