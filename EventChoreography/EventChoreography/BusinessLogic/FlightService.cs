using EventChoreography.Messages;
using MassTransit;

namespace EventChoreography.BusinessLogic
{
    public class FlightService 
    {
        private readonly IBus _bus;

        public FlightService(IBus bus)
        {
            _bus = bus;
        }

        public Task CancelFlight()
        {
            _bus.Publish(new FlightBookingFailed());
            return Task.CompletedTask;
        }

        public Task BookFlight(DTO dto)
        {
            _bus.Publish(new FlightBooked(dto));
            return Task.CompletedTask;
        }
    }
}
