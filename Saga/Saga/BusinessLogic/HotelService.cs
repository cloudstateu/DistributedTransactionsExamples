using Chronicle;
using Saga.Messages;

namespace Saga.BusinessLogic
{
    public class HotelService
    {
        private readonly ISagaCoordinator _sagaCoordinator;

        public HotelService(ISagaCoordinator sagaCoordinator)
        {
            _sagaCoordinator = sagaCoordinator;
        }

        public Task CancelBooking()
        {
            return Task.CompletedTask;
        }

        public Task BookHotel(DTO dto, ISagaContext context)
        {
            try
            {
                BookHotelInternal(dto.ShouldFail);
                _sagaCoordinator.ProcessAsync(new HotelBooked(), context);

            }
            catch (Exception ex)
            {
                context.SagaContextError = new SagaContextError(ex);
                _sagaCoordinator.ProcessAsync(new HotelBookingFailed(), context);
            }

            return Task.CompletedTask;
        }

        private void BookHotelInternal(bool shouldFail)
        {
            if (shouldFail)
            {
                throw new Exception("Booking hotel failed");
            }
        }

    }
}
