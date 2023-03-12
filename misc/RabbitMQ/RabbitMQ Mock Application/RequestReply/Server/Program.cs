using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

// create a new connection factory and configure it to connect to the RabbitMQ server on localhost
var factory = new ConnectionFactory { HostName = "localhost" };

// create a new connection to the server using the factory 
using var connection = factory.CreateConnection();

// create a new channel from the connection
using var channel = connection.CreateModel();

channel.QueueDeclare("request-queue", exclusive: false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    Console.WriteLine($"Recieved request {ea.BasicProperties.CorrelationId}");

    var replyMessage = $"this is the rely: {ea.BasicProperties.CorrelationId}";

    var body = Encoding.UTF8.GetBytes(replyMessage);

    channel.BasicPublish("", ea.BasicProperties.ReplyTo, null, body);

};

channel.BasicConsume(queue: "request-queue", autoAck: true, consumer: consumer);

Console.ReadKey();