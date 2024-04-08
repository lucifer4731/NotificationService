using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NotificationService.Application.RabitMQ
{
    public class MessageReceiver : IMessageReceiver
    {
        private readonly string _queueName;
        private readonly ConnectionFactory _connectionFactory;

        public MessageReceiver(string queueName, string hostName, string userName, string password)
        {
            _queueName = queueName;
            _connectionFactory = new ConnectionFactory
            {
                HostName = hostName,
                UserName = userName,
                Password = password
            };

        }
        public async Task<RabbitMQMessage> ReceiveMessage()
        {
            using var connection = _connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            var tcs = new TaskCompletionSource<RabbitMQMessage>();

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var rabbitMQMessage = JsonConvert.DeserializeObject<RabbitMQMessage>(message);

                tcs.SetResult(rabbitMQMessage);
            };

            channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            return await tcs.Task;
        }

    }
}
