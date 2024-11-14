using FinalTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalTest.Infrastructure.Configurations
{
    public class SensorDataConfiguration : IEntityTypeConfiguration<SensorData>
    {
        public void Configure(EntityTypeBuilder<SensorData> builder)
        {
            builder.HasKey(sd => sd.Id);

            builder.Property(sd => sd.Value).IsRequired();
            builder.Property(sd => sd.Timestamp).IsRequired();
        }
    }
}
