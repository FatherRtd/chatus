using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chatus.API.Entities.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<MessageEntity>
{
    public void Configure(EntityTypeBuilder<MessageEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Chat)
               .WithMany(x => x.Messages)
               .HasForeignKey(x => x.ChatId);

        builder.HasOne(x => x.User)
               .WithMany(x => x.Messages)
               .HasForeignKey(x => x.UserId);
    }
}