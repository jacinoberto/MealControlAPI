namespace noberto.mealControl.Application.Background.Utils.Validations.ValidateDayAndHours.Impl;

public class ValidateDayAndHoursImpl : IValidateDayAndHours
{
    public bool Validate()
    {
        TimeSpan timeNow = DateTime.Now.TimeOfDay;
        var standardTime = new TimeSpan(00, 00, 00);

        if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday
            && timeNow.Hours == standardTime.Hours
            && timeNow.Minutes == standardTime.Minutes
            && timeNow.Seconds == standardTime.Seconds)
        {
            return true;
        }

        return false;
    }
}
