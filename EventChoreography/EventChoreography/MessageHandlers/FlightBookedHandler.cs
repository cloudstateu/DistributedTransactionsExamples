using EventChoreography.BusinessLogic;
using EventChoreography.Messages;
using MassTransit;

namespace EventChoreography.MessageHandlers
{
    public class FlightBookedHandler : IConsumer<FlightBooked>
    {
        private readonly HotelService _hotelService;

        public FlightBookedHandler(HotelService hotelService)
        {
            _hotelService = hotelService;
        }
        public Task Consume(ConsumeContext<FlightBooked> context)
        {
            Console.WriteLine($"Message: {context.Message.GetType().Name}");

            _hotelService.BookHotel(context.Message.DTO);            
            return Task.CompletedTask;
        }
    }
}
