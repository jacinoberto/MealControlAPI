using MediatR;
using noberto.mealControl.Application.CQRS.AddressCQRS.Command;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.WorkCQRS.Commands;

public class CreateWorkCommand : IRequest<Work>
{
    public string Identification { get; set; }
    public DateOnly StartDate { get; set; }
    public Guid AdministratorId { get; set; }
    public CreateAddressCommand Address { get; set; }

    public CreateWorkCommand(string identification, DateOnly startDate, Guid administratorId,
        CreateAddressCommand address)
    {
        Identification = identification;
        StartDate = startDate;
        AdministratorId = administratorId;
        Address = address;
    }
}
