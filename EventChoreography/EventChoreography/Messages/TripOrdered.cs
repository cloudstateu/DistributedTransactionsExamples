using EventChoreography.BusinessLogic;

namespace EventChoreography.Messages
{
    public class TripOrdered : BaseMessage
    {
        public TripOrdered(DTO dto)
        {
            DTO = dto;
        }

        public DTO DTO { get; }
    }
}