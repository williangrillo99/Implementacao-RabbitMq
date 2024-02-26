using Rabbit.Model.Entity;
using Rabbit.Repositories.Interfaces;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client;

namespace Rabbit.Repositories
{
    public class RabbitMensagemRepository : IRabbitMensagemRepository
    {
        public void SedMensagem(RabbitMensagem rabbitMensagem)
        {
         
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    UserName = "admin",
                    Password = "123456"
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "rabbitMensagesQueue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    string json = JsonSerializer.Serialize(rabbitMensagem);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "rabbitMensagesQueue",
                                         basicProperties: null,
                                         body: body);
                }
           

        }
    }
}
