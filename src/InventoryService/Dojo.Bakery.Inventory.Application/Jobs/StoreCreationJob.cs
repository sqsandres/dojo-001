using Dojo.Bakery.BuildingBlocks.EventBus;

namespace Dojo.Bakery.Inventory.Application.Jobs
{
    public class StoreCreationJob : ServiceBusMessage
    {
        public static string JobName = "StoreCreation";
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public StoreCreationJob() : base(JobName)
        {

        }
    }
}
