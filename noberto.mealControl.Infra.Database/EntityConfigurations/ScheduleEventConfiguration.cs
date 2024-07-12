using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Infra.Database.EntityConfigurations;

public class ScheduleEventConfiguration : IEntityTypeConfiguration<ScheduleEvent>
{
    public void Configure(EntityTypeBuilder<ScheduleEvent> builder)
    {
        builder.ToTable("tb_schedule_events");

        builder.HasKey(scheduleEvent => scheduleEvent.Id);

        builder.Property(scheduleEvent => scheduleEvent.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(team => team.Id)
            .HasColumnName("id_team");

        builder.Property(scheduleEvent => scheduleEvent.MealDate)
            .HasColumnName("meal_date")
            .IsRequired();

        builder.Property(scheduleEvent => scheduleEvent.Description)
            .HasColumnName("description")
            .HasMaxLength(100);

        builder.Property(scheduleEvent => scheduleEvent.Atypical)
            .HasColumnName("atypical")
            .IsRequired();

        builder.Property(scheduleEvent => scheduleEvent.AdministratorId)
            .HasColumnName("administrator_id");

        // Relacionamento
        builder.HasOne(ScheduleEvent => ScheduleEvent.Administrator)
            .WithMany(admin => admin.ScheduleEvents)
            .HasForeignKey(scheduleEvent => scheduleEvent.AdministratorId);
    }
}
