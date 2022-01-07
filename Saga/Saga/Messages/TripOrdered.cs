using Saga.BusinessLogic;

namespace Saga.Messages
{
    public class TripOrdered
    {
        public TripOrdered(DTO dto)
        {
            DTO = dto;
        }

        public DTO DTO { get; }
    }
}