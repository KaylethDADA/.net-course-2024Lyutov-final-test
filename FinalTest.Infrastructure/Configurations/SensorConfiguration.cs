using FinalTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalTest.Infrastructure.Configurations
{
    public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired();

            builder.Property(s => s.Description);

            builder.Property(s => s.DataType)
                .IsRequired();

            builder.Property(s => s.MinThreshold)
                .IsRequired();
            
            builder.Property(s => s.MaxThreshold)
                .IsRequired();

            builder.HasMany(s => s.SensorData)
                   .WithOne(sd => sd.Sensor)
                   .HasForeignKey(sd => sd.SensorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
