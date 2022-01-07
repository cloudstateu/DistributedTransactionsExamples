using Chronicle;
using Saga.Messages;

namespace Saga.BusinessLogic
{
    public class FlightService
    {
        private readonly ISagaCoordinator _sagaCoordinator;

        public FlightService(ISagaCoordinator sagaCoordinator)
        {
            _sagaCoordinator = sagaCoordinator;
        }

        public Task CancelFlight(ISagaContext context)
        {
            return Task.CompletedTask;
        }

        public Task BookFlight(DTO dto, ISagaContext context)
        {
            _sagaCoordinator.ProcessAsync(new FlightBooked(dto), context);
            return Task.CompletedTask;
        }
    }
}
