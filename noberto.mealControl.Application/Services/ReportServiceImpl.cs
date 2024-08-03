using noberto.mealControl.Application.DTOs.Report;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Application.Utils.CalculationForReport;

namespace noberto.mealControl.Application.Services;

public class ReportServiceImpl : IReportService
{
    private readonly ICalculation _calculation;

    public ReportServiceImpl(ICalculation calculation)
    {
        _calculation = calculation;
    }

    public async Task<IEnumerable<ReportDTO>> GetReportsByStartDateAndClosingDateAndManagerId(DateOnly startDate, DateOnly closingDate, Guid managerId)
    {
        return await _calculation.Execute(startDate, closingDate, managerId);
    }
}
