using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace EFT_RabbitMQ.Helpers
{
    public static class EftProducerHelper
    {
        public static void SendMoney(SendingEftModel model)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "pass"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Eft",
                    durable: false, 
                    exclusive: false, 
                    autoDelete: false,
                    arguments: null);

                string message = JsonConvert.SerializeObject(model);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",routingKey: "Eft",body: body);
            }
        }
    }
}
