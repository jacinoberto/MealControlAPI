using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Queries;

public class GetManagerByEmailAndPasswordQuery : IRequest<Manager>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public GetManagerByEmailAndPasswordQuery(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
