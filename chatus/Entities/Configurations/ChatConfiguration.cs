using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chatus.API.Entities.Configurations;

public class ChatConfiguration : IEntityTypeConfiguration<ChatEntity>
{
    public void Configure(EntityTypeBuilder<ChatEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type)
               .HasConversion<int>();

        builder.HasMany(x => x.Users)
               .WithMany(x => x.Chats);

        builder.HasMany(x => x.Messages)
               .WithOne(x => x.Chat)
               .HasForeignKey(x => x.ChatId);
    }
}