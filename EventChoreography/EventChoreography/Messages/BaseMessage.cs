using MassTransit;

namespace EventChoreography.Messages
{
    public class BaseMessage : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }
    }
}
