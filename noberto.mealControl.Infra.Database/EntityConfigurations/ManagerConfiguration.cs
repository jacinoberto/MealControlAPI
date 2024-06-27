using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Infra.Database.EntityConfigurations;

public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.ToTable("tb_managers");

        builder.HasKey(manager => manager.Id);

        builder.Property(manager => manager.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(manager => manager.Id)
            .HasColumnName("id_manager");

        //builder.ComplexProperty(manager => manager.User);

        builder.OwnsOne(manager => manager.User, userBuilder =>
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

        //Relacionamento
        builder.HasOne(manager => manager.Address)
            .WithMany(address => address.Managers)
            .HasForeignKey(manager => manager.AddressId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
