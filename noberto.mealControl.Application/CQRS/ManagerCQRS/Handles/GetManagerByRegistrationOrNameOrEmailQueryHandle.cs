using MediatR;
using noberto.mealControl.Application.CQRS.ManagerCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Handles;

public class GetManagerByRegistrationOrNameOrEmailQueryHandle
    : IRequestHandler<GetMangerByRegistrationOrNameOrEmailQuery, IEnumerable<Manager>>
{
    private readonly IManagerRepository _repository;

    public GetManagerByRegistrationOrNameOrEmailQueryHandle(IManagerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Manager>> Handle(GetMangerByRegistrationOrNameOrEmailQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetManagersByRegistrationOrNameOrEmailAsync(
            request.RegistrationOrNameOrEmail, request.State);
    }
}
