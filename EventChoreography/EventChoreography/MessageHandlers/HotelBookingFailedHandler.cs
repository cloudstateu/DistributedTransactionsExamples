using EventChoreography.BusinessLogic;
using EventChoreography.Messages;
using MassTransit;

namespace EventChoreography.MessageHandlers
{
    public class HotelBookingFailedHandler : IConsumer<HotelBookingFailed>
    {
        private readonly FlightService _flightService;

        public HotelBookingFailedHandler(FlightService flightService)
        {
            _flightService = flightService;
        }
        public Task Consume(ConsumeContext<HotelBookingFailed> context)
        {
            Console.WriteLine($"Message: {context.Message.GetType().Name}");

            _flightService.CancelFlight();
            return Task.CompletedTask;
        }
    }
}
