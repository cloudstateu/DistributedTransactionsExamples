using Chronicle;
using Saga.Messages;

namespace Saga.BusinessLogic
{
    public class TicketService
    {
        private readonly ISagaCoordinator _sagaCoordinator;

        public TicketService(ISagaCoordinator sagaCoordinator)
        {
            _sagaCoordinator = sagaCoordinator;
        }

        public Task ReturnTicket()
        {
            _sagaCoordinator.ProcessAsync(new TicketReturned(), null);
            return Task.CompletedTask;
        }

        public Task BuyTicket(DTO dto, ISagaContext context)
        {
            _sagaCoordinator.ProcessAsync(new TicketBought(dto), context);
            return Task.CompletedTask;
        }
    }
}
