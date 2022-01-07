using EventChoreography.BusinessLogic;

namespace EventChoreography.Messages
{
    public class FlightBooked : BaseMessage
    {
        public FlightBooked(DTO dto)
        {
            DTO = dto;
        }

        public DTO DTO { get; }
    }
}
