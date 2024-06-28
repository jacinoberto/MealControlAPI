using MediatR;
using noberto.mealControl.Application.CQRS.ManagerCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Handles;

public class GetManagerByStateQueryHandle
    : IRequestHandler<GetManagerByStateQuery, IEnumerable<Manager>>
{
    private readonly IManagerRepository _repository;

    public GetManagerByStateQueryHandle(IManagerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Manager>> Handle(GetManagerByStateQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetManagersByStateAsync(request.State);
    }
}
