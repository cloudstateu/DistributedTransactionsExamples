using Saga.BusinessLogic;

namespace Saga.Messages
{
    public class FlightBooked
    {
        public FlightBooked(DTO dto)
        {
            DTO = dto;
        }

        public DTO DTO { get; }
    }
}
