using EventChoreography.BusinessLogic;
using EventChoreography.Messages;
using MassTransit;

namespace EventChoreography.MessageHandlers
{
    public class TripOrderedHandler : IConsumer<TripOrdered>
    {
        private readonly TicketService _ticketService;

        public TripOrderedHandler(TicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public Task Consume(ConsumeContext<TripOrdered> context)
        {
            Console.WriteLine($"Message: {context.Message.GetType().Name}");

            _ticketService.BuyTicket(context.Message.DTO);
            return Task.CompletedTask;
        }
    }
}
