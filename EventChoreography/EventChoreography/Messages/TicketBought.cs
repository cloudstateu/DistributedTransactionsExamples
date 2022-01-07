using EventChoreography.BusinessLogic;

namespace EventChoreography.Messages
{
    public class TicketBought : BaseMessage
    {
        public TicketBought(DTO dto)
        {
            DTO = dto;
        }

        public DTO DTO { get; }
    }
}
