using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Infra.Database.Context;

public class MealControlDbContext : DbContext
{
    public MealControlDbContext(DbContextOptions<MealControlDbContext> options) 
    : base(options) {}

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Work> Works { get; set; }
    public DbSet<TeamManagement> TeamManagement { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<ScheduleEvent> ScheduleEvents { get; set; }
    public DbSet<ScheduleLocalEvent> ScheduleLocalEvents { get; set; }
    public DbSet<Meal> Meals { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(MealControlDbContext).Assembly);
    }
}
