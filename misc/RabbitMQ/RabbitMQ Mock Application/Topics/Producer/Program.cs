using System;
using System.Text;
using RabbitMQ.Client;

// create a new connection factory and configure it to connect to the RabbitMQ server on localhost
var factory = new ConnectionFactory { HostName = "localhost" };

// create a new connection to the server using the factory 
using var connection = factory.CreateConnection();

// create a new channel from the connection
using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "myTopicexchange", type: ExchangeType.Topic);

// message to be published
var eu = "This message is going to be routed to EU only";
var us = "This message is going to be routed to US only";
var allConsumers = "This message is going to be routed to NZ payments";

// encode the message to a byte array
var encodedEU = Encoding.UTF8.GetBytes(eu);
var encodedUS = Encoding.UTF8.GetBytes(us);
var encodedallConsumers = Encoding.UTF8.GetBytes(allConsumers);


channel.BasicPublish("myTopicexchange", "US.airline.lodging", null, encodedUS);
channel.BasicPublish("myTopicexchange", "EU.airline.checking", null, encodedEU);
channel.BasicPublish("myTopicexchange", "NZ.airline.payments", null, encodedallConsumers);

// print the original message to the  console
Console.WriteLine("Publish messages");