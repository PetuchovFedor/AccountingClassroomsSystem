using ClassroomService.Dtos;
using ClassroomService.EventProcessor;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace ClassroomService.MessageBusSubscriber
{
    public class MessageBusSubscriber : BackgroundService
    {
        private readonly IEventProcessor _eventProcessor;
        private IConnection _connection;
        private IModel _channel;
        public MessageBusSubscriber(IConfiguration configuration, IEventProcessor eventProcessor) 
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
            _eventProcessor = eventProcessor;
        }
        public override void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
            base.Dispose();
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            ConfigureQueue("university_building_exchange", "add_route", async (string msg) => 
            { 
                var dto = JsonSerializer.Deserialize<BuildingCreateDto>(msg);
                await _eventProcessor.ProcessCreateEvent(dto);
            });
            ConfigureQueue("university_building_exchange", "update_route", async (string msg) =>
            {
                var dto = JsonSerializer.Deserialize<BuildingUpdateDto>(msg);
                await _eventProcessor.ProcessUpdateEvent(dto);
            });
            ConfigureQueue("university_building_exchange", "delete_route", async (string msg) =>
            {
                var dto = JsonSerializer.Deserialize<Guid>(msg);
                await _eventProcessor.ProcessDeleteEvent(dto);
            });
            return Task.CompletedTask;
        }
        private void ConfigureQueue(string exchangeName, string route, Func<string, Task> callback)
        {
            _channel.ExchangeDeclare(exchangeName, ExchangeType.Topic);
            var queueName = _channel.QueueDeclare(exclusive: false).QueueName;
            _channel.QueueBind(queueName, exchangeName, route, null);
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await callback(message);
            };

            _channel.BasicConsume(queue: queueName,
                                  autoAck: true,
                                  consumer: consumer);
        }       
    }
}
