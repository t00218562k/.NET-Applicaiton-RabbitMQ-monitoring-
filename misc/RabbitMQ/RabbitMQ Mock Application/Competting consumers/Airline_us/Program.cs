using System;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

// create a new connection factory and configure it to connect to the RabbitMQ server on local host
var factory = new ConnectionFactory { HostName = "localhost" };

// create a new connecetion to the server using the factory
using var connection = factory.CreateConnection();

// create a new channel from the connection
using var channel = connection.CreateModel();

// declare the "letterbox" queue
channel.QueueDeclare(
    queue: "letterbox",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);

channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

// create a new event-based consumer
var consumer = new EventingBasicConsumer(channel);

var random = new Random();

// set the received event to handle incoming messages
consumer.Received += (model, ea) =>
{
    var processingTime = 6;

    // convert the message body from binary to string
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Airline US message received: {message} will take {processingTime}");

    Task.Delay(TimeSpan.FromSeconds(processingTime)).Wait();

    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
};

// start consuming messages from the queue
channel.BasicConsume(queue: "letterbox", autoAck: false, consumer: consumer);

// wait for a key press to exit
Console.ReadKey();