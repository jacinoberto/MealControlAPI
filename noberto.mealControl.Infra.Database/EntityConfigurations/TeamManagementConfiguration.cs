using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Infra.Database.EntityConfigurations;

public class TeamManagementConfiguration : IEntityTypeConfiguration<TeamManagement>
{
    public void Configure(EntityTypeBuilder<TeamManagement> builder)
    {
        builder.ToTable("tb_team_management");

        builder.HasKey(teamManagement => teamManagement.Id);

        builder.Property(teamManagement => teamManagement.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(teamManagement => teamManagement.Id)
            .HasColumnName("id_teamManagement");

        builder.Property(teamManagement => teamManagement.Sector)
            .HasColumnName("sector")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(teamManagement => teamManagement.ActiveTeam)
            .HasColumnName("active_team")
            .IsRequired();

        builder.Property(teamManagement => teamManagement.AdministratorId)
            .HasColumnName("administrator_id")
            .IsRequired();

        builder.Property(teamManagement => teamManagement.ManagerId)
            .HasColumnName("manager_id")
            .IsRequired();

        builder.Property(teamManagement => teamManagement.WorkId)
            .HasColumnName("work_id")
            .IsRequired();

        //Relacionamentos
        builder.HasOne(teamManagement => teamManagement.Administrator)
            .WithMany(admin => admin.TeamManagement)
            .HasForeignKey(teamManagement => teamManagement.AdministratorId);

        builder.HasOne(teamManagement => teamManagement.Manager)
            .WithMany(manager => manager.TeamManagement)
            .HasForeignKey(teamManagement => teamManagement.ManagerId);

        builder.HasOne(teamManagement => teamManagement.Work)
            .WithMany(work => work.TeamManagemant)
            .HasForeignKey(teamManagement => teamManagement.WorkId);
    }
}
