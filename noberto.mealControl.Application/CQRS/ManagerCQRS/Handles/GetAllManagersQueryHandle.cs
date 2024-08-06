using MediatR;
using noberto.mealControl.Application.CQRS.ManagerCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Handles;

public class GetAllManagersQueryHandle
    : IRequestHandler<GetAllManagersQuery, IEnumerable<Manager>>
{
    private readonly IManagerRepository _repository;

    public GetAllManagersQueryHandle(IManagerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Manager>> Handle(GetAllManagersQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllManagersAsync();
    }
}
