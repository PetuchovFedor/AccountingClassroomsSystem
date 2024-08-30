using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace UniversityBuildingService.MessageBusClient
{
    public class MessageBusClient : IMessageBusClient, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        public MessageBusClient(IConfiguration configuration) 
        {
            var hostName = configuration.GetValue<string>("RabbitHost");
            var port = int.Parse(configuration.GetValue<string>("RabbitPort"));
            var factory = new ConnectionFactory
            {
                HostName = hostName,
                Port = port,
                UserName = "guest",
                Password = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }

        public void SendMessage<T>(string exchangeName, string routingKey, T msg)
        {
            _channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Topic);
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(msg));
            _channel.BasicPublish(exchange: exchangeName,
                routingKey: routingKey, body: body, basicProperties: null);            
        }
    }
}
