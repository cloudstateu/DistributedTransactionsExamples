using Chronicle;
using Saga.BusinessLogic;
using Saga.Messages;

namespace Saga.Sagas
{
    public class TripSagaData
    {
        public bool IsTicketBought { get; set; }
        public bool IsFlightBooked { get; set; }
        public bool IsHotelBooked { get; set; }
    }

    public class TripSaga :
        Chronicle.Saga<TripSagaData>,
        ISagaStartAction<TripOrdered>,
        ISagaAction<TicketBought>,
        ISagaAction<FlightBooked>,
        ISagaAction<FlightBookingFailed>,
        ISagaAction<HotelBooked>,
        ISagaAction<HotelBookingFailed>
    {
        private readonly TicketService _ticketService;
        private readonly FlightService _flightService;
        private readonly HotelService _hotelService;
        private readonly PaymentService _paymentService;
        private readonly NotificationService _notificationService;

        public TripSagaData TripSagaData { get; set; }

        public TripSaga(TicketService ticketService, FlightService flightService, HotelService hotelService, PaymentService paymentService, NotificationService notificationService)
        {
            _ticketService = ticketService;
            _flightService = flightService;
            _hotelService = hotelService;
            _paymentService = paymentService;
            _notificationService = notificationService;

            TripSagaData = new TripSagaData();
        }

        public Task HandleAsync(TripOrdered message, ISagaContext context)
        {
            Console.WriteLine($"handle: {message.GetType().Name}");

            _ticketService.BuyTicket(message.DTO, context);
            _flightService.BookFlight(message.DTO, context);
            _hotelService.BookHotel(message.DTO, context);

            return Task.CompletedTask;
        }

        public Task CompensateAsync(TripOrdered message, ISagaContext context)
        {
            Console.WriteLine($"compensate: {message.GetType().Name}");
            return _notificationService.NotifyOnCanceledTrip();
        }

        public Task HandleAsync(TicketBought message, ISagaContext context)
        {
            Console.WriteLine($"handle: {message.GetType().Name}");
            TripSagaData.IsTicketBought = true;
            return TryCompleteSaga();
        }

        public Task CompensateAsync(TicketBought message, ISagaContext context)
        {
            Console.WriteLine($"compensate: {message.GetType().Name}");
            return _ticketService.ReturnTicket();
        }

        public Task HandleAsync(FlightBooked message, ISagaContext context)
        {
            Console.WriteLine($"handle: {message.GetType().Name}");
            TripSagaData.IsFlightBooked = true;
            return TryCompleteSaga();
        }


        public Task CompensateAsync(FlightBooked message, ISagaContext context)
        {
            Console.WriteLine($"compensate: {message.GetType().Name}");
            return _flightService.CancelFlight(context);
        }

        public Task HandleAsync(FlightBookingFailed message, ISagaContext context)
        {
            Console.WriteLine($"handle: {message.GetType().Name}");
            Reject(context.SagaContextError.Exception);
            return Task.CompletedTask;
        }

        public Task CompensateAsync(FlightBookingFailed message, ISagaContext context)
        {
            Console.WriteLine($"compensate: {message.GetType().Name}");
            // for demo purposes this operation never fails :) 
            return Task.CompletedTask;
        }

        public Task HandleAsync(HotelBooked message, ISagaContext context)
        {
            Console.WriteLine($"handle: {message.GetType().Name}");
            TripSagaData.IsHotelBooked = true;
            return TryCompleteSaga();
        }

        public Task CompensateAsync(HotelBooked message, ISagaContext context)
        {
            Console.WriteLine($"compensate: {message.GetType().Name}");
            return _hotelService.CancelBooking();
        }

        public Task HandleAsync(HotelBookingFailed message, ISagaContext context)
        {
            Console.WriteLine($"handle: {message.GetType().Name}");
            Reject(context.SagaContextError.Exception);
            return Task.CompletedTask;
        }

        public Task CompensateAsync(HotelBookingFailed message, ISagaContext context)
        {
            Console.WriteLine($"compensate: {message.GetType().Name}");
            // for demo purposes this operation never fails :) 
            return Task.CompletedTask;
        }

        private Task TryCompleteSaga()
        {
            if (TripSagaData.IsFlightBooked &&
                TripSagaData.IsHotelBooked &&
                TripSagaData.IsTicketBought)
            {
                Complete();
                _paymentService.RediretToPayment();
            }

            return Task.CompletedTask;
        }
    }
}
