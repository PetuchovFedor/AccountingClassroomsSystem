namespace UniversityBuildingService.MessageBusClient
{
    public interface IMessageBusClient
    {
        void SendMessage<T>(string exchangeName, string routingKey, T msg);
    }
}
