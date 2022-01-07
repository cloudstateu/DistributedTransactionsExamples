using EventChoreography.BusinessLogic;
using EventChoreography.Messages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace EventChoreography.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {
        private readonly ILogger<TripController> _logger;
        private readonly IBus _bus;

        public TripController(ILogger<TripController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpGet(nameof(Order))]
        public void Order()
        {
            _bus.Publish(new TripOrdered(new DTO()));
        }

        [HttpGet(nameof(OrderWithException))]
        public void OrderWithException()
        {
            _bus.Publish(new TripOrdered(new DTO(shouldFail: true)));
        }
    }
}