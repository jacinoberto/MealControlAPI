using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using noberto.mealControl.Infra.Database.Context;

namespace noberto.mealControl.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<MealControlDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(MealControlDbContext).Assembly.FullName)));

        return services;
    }
}
