using MediatR;
using MicroServiceName.Dom.Agg;
using MicroServiceName.Dom.Evt;
using MicroServiceName.Dom.Seed;

namespace MicroServiceName.App.Deh;

public abstract class RecordHistoryWhenMicroServiceNameDeh<TEvent>(
    IEntityRepository<MicroServiceNameHistoryAgg> entityRepository,
    MicroServiceNameEventEnum eventType) : INotificationHandler<TEvent>
    where TEvent : MicroServiceNameEvent
{
    private readonly IEntityRepository<MicroServiceNameHistoryAgg> MicroServiceNameHistoryRepository = entityRepository;
    private readonly MicroServiceNameEventEnum eventType = eventType;

    public async Task Handle(TEvent notification, CancellationToken cancellationToken)
    {
        var entity =
            MicroServiceNameHistoryAgg.Create(
                notification.MicroserviceNameAgg.Id, eventType);

        await MicroServiceNameHistoryRepository.Create(entity);
        await MicroServiceNameHistoryRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}

public class RecordHistoryWhenMicroServiceNameCreatedDeh(
    IEntityRepository<MicroServiceNameHistoryAgg> entityRepository) :
    RecordHistoryWhenMicroServiceNameDeh<MicroServiceNameCreatedEvt>(entityRepository, 
    MicroServiceNameEventEnum.Create)
{
}

public class RecordHistoryWhenMicroServiceNameUpdatedDeh(
    IEntityRepository<MicroServiceNameHistoryAgg> entityRepository) :
    RecordHistoryWhenMicroServiceNameDeh<MicroServiceNameUpdatedEvt>(entityRepository, 
    MicroServiceNameEventEnum.Update)
{
}

public class RecordHistoryWhenMicroServiceNameDeletedDeh(
    IEntityRepository<MicroServiceNameHistoryAgg> entityRepository) :
    RecordHistoryWhenMicroServiceNameDeh<MicroServiceNameDeletedEvt>(entityRepository, 
    MicroServiceNameEventEnum.Delete)
{
}