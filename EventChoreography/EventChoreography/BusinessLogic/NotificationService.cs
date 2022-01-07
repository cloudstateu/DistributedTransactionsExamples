namespace EventChoreography.BusinessLogic
{
    public class NotificationService
    {
        public Task NotifyOnCanceledTrip()
        {
            Console.WriteLine($"Notified on canceled trip");
            return Task.CompletedTask;
        }
    }
}
