using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

namespace Dojo.Bakery.Inventory.Application.Jobs
{
    public static class GeneralJobHandler
    {
        public static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string identifier = args.Identifier;
            string body = args.Message.Body.ToString();
            object? jsonMessage = JsonConvert.DeserializeObject(body);
            BuildingBlocks.EventBus.ServiceBusMessage serviceBusMessage = (BuildingBlocks.EventBus.ServiceBusMessage)jsonMessage;
            if (serviceBusMessage == null)
            {
                throw new Exception("Invalid message");
            }
            if (serviceBusMessage.Name == StoreCreationJob.JobName)
            {
                Console.WriteLine("Entro");
            }
            // complete the message. message is deleted from the queue. 
            await args.CompleteMessageAsync(args.Message);
        }
    }
}
