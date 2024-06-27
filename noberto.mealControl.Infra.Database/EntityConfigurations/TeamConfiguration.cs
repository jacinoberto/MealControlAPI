using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Infra.Database.EntityConfigurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("tb_teams");

        builder.HasKey(team => team.Id);

        builder.Property(team => team.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(team => team.Id)
            .HasColumnName("id_team");

        builder.Property(team => team.ActiveTeam)
            .HasColumnName("active_team")
            .IsRequired();

        builder.Property(team => team.AdministratorId)
            .HasColumnName("administrator_id")
            .IsRequired();

        builder.Property(team => team.TeamManagementId)
            .HasColumnName("manage_team_id")
            .IsRequired();

        builder.Property(team => team.WorkerId)
            .HasColumnName("worker_id")
            .IsRequired();

        //Relacionamentos
        builder.HasOne(team => team.Administrator)
            .WithMany(admin => admin.Teams)
            .HasForeignKey(team => team.AdministratorId);

        builder.HasOne(team => team.TeamManagement)
            .WithMany(manageTeam => manageTeam.Teams)
            .HasForeignKey(team => team.TeamManagementId);

        builder.HasOne(team => team.Worker)
            .WithMany(manageTeam => manageTeam.Teams)
            .HasForeignKey(team => team.WorkerId);
    }
}
