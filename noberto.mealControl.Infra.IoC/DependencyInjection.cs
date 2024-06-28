using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;
using noberto.mealControl.Infra.Database.Context;
using noberto.mealControl.Infra.Database.Repositories;
using noberto.mealControl.Infra.Database.Utils.Validations;
using noberto.mealControl.Infra.Database.Utils.Validations.DuplicateData;
using noberto.mealControl.Infra.Database.Utils.Validations.DuplicateDataImpl;

namespace noberto.mealControl.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<MealControlDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(MealControlDbContext).Assembly.FullName)));

        // Registrando Repositórios
        services.AddScoped<IAdministratorRepository, AdministratorRepositoryImpl>();
        services.AddScoped<IManagerRepository, ManagerRepositoryImlp>();
        services.AddScoped<IWorkerRepository, WorkerRepositoryImpl>();
        services.AddScoped<IWorkRepository, WorkRepositoryImpl>();
        services.AddScoped<ITeamManagementRepository, TeamManagementRepositoryImpl>();
        services.AddScoped<ITeamRepository, TeamRepositoryImpl>();
        services.AddScoped<IScheduleEventRepository, ScheduleEventRepositoryImpl>();
        services.AddScoped<IScheduleLocalEventRepository, ScheduleLocalEventRepositoryImpl>();
        services.AddScoped<IMealRepository, MealRepositoryImpl>();

        //Registrando Validações
        services.AddScoped<IValidateStrategy<Administrator>, DuplicateAdminEmailError>();
        services.AddScoped<IValidateStrategy<Administrator>, DuplicateAdminRegistrationError>();
        services.AddScoped<IValidateStrategy<Manager>, DuplicateManagerEmailError>();
        services.AddScoped<IValidateStrategy<Manager>, DuplicateManagerRegistrationError>();
        services.AddScoped<IValidateStrategy<Worker>, DuplicateWorkerRegistrationError>();
        services.AddScoped<IValidateStrategy<Work>, DuplicateWorkIdentificationError>();
        services.AddScoped<IValidateStrategy<TeamManagement>, DuplicateTeamManagementSectorError>();
        services.AddScoped<IValidateStrategy<TeamManagement>, DuplicateTeamManagementWorkError>();

        return services;
    }
}
