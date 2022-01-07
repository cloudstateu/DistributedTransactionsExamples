using EventChoreography.BusinessLogic;
using EventChoreography.Messages;
using MassTransit;

namespace EventChoreography.MessageHandlers
{
    public class TicketBoughtHandler : IConsumer<TicketBought>
    {
        private readonly FlightService _flightService;

        public TicketBoughtHandler(FlightService flightService)
        {
            _flightService = flightService;
        }
        public Task Consume(ConsumeContext<TicketBought> context)
        {
            Console.WriteLine($"Message: {context.Message.GetType().Name}");

            _flightService.BookFlight(context.Message.DTO);            
            return Task.CompletedTask;
        }
    }
}
