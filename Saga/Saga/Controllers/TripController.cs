using Chronicle;
using Saga.BusinessLogic;
using Saga.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Saga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {
        private readonly ILogger<TripController> _logger;
        private readonly ISagaCoordinator _sagaCoordinator;
        private readonly ISagaContext _context;

        public TripController(ILogger<TripController> logger, ISagaCoordinator sagaCoordinator)
        {
            _logger = logger;
            _sagaCoordinator = sagaCoordinator;
            _context = SagaContext.Create().WithSagaId(SagaId.NewSagaId()).Build();
        }

        [HttpGet(nameof(Order))]
        public void Order()
        {
            _sagaCoordinator.ProcessAsync(
                new TripOrdered(new DTO()),
                _context);
        }

        [HttpGet(nameof(OrderWithException))]
        public void OrderWithException()
        {
            _sagaCoordinator.ProcessAsync(
                new TripOrdered(new DTO(shouldFail: true)),
                _context);
        }
    }
}