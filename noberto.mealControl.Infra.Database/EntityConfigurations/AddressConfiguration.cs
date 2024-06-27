using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Infra.Database.EntityConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("tb_addresses");

        builder.HasKey(address => address.Id);

        builder.Property(address => address.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(address => address.Id)
            .HasColumnName("id_address");

        builder.Property(address => address.ZipCode)
            .HasColumnName("zip_code")
            .HasMaxLength(8)
            .IsRequired();

        builder.Property(address => address.Street)
            .HasColumnName("street")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(address => address.Number)
            .HasColumnName("number")
            .IsRequired();

        builder.Property(address => address.Area)
            .HasColumnName("area")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(address => address.City)
            .HasColumnName("city")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(address => address.State)
            .HasColumnName("state")
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(address => address.Complement)
            .HasColumnName("complement")
            .HasMaxLength(100);
    }
}
