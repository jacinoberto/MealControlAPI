using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Handles;

public class CreateScheduleEventCommandHandle
    : IRequestHandler<CreateScheduleEventCommand, ScheduleEvent>
{
    private readonly IScheduleEventRepository _repository;
    private readonly IWorkRepository _workerRepository;
    private readonly IScheduleLocalEventRepository _scheduleLocalEventRepository;

    public CreateScheduleEventCommandHandle(IScheduleEventRepository repository, IWorkRepository workerRepository, IScheduleLocalEventRepository scheduleLocalEventRepository)
    {
        _repository = repository;
        _workerRepository = workerRepository;
        _scheduleLocalEventRepository = scheduleLocalEventRepository;
    }

    public async Task<ScheduleEvent> Handle(CreateScheduleEventCommand request, CancellationToken cancellationToken)
    {
        var works = await _workerRepository.GetWorksByCityAsync(request.Citys);
        IList<ScheduleEvent> e = [];
        
        var scheduleEvent = new ScheduleEvent(request.MealDate, request.Description,
            request.Atypical);
        scheduleEvent.AdministratorId = request.AdministratorId;
            
        var result = await _repository.CreateScheduleEventAsync(scheduleEvent);
        e.Add(result);

        foreach (var work in works)
        {
            var r = await _scheduleLocalEventRepository.GetScheduleLocalEventByWorkId(work.Id);

            if (r is null)
            {
                var scheduleLocal = new ScheduleLocalEvent();
                scheduleLocal.AdministratorId = request.AdministratorId;
                scheduleLocal.ScheduleEventId = result.Id;
                scheduleLocal.WorkId  = work.Id;

                await _scheduleLocalEventRepository.CreateScheduleLocalEventAsync(scheduleLocal);
            }
        }

        return result;
    }
}
