using EventChoreography.BusinessLogic;
using EventChoreography.Messages;
using MassTransit;

namespace EventChoreography.MessageHandlers
{
    public class FlightBookingFailedHandler : IConsumer<FlightBookingFailed>
    {
        private readonly TicketService _ticketService;

        public FlightBookingFailedHandler(TicketService ticketService)
        {;
            _ticketService = ticketService;
        }
        public Task Consume(ConsumeContext<FlightBookingFailed> context)
        {
            Console.WriteLine($"Message: {context.Message.GetType().Name}");

            _ticketService.ReturnTicket();
            return Task.CompletedTask;
        }
    }
}
