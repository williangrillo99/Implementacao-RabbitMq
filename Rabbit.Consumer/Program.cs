// See https://aka.ms/new-console-template for more information
using Rabbit.Model.Entity;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

Console.WriteLine("Hello, World!");
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

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var json = Encoding.UTF8.GetString(body);

        RabbitMensagem mensagem = JsonSerializer.Deserialize<RabbitMensagem>(json);

        Console.WriteLine($"Titulo: {mensagem.Titulo}; Texto={mensagem.Texto}; Id={mensagem.Id}");
    };
    channel.BasicConsume(queue: "rabbitMensagesQueue",
                         autoAck: true,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}
    