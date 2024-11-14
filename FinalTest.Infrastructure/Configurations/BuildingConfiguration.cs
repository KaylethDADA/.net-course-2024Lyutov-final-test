using FinalTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalTest.Infrastructure.Configurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired();

            builder.Property(b => b.Address)
                .IsRequired();

            builder.HasMany(b => b.Sensors)
                   .WithOne(s => s.Building)
                   .HasForeignKey(s => s.BuildingId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
