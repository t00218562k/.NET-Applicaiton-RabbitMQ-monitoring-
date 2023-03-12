using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

// create a new connection factory and configure it to connect to the RabbitMQ server on local host
var factory = new ConnectionFactory { HostName = "localhost" };

// create a new connecetion to the server using the factory
using var connection = factory.CreateConnection();

// create a new channel from the connection
using var channel = connection.CreateModel();

var replyQueue = channel.QueueDeclare(queue: "", exclusive: true);

channel.QueueDeclare("request-queue", exclusive: false);

// create a new event-based consumer
var consumer = new EventingBasicConsumer(channel);

// set the received event to handle incoming messages
consumer.Received += (model, ea) =>
{
    // convert the message body from binary to string
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Reply Received: {message}");
};

// start consuming messages from the queue
channel.BasicConsume(queue: replyQueue.QueueName, autoAck: false, consumer: consumer);

var message = "can i request a reply";
var body = Encoding.UTF8.GetBytes(message);

var properties = channel.CreateBasicProperties();
properties.ReplyTo = replyQueue.QueueName;
properties.CorrelationId = Guid.NewGuid().ToString();

channel.BasicPublish("", "request-queue", properties, body);

Console.WriteLine($"Sending request: {properties.CorrelationId}");

// wait for a key press to exit
Console.ReadKey();