using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.Application.Utils.Validations.ValidateDay.Impl;

public class ValidateTerm : IValidateTerm
{
    private readonly IScheduleEventService _service;

    public ValidateTerm(IScheduleEventService service)
    {
        _service = service;
    }

    public async Task<TimeSpan> Validate(DateOnly date)
    {
        var scheduleEvent = await _service.GetScheduleEventByDateAsync(date);

        if (scheduleEvent.Atypical) return new TimeSpan(0, 12, 0, 0);
        return new TimeSpan(1, 0, 0, 0);
    }
}
