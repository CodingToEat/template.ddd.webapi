using MediatR;
using MicroServiceName.Dom.Agg;

namespace MicroServiceName.Dom.Evt;

public abstract class MicroServiceNameEvent(MicroServiceNameAgg entity) : INotification
{
    public MicroServiceNameAgg MicroserviceNameAgg { get; } = entity;
}

public class MicroServiceNameCreatedEvt(MicroServiceNameAgg entity) 
    : MicroServiceNameEvent(entity);

public class MicroServiceNameUpdatedEvt(MicroServiceNameAgg entity)
    : MicroServiceNameEvent(entity);

public class MicroServiceNameDeletedEvt(MicroServiceNameAgg entity)
    : MicroServiceNameEvent(entity);