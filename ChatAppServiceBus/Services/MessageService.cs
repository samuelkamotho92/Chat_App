using Azure.Messaging.ServiceBus;
using ChatAppServiceBus.Services.IService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChatAppServiceBus.Services
{
    public class MessageService : IMessage
    {
        private readonly string connectionString = "Endpoint=sb://chatappbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=hs2VtRunGPQkogvXutLmPjdPNif3vsjK6+ASbIZ4PwY=";
        ServiceBusClient client;
        ServiceBusSender sender;
        ServiceBusMessage theMessage;
        public async Task publishMessage(object message, string Topic_Queue_Name)
        {
            client = new ServiceBusClient(connectionString);
            sender = client.CreateSender(Topic_Queue_Name);
            var messageSent = JsonConvert.SerializeObject(message);
            theMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageSent)) {       
            //UNIQUE IDENTIFIER for message
            CorrelationId = Guid.NewGuid().ToString(),
            
            };
            //send message
            await sender.SendMessageAsync(theMessage);
            //free resource
            await sender.DisposeAsync();
        }
    }
}
