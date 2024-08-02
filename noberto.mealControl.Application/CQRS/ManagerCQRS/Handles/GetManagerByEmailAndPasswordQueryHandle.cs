using MediatR;
using noberto.mealControl.Application.CQRS.ManagerCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Handles;

public class GetManagerByEmailAndPasswordQueryHandle
    : IRequestHandler<GetManagerByEmailAndPasswordQuery, Manager>
{
    private readonly IManagerRepository _repository;

    public GetManagerByEmailAndPasswordQueryHandle(IManagerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Manager> Handle(GetManagerByEmailAndPasswordQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetManagerByEmailAndPassword(request.Email, request.Password);
    }
}
