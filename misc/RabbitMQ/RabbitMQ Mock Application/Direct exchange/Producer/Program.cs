using System;
using System.Text;
using RabbitMQ.Client;

// create a new connection factory and configure it to connect to the RabbitMQ server on localhost
var factory = new ConnectionFactory { HostName = "localhost" };

// create a new connection to the server using the factory 
using var connection = factory.CreateConnection();

// create a new channel from the connection
using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "myrootingexchange", type: ExchangeType.Direct);

// declare the "letterbox" queue
channel.QueueDeclare(
    queue: "letterbox",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);

// message to be published
var airline = "This message is going to be routed to all airlines";
var eu = "This message is going to be routed to EU only";
var us = "This message is going to be routed to US only";
var others = "This message is going to be routed to others";

// encode the message to a byte array
var encodedAirline = Encoding.UTF8.GetBytes(airline);
var encodedEU = Encoding.UTF8.GetBytes(eu);
var encodedUS = Encoding.UTF8.GetBytes(us);
var encodedOthers = Encoding.UTF8.GetBytes(others);


channel.BasicPublish("myrootingexchange", "airline", null, encodedAirline);
channel.BasicPublish("myrootingexchange", "USairline", null, encodedUS);
channel.BasicPublish("myrootingexchange", "EUairline", null, encodedEU);
channel.BasicPublish("myrootingexchange", "others", null, encodedOthers);

// print the original message to the  console
Console.WriteLine("Publish messages");