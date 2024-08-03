using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Infra.Database.EntityConfigurations;

public class MealConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.ToTable("tb_meals");

        builder.HasKey(meal => meal.Id)
            .HasName("id_meal");

        builder.Property(meal => meal.Id)
            .HasValueGenerator<GuidValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(meal => meal.Id)
            .HasColumnName("id_meal");

        builder.Property(meal => meal.Coffee)
            .HasColumnName("coffe")
            .IsRequired();

        builder.Property(meal => meal.Lunch)
            .HasColumnName("lunch")
            .IsRequired();

        builder.Property(meal => meal.Dinner)
            .HasColumnName("dinner")
            .IsRequired();

        builder.Property(meal => meal.AdministratorId)
            .HasColumnName("administrator_id");

        builder.Property(meal => meal.TeamId)
            .HasColumnName("team_id")
            .IsRequired();

        builder.Property(meal => meal.ShecheduleLocalEventId)
            .HasColumnName("schedule_local_event_id")
            .IsRequired();

        //Relaciomentos
        builder.HasOne(meal => meal.Administrator)
            .WithMany(admin => admin.Meals)
            .HasForeignKey(meal => meal.AdministratorId);

        builder.HasOne(meal => meal.Team)
            .WithMany(team => team.Meals)
            .HasForeignKey(meal => meal.TeamId);

        builder.HasOne(meal => meal.ScheduleLocalEvent)
            .WithMany(scheduleLocalEvent => scheduleLocalEvent.Meals)
            .HasForeignKey(meal => meal.ShecheduleLocalEventId);
    }
}
