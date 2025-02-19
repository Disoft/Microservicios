using Customer.Api.Application.Interfaces.Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Customer.Api.Infrastructure.Messaging
{
    public class RabbitMQPublisher : IMessagePublisher
    {
        private readonly string _hostname;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;

        public RabbitMQPublisher(IConfiguration configuration)
        {
            var rabbitMQConfig = configuration.GetSection("RabbitMQ");
            _hostname = rabbitMQConfig["Host"];
            _queueName = rabbitMQConfig["QueueName"];
            _username = rabbitMQConfig["Username"];
            _password = rabbitMQConfig["Password"];
        }

        public void Publish<T>(T message)
        {
            var factory = new RabbitMQ.Client.ConnectionFactory()
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var messageBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish(exchange: "",
                                 routingKey: _queueName,
                                 basicProperties: null,
                                 body: messageBody);
        }
    }
}
