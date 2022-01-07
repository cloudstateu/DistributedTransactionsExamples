using EventChoreography.Messages;
using MassTransit;

namespace EventChoreography.BusinessLogic
{
    public class HotelService
    {
        private readonly IBus _bus;

        public HotelService(IBus bus)
        {
            _bus = bus;
        }
            
        public Task BookHotel(DTO dto)
        {
            if (dto.ShouldFail)
            {
                _bus.Publish(new HotelBookingFailed());
            }
            else
            {
                _bus.Publish(new HotelBooked());
            }           

            return Task.CompletedTask;
        }
    }
}
