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
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _eventProcessor = eventProcessor;
            //ConfigureQueue("university_building_exchange", "add_route");
            //ConfigureQueue("university_building_exchange", "add_route");

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
            ConfigureQueue("university_building_exchange", "add_route", AddProcessCallback);
            return Task.CompletedTask;
        }
        private void ConfigureQueue(string exchangeName, string route, Func<string, Task> callback)
        {
            _channel.ExchangeDeclare(exchangeName, ExchangeType.Topic);
            var queueName = _channel.QueueDeclare().QueueName;
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
        private async Task AddProcessCallback(string msg)
        {
            var dto = JsonSerializer.Deserialize<BuildingCreateDto>(msg);
            await _eventProcessor.ProcessCreateEvent(dto);
        }
    }
}
