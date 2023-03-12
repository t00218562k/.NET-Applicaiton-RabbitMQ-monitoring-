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

channel.ExchangeDeclare(exchange: "myrootingexchange", ExchangeType.Direct);

var queueName = channel.QueueDeclare().QueueName;

channel.QueueBind(queue: queueName, exchange: "myrootingexchange", routingKey: "others");

// create a new event-based consumer
var consumer = new EventingBasicConsumer(channel);

// set the received event to handle incoming messages
consumer.Received += (model, ea) =>
{
    // convert the message body from binary to string
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Others: {message}");
};

// start consuming messages from the queue
channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

// wait for a key press to exit
Console.ReadKey();