using System;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

// create a new connection factory and configure it to connect to the RabbitMQ server on localhost
var factory = new ConnectionFactory { HostName = "localhost" };

// create a new connection to the server using the factory 
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


var messageId = 1;

while(true)
{
    var publishing = 3;

    // message to be published
    var message = $"Hello World for the {messageId}th time";

    // encode the message to a byte array
    var encodedMessage = Encoding.UTF8.GetBytes(message);

    // publish the message to the "letterbox" queue using the  default exchange
    channel.BasicPublish("", "letterbox", null, encodedMessage);

    // print the original message to the  console
    Console.WriteLine($"Publish message: {message}");

    Task.Delay(TimeSpan.FromSeconds(publishing)).Wait();

    messageId++;
}