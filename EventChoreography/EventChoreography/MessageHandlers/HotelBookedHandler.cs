using EventChoreography.BusinessLogic;
using EventChoreography.Messages;
using MassTransit;

namespace EventChoreography.MessageHandlers
{
    public class HotelBookedHandler : IConsumer<HotelBooked>
    {
        private readonly PaymentService _paymentService;

        public HotelBookedHandler(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public Task Consume(ConsumeContext<HotelBooked> context)
        {
            Console.WriteLine($"Message: {context.Message.GetType().Name}");

            _paymentService.RediretToPayment();            
            return Task.CompletedTask;
        }
    }
}
