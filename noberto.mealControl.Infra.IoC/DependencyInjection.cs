using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using noberto.mealControl.Application.Background.Services.Background;
using noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingDateToWork;
using noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingDateToWork.Impl;
using noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingPendingDateToWork;
using noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingPendingDateToWork.Impl;
using noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingPendingWorksToDate;
using noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingPendingWorksToDate.Impl;
using noberto.mealControl.Application.Background.Services.OpenCalendar;
using noberto.mealControl.Application.Background.Services.OpenCalendar.Impl;
using noberto.mealControl.Application.Background.Services.RegisterMealDate;
using noberto.mealControl.Application.Background.Services.RegisterMealDate.Impl;
using noberto.mealControl.Application.Background.Utils.Filters.FilterWorks;
using noberto.mealControl.Application.Background.Utils.Filters.FilterWorks.Impl;
using noberto.mealControl.Application.Background.Utils.Validations.ValidateAtypicalDay;
using noberto.mealControl.Application.Background.Utils.Validations.ValidateAtypicalDay.Impl;
using noberto.mealControl.Application.Background.Utils.Validations.ValidateDayAndHours;
using noberto.mealControl.Application.Background.Utils.Validations.ValidateDayAndHours.Impl;
using noberto.mealControl.Application.Background.Utils.Validations.ValidateWeekend;
using noberto.mealControl.Application.Background.Utils.Validations.ValidateWeekend.Impl;
using noberto.mealControl.Application.Background.Utils.Validations.ValidateWorkOnLocalEventScheduling;
using noberto.mealControl.Application.Background.Utils.Validations.ValidateWorkOnLocalEventScheduling.Impl;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Application.Mappings;
using noberto.mealControl.Application.Services;
using noberto.mealControl.Application.Utils.CalculationForReport;
using noberto.mealControl.Application.Utils.Validations.ValidateDay;
using noberto.mealControl.Application.Utils.Validations.ValidateDay.Impl;
using noberto.mealControl.Application.Utils.Validations.ValidateMeals;
using noberto.mealControl.Application.Utils.Validations.ValidateMeals.Impl;
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

        services.AddAutoMapper(typeof(DomainToDtoProfile));

        var myHandlers = AppDomain.CurrentDomain.Load("noberto.mealControl.Application");
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(myHandlers));

        // Registrando repositórios
        services.AddScoped<IAdministratorRepository, AdministratorRepositoryImpl>();
        services.AddScoped<IManagerRepository, ManagerRepositoryImlp>();
        services.AddScoped<IWorkerRepository, WorkerRepositoryImpl>();
        services.AddScoped<IWorkRepository, WorkRepositoryImpl>();
        services.AddScoped<ITeamManagementRepository, TeamManagementRepositoryImpl>();
        services.AddScoped<ITeamRepository, TeamRepositoryImpl>();
        services.AddScoped<IScheduleEventRepository, ScheduleEventRepositoryImpl>();
        services.AddScoped<IScheduleLocalEventRepository, ScheduleLocalEventRepositoryImpl>();
        services.AddScoped<IMealRepository, MealRepositoryImpl>();

        // Registrando Serviços
        services.AddScoped<IAdministratorService, AdministratorServiceImpl>();
        services.AddScoped<IManagerService, ManagerServiceImpl>();
        services.AddScoped<IWorkerService, WorkerServiceImpl>();
        services.AddScoped<IWorkService, WorkServiceImpl>();
        services.AddScoped<ITeamManagementService, TeamManagementServiceImpl>();
        services.AddScoped<ITeamService, TeamServiceImpl>();
        services.AddScoped<IScheduleEventService, ScheduleEventServiceImpl>();
        services.AddScoped<IScheduleLocalEventService, ScheduleLocalEventServiceImpl>();
        services.AddScoped<IMealService, MealServiceImpl>();
        services.AddHostedService<WorkService>();


        //Registrando validações dos dados quando cadastrados
        services.AddScoped<IFilterWorks, FilterWorks>();
        services.AddScoped<IValidateWeekendStrategy, Weekend>();
        services.AddScoped<IValidateWeekendStrategy, MidWeek>();
        services.AddScoped<IAssingPendingWorksToDate, AssingPendingWorksToDate>();
        services.AddScoped<IValidateWorkOnLocalEventScheduling, ValidateWorkOnLocalEventScheduling>();
        services.AddScoped<IAssingPendingDateToWork, AssingPendingDateToWork>();
        services.AddScoped<IAssingDateToWork, AssingDateToWork>();
        services.AddScoped<IRegisterMealDate, RegisterMealDateImpl>();
        services.AddScoped<RegisterMealDateImpl>();
        services.AddScoped<OpenCalendarImpl>();
        services.AddScoped<IValidateAtypicalDayStrategy, AtypicalDay>();
        services.AddScoped<IValidateAtypicalDayStrategy, NotAtypicalDay>();
        services.AddScoped<IOpenCalendar, OpenCalendarImpl>();

        services.AddScoped<IValidateStrategy<Administrator>, DuplicateAdminEmailError>();
        services.AddScoped<IValidateStrategy<Administrator>, DuplicateAdminRegistrationError>();
        services.AddScoped<IValidateStrategy<Manager>, DuplicateManagerEmailError>();
        services.AddScoped<IValidateStrategy<Manager>, DuplicateManagerRegistrationError>();
        services.AddScoped<IValidateStrategy<Worker>, DuplicateWorkerRegistrationError>();
        services.AddScoped<IValidateStrategy<Work>, DuplicateWorkIdentificationError>();
        services.AddScoped<IValidateStrategy<TeamManagement>, DuplicateTeamManagementSectorError>();
        services.AddScoped<IValidateStrategy<TeamManagement>, DuplicateTeamManagementWorkError>();
        services.AddTransient<IValidateDayAndHours, ValidateDayAndHoursImpl>();
        
        services.AddScoped<IValidateTerm, ValidateTerm>();
        services.AddScoped<IValidateMeals<UpdateMealCoffeeDTO>, Coffe>();
        services.AddScoped<IValidateMeals<UpdateMealLunchDTO>, Lunch>();
        services.AddScoped<IValidateMeals<UpdateMealDinnerDTO>, Dinner>();
        services.AddScoped<Calculation>();

        return services;
    }
}
