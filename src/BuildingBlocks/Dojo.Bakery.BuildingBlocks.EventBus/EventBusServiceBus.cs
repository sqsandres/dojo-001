using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Dojo.Bakery.BuildingBlocks.EventBus
{
    public class EventBusServiceBus
    {
        private EventBusInfo _conectionInfo;
        public EventBusServiceBus(EventBusInfo conectionInfo)
        {
            _conectionInfo = conectionInfo;
        }
        public async void Publish(ServiceBusMessage @event)
        {
            ServiceBusClient client = _conectionInfo.Client();
            ServiceBusSender sender = _conectionInfo.Sender(client);

            using (ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync())
            {
                string jsonMessage = JsonConvert.SerializeObject(@event);
                Byte[] body = Encoding.UTF8.GetBytes(jsonMessage);
                // try adding a message to the batch
                if (!messageBatch.TryAddMessage(new Azure.Messaging.ServiceBus.ServiceBusMessage(body)))
                {
                    // if it is too large for the batch
                    throw new Exception($"The message {@event} is too large to fit in the batch.");
                }
                try
                {
                    await sender.SendMessagesAsync(messageBatch);
                }
                finally
                {
                    // Calling DisposeAsync on client types is required to ensure that network
                    // resources and other unmanaged objects are properly cleaned up.
                    await sender.DisposeAsync();
                    await client.DisposeAsync();
                }
            }
        }

        public async void Subscribe(Func<ProcessMessageEventArgs, Task> MessageHandler)
        {
            ServiceBusClient client = _conectionInfo.Client();
            // create a processor that we can use to process the messages
            ServiceBusProcessor processor = client.CreateProcessor(_conectionInfo.QueueName, new ServiceBusProcessorOptions());
            processor.ProcessMessageAsync += MessageHandler;
            processor.ProcessErrorAsync += new Func<ProcessErrorEventArgs, Task>(args => {
                Console.WriteLine(args.Exception.ToString());
                return Task.CompletedTask;
            });
            await processor.StartProcessingAsync();
        }
    }
}
