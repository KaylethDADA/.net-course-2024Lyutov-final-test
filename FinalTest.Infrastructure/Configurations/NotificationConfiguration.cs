using FinalTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalTest.Infrastructure.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Recipient)
                .IsRequired();

            builder.Property(n => n.Date)
                .IsRequired();

            builder.Property(n => n.Message)
                .IsRequired();

            builder.HasIndex(n => n.Date); 
        }
    }
}
