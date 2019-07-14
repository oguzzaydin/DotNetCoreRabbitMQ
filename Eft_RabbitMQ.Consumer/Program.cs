using System;
using System.Text;
using Database;
using Database.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Eft_RabbitMQ.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
           EftContext context = new EftContext();
           var factory = new ConnectionFactory() {HostName = "localhost", UserName = "admin", Password = "pass"};
           using (IConnection connection = factory.CreateConnection())
           using (IModel channel = connection.CreateModel())
           {
              
               var consumer = new EventingBasicConsumer(channel);
               consumer.Received += (model, ea) =>
               {
                   var body = ea.Body;
                   var message = Encoding.UTF8.GetString(body);
                   SendingEftModel sendingEftModel = JsonConvert.DeserializeObject<SendingEftModel>(message); 
                   context.Send(sendingEftModel);
                   Console.WriteLine($" {sendingEftModel.FromId} - {sendingEftModel.Money}₺ --> {sendingEftModel.ToId}");
               };
               channel.BasicConsume(queue: "Eft", autoAck: true,consumer: consumer); 

               Console.WriteLine("Eft kuyruğuna bağlantı başarılı. Dinleniyor...");
               Console.ReadKey();
           }
        }
    }
}
