using noberto.mealControl.Application.DTOs.Report;

namespace noberto.mealControl.Application.Interfaces;

public interface IReportService
{
    Task<IEnumerable<ReportDTO>> GetReportsByStartDateAndClosingDateAndManagerId(DateOnly startDate, DateOnly closingDate, Guid managerId);
}
