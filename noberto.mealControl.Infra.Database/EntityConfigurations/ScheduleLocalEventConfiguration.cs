using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Infra.Database.EntityConfigurations;

public class ScheduleLocalEventConfiguration : IEntityTypeConfiguration<ScheduleLocalEvent>
{
    public void Configure(EntityTypeBuilder<ScheduleLocalEvent> builder)
    {
        builder.ToTable("tb_schedule_local_events");

        builder.HasKey(scheduleLocalEvent => scheduleLocalEvent.Id)
            .HasName("id_schedule_local_event");

        builder.Property(scheduleLocalEvent => scheduleLocalEvent.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(scheduleEvent => scheduleEvent.Id)
            .HasColumnName("id_schedule_event");

        builder.Property(scheduleLocalEvent => scheduleLocalEvent.AdministratorId)
            .HasColumnName("administrator_id");

        builder.Property(scheduleLocalEvent => scheduleLocalEvent.ScheduleEventId)
            .HasColumnName("schedule_event_id")
            .IsRequired();

        builder.Property(scheduleLocalEvent => scheduleLocalEvent.WorkId)
            .HasColumnName("work_id")
            .IsRequired();

        //Relacionamentos
        builder.HasOne(scheduleLocalEvent => scheduleLocalEvent.Administrator)
            .WithMany(admin => admin.ScheduleLocalEvents)
            .HasForeignKey(scheduleLocalEvent => scheduleLocalEvent.AdministratorId);

        builder.HasOne(scheduleLocalEvent => scheduleLocalEvent.ScheduleEvent)
            .WithMany(scheduleEvent => scheduleEvent.ScheduleLocalEvents)
            .HasForeignKey(scheduleLocalEvent => scheduleLocalEvent.ScheduleEventId);

        builder.HasOne(scheduleLocalEvent => scheduleLocalEvent.Work)
            .WithMany(work => work.ScheduleLocalEvents)
            .HasForeignKey(scheduleLocalEvent => scheduleLocalEvent.WorkId);
    }
}
