namespace Saga.BusinessLogic
{
    public class PaymentService
    {
        public Task RediretToPayment()
        {
            Console.WriteLine($"Redirected to payment");
            return Task.CompletedTask;
        }
    }
}
