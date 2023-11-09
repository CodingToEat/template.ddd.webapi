
using MicroServiceName.Dom.Seed;

namespace MicroServiceName.Dom.Agg
{
    public class MicroServiceNameHistoryAgg: Entity
    {
        private MicroServiceNameHistoryAgg(Guid id, Guid relatedId) : base(id)
        {
            Id = id;
            EventDateTime = DateTime.UtcNow;
            RelatedId = relatedId;
        }

        public Guid RelatedId { get; private set; }
        public MicroServiceNameEventEnum Event { get; private set; }
        public DateTime EventDateTime { get; private set; }

        public static MicroServiceNameHistoryAgg Create(Guid relatedId, MicroServiceNameEventEnum eventEnum)
        {
            var result = new MicroServiceNameHistoryAgg(Guid.NewGuid(), relatedId)
            {
                Event = eventEnum
            };
            return result;
        }
    }

    public enum MicroServiceNameEventEnum : byte
    {
        Create,
        Update,
        Delete
    }
}