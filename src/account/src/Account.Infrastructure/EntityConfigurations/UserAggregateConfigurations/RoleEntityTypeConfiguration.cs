using Account.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Infrastructure.EntityConfigurations.UserAggregateConfigurations
{
    public class RoleEntityTypeConfiguration: IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles", AccountContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);

            builder.HasData(
                new Role
                {
                    Id = "af5205f8-048e-44c9-acb2-5fae81591a02",
                    RoleName = "Admin"
                },
                new Role
                {
                    Id = "f73e2090-6224-4e0a-b9f2-240710dd42e8",
                    RoleName = "User"
                }
            );
        }
    }
}
