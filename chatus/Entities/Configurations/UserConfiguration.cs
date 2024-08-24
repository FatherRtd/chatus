using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chatus.API.Entities.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Chats)
                   .WithMany(x => x.Users);

            builder.HasMany(x => x.Messages)
                   .WithOne(x => x.User);
        }
    }
}
