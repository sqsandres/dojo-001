using Azure.Messaging.ServiceBus;

namespace Dojo.Bakery.BuildingBlocks.EventBus
{
    public class EventBusInfo
    {
        public string ClientName { get; set; }
        // connection string to your Service Bus namespace
        public string BusConnectionString { get; set; }
        // name of your Service Bus queue
        public string QueueName { get; set; }
        public EventBusInfo(string busConnectionString, string clientName)
        {
            BusConnectionString = busConnectionString;
            QueueName = "events";
            ClientName = clientName;
        }
        public ServiceBusClient Client()
        {
            return new ServiceBusClient(BusConnectionString);
        }
        public ServiceBusSender Sender(ServiceBusClient client)
        {
            return client.CreateSender(QueueName);
        }
    }
}
