using Customer.Api.Application.Interfaces.Messaging;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Newtonsoft.Json;
using Customer.Api.Application.Events;
using System.Text;

namespace Customer.Api.Infrastructure.Messaging
{
    public class RabbitMQConsumer : BackgroundService, IMessageConsumer
    {
        private readonly string _hostname;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;

        public RabbitMQConsumer(IConfiguration configuration)
        {
            var rabbitMQConfig = configuration.GetSection("RabbitMQ");
            _hostname = rabbitMQConfig["Host"];
            _queueName = rabbitMQConfig["QueueName"];
            _username = rabbitMQConfig["Username"];
            _password = rabbitMQConfig["Password"];
        }

        public void Consume()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var data = JsonConvert.DeserializeObject<CustomerCreatedEvent>(message);

                Console.WriteLine($"[Received] {data?.Id}: {data?.Name}");
            };

            channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Consume();
            return Task.CompletedTask;
        }
    }
}
