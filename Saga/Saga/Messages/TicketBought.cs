using Saga.BusinessLogic;

namespace Saga.Messages
{
    public class TicketBought
    {
        public TicketBought(DTO dto)
        {
            DTO = dto;
        }

        public DTO DTO { get; }
    }
}
