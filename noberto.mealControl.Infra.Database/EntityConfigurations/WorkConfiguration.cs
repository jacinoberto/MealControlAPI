using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Infra.Database.EntityConfigurations;

public class WorkConfiguration : IEntityTypeConfiguration<Work>
{
    public void Configure(EntityTypeBuilder<Work> builder)
    {
        builder.ToTable("tb_works");

        builder.HasKey(work => work.Id);

        builder.Property(work => work.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(work => work.Id)
            .HasColumnName("id_work");

        builder.Property(work => work.Identification)
            .HasColumnName("identification")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(work => work.StartDate)
            .HasColumnName("start_date")
            .IsRequired();

        builder.Property(work => work.ClosingDate)
            .HasColumnName("closing_date");

        builder.Property(work => work.AdministratorId)
            .HasColumnName("administrator_id")
            .IsRequired();

        builder.Property(work => work.AddressId)
            .HasColumnName("address_id")
            .IsRequired();

        //Relacionamentos
        builder.HasOne(work => work.Administrator)
            .WithMany(admin => admin.Works)
            .HasForeignKey(work => work.AdministratorId);

        builder.HasOne(work => work.Address)
            .WithMany(address => address.Works)
            .HasForeignKey(work => work.AddressId);
    }
}
