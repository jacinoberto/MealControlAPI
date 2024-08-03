using noberto.mealControl.Application.DTOs.Report;

namespace noberto.mealControl.Application.Utils.CalculationForReport;

public interface ICalculation
{
    Task<IEnumerable<ReportDTO>> Execute(DateOnly startDate, DateOnly closingDate, Guid managerId);
}
