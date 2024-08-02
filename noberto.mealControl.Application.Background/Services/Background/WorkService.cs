using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using noberto.mealControl.Application.Background.Services.OpenCalendar;
using noberto.mealControl.Application.Background.Services.OpenCalendar.Impl;
using noberto.mealControl.Application.Background.Services.RegisterMealDate;
using noberto.mealControl.Application.Background.Services.RegisterMealDate.Impl;
using noberto.mealControl.Application.Background.Utils.Validations.ValidateDayAndHours;

namespace noberto.mealControl.Application.Background.Services.Background;

public class WorkService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IValidateDayAndHours _validateDayAndHours;

    public WorkService(IValidateDayAndHours validateDayAndHours, IServiceProvider serviceProvider)
    {
        _validateDayAndHours = validateDayAndHours;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_validateDayAndHours.Validate())
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var registerMealDate = scope.ServiceProvider.GetRequiredService<RegisterMealDateImpl>();
                    var openCalendar = scope.ServiceProvider.GetRequiredService<OpenCalendarImpl>();

                    await registerMealDate.Register();
                    await openCalendar.Open();
                }
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
