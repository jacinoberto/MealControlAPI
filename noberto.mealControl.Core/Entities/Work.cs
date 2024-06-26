using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;

namespace noberto.mealControl.Core.Entities;

public class Work : Identifier
{
    public string Identification { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly? ClosingDate { get; private set; }

    public Guid AdministratorId { get; set; }
    public Guid AddressId { get; set; }

    public Administrator Administrator { get; set; }
    public Address Address { get; set; }
    public IEnumerable<TeamManagement> TeamManagemants { get; set; }
    public IEnumerable<ScheduleLocalEvent> ScheduleLocalEvents { get; set; }

    public Work(string identification, DateOnly startDate)
    {
        ValidateWorkData(identification, startDate);
    }

    /// <summary>
    /// Validar os dados informados para a criação de uma nova Obra
    /// </summary>
    /// <param name="identification"></param>
    /// <param name="startDate"></param>
    private void ValidateWorkData(string identification, DateOnly startDate)
    {
        InvalidEntityDataException.When(string.IsNullOrEmpty(identification),
            BadInternalOrdersEnum.IdentificationIsNull.ToString());

        InvalidEntityDataException.When(identification.Length > 30,
            BadInternalOrdersEnum.LongIdentification.ToString());

        InvalidEntityDataException.When(identification.Length < 3,
            BadInternalOrdersEnum.ShortIdentification.ToString());

        InvalidEntityDataException.When(startDate == null,
            BadInternalOrdersEnum.StartDateIsNull.ToString());

        InvalidEntityDataException.When(startDate < DateOnly.FromDateTime(DateTime.UtcNow),
            BadInternalOrdersEnum.PastStartDate.ToString());

        Identification = identification;
        StartDate = startDate;
        ClosingDate = null;
    }

    /// <summary>
    /// Finalizar a construção de uma Obra
    /// </summary>
    public void FinishWork()
    {
        ClosingDate = DateOnly.FromDateTime(DateTime.Now);
    }
}
