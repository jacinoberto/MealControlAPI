using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Infra.Database.EntityConfigurations;

public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.ToTable("tb_workers");

        builder.HasKey(worker => worker.Id);

        builder.Property(worker => worker.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(worker => worker.Id)
            .HasColumnName("id_worker");

        builder.Property(worker => worker.Registration)
            .HasColumnName("registration")
            .HasMaxLength(9)
            .IsRequired();

        builder.Property(worker => worker.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(worker => worker.ActiveProfile)
            .HasColumnName("active_profile")
            .IsRequired();
    }
}
