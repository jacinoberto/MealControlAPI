using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Queries;

public class GetMangerByRegistrationOrNameOrEmailQuery : IRequest<IEnumerable<Manager>>
{
    public string RegistrationOrNameOrEmail { get; set; }
    public string State { get; set; }

    public GetMangerByRegistrationOrNameOrEmailQuery(string registrationOrNameOrEmail, string state)
    {
        RegistrationOrNameOrEmail = registrationOrNameOrEmail;
        State = state;
    }
}
