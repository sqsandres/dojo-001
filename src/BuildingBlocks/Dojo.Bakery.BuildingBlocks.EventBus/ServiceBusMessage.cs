namespace Dojo.Bakery.BuildingBlocks.EventBus
{
    public class ServiceBusMessage
    {
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public ServiceBusMessage()
        {

        }
        public ServiceBusMessage(string name)
        {
            Name = name;
            DateTime = DateTime.Now;
        }
        public override string ToString()
        {
            return $"Name:{Name} - DateTime:{DateTime}";
        }
    }
}
