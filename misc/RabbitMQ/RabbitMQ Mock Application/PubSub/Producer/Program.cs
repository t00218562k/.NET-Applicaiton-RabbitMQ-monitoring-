using System;
using System.Text;
using RabbitMQ.Client;

// create a new connection factory and configure it to connect to the RabbitMQ server on localhost
var factory = new ConnectionFactory { HostName = "localhost" };

// create a new connection to the server using the factory 
using var connection = factory.CreateConnection();

// create a new channel from the connection
using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "PubSub", type: ExchangeType.Fanout);

// message to be published
var message = $"Update sent";

// encode the message to a byte array
var encodedMessage = Encoding.UTF8.GetBytes(message);

// publish the message to the "letterbox" queue using the  default exchange
channel.BasicPublish(exchange: "PubSub", "", null, encodedMessage);

// print the original message to the  console
Console.WriteLine($"Publish message: {message}");
