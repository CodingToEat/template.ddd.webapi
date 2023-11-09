using MicroServiceName.Dom.Evt;
using MicroServiceName.Dom.Seed;

namespace MicroServiceName.Dom.Agg;

public class MicroServiceNameAgg: Entity, IAggregateRoot
{
    private MicroServiceNameAgg(Guid id, string name): base(id)
    {
        Id = id;
        Name = name;
        State = MicroServiceNameStateEnum.Created;
    }

    public string Name { get; private set; }
    public MicroServiceNameStateEnum State { get; private set; }

    public static MicroServiceNameAgg Create(string name)
    { 
        var result = new MicroServiceNameAgg(Guid.NewGuid(), name);
        result.AddDomainEvent(new MicroServiceNameCreatedEvt(result));
        return result;
    }

    public void Update(string name)
    {
        if (State == MicroServiceNameStateEnum.Deleted)
        {
            StateChangeException(MicroServiceNameStateEnum.Updated);
        }

        Name = name;
        State = MicroServiceNameStateEnum.Updated;
        AddDomainEvent(new MicroServiceNameUpdatedEvt(this));
    }

    public void Delete()
    {
        if (State == MicroServiceNameStateEnum.Deleted)
        {
            StateChangeException(MicroServiceNameStateEnum.Deleted);
        }

        State = MicroServiceNameStateEnum.Deleted;
        AddDomainEvent(new MicroServiceNameDeletedEvt(this));
    }

    private void StateChangeException(MicroServiceNameStateEnum stateToChange)
    {
        throw new MicroServiceNameEx($"Is not possible to change the state from {Enum.GetName(State)} to {Enum.GetName(stateToChange)}.");
    }
}

public enum MicroServiceNameStateEnum : byte
{
    Created,
    Updated,
    Deleted
}