using EventChoreography.Messages;
using MassTransit;

namespace EventChoreography.BusinessLogic
{
    public class TicketService
    {
        private readonly IBus _bus;

        public TicketService(IBus bus)
        {
            _bus = bus;
        }

        public Task ReturnTicket()
        {
            _bus.Publish(new TicketReturned());
            return Task.CompletedTask;
        }

        public Task BuyTicket(DTO dto)
        {
            _bus.Publish(new TicketBought(dto));
            return Task.CompletedTask;
        }
    }
}
