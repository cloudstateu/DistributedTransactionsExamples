using EventChoreography.BusinessLogic;
using EventChoreography.Messages;
using MassTransit;

namespace EventChoreography.MessageHandlers
{
    public class TicketReturnedHandler : IConsumer<TicketReturned>
    {
        private readonly NotificationService _notificationService;

        public TicketReturnedHandler(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public Task Consume(ConsumeContext<TicketReturned> context)
        {
            Console.WriteLine($"Message: {context.Message.GetType().Name}");

            _notificationService.NotifyOnCanceledTrip();
            return Task.CompletedTask;
        }
    }
}
