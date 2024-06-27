using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Infra.Database.EntityConfigurations;

public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
{
    public void Configure(EntityTypeBuilder<Administrator> builder)
    {
        builder.ToTable("tb_administrators");

        builder.HasKey(admin => admin.Id);

        builder.Property(admin => admin.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(admin => admin.Id)
            .HasColumnName("id_administrator");

        //builder.ComplexProperty(admin => admin.User);

        builder.OwnsOne(admin => admin.User, userBuilder =>
        {
            userBuilder.Property(user => user.Registration)
                .HasColumnName("registration")
                .HasMaxLength(9)
                .IsRequired();

            userBuilder.Property(user => user.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            userBuilder.Property(user => user.Email)
                .HasColumnName("email")
                .HasMaxLength(150)
                .IsRequired();

            userBuilder.Property(user => user.Password)
                .HasColumnName("password")
                .IsRequired();

            userBuilder.Property(user => user.ActiveProfile)
                .HasColumnName("active_profile")
                .IsRequired();

            // Propriedades unícas
            userBuilder.HasIndex(user => user.Registration)
                .IsUnique();

            userBuilder.HasIndex(user => user.Email)
                .IsUnique();
        });

        builder.Property(admin => admin.AddressId)
            .HasColumnName("address_id");

        //Relacionamento
        builder.HasOne(admin => admin.Address)
            .WithMany(address => address.Administrators)
            .HasForeignKey(admin => admin.AddressId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
