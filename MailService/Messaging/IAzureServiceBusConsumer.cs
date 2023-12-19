namespace MailService.Messaging
{
    public interface IAzureServiceBusConsumer
    {
        //check service bus if it has email and send emails
        Task Start();

        //stop checking if it has messaging
        Task Stop();
    }
}
