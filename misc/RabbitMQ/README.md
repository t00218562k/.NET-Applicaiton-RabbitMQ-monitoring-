## RabbitMQ terminology
Quick summary of key concepts and terms.
Original source https://www.cloudamqp.com/blog/RabbitMQ-and-AMQP-concepts-glossary.html


## Acknowledgements (Consumer Acknowledgements, Ack, Delivery Acknowledgements)
When RabbitMQ delivers a message to a consumer, it needs to know when to consider the message successfully sent. An ack will acknowledge one or more messages, which tells RabbitMQ that a message/messages has been handled. More information can be found here: https://www.rabbitmq.com/amqp-0-9-1-reference.html#basic.ack

## AMQP
RabbitMQ was originally developed to support AMQP 0-9-1 (Advanced Message Queuing Protocol) which is the "core" protocol supported by the RabbitMQ broker.

## Binding
A binding is a "link" that you set up to bind a queue to an exchange.

## Channel
A channel is a virtual connection inside a connection. When you are publishing or consuming messages from a queue - it's all done over a channel.

## Confirms (Publisher Confirms, Publisher Acknowledgements)
Publisher confirms indicate that messages have been received by RabbitMQ.

## Delivery tag
The Delivery tag uniquely identifies the delivery on a channel. If the delivery tag is set to 1, multiple messages can be acknowledged with a single method. If set to zero, the delivery tag refers to a single message.

## Connection
A connection is a TCP connection between your application and the RabbitMQ broker.

## Consumer
A Consumer is the application that receives the messages from the message queue.
![plot](workflow-rabbitmq.png)

## Exchange
An exchange is responsible for the routing of the messages to the different queues. An exchange accepts messages from the producer application and routes them to message queues with help of header attributes, bindings, and routing keys.

In RabbitMQ, there are four different types of exchange that routes the message differently using different parameters and bindings setups. Read more about different routing types here: RabbitMQ Exchanges, routing keys and bindings

##  Message queue
message queue
A message queue is a queue of messages sent between applications. It allow applications to communicate by sending messages to each other.
![plot](message-queue-small.png)

## Negative Acknowledgment, Nack
Nack is a negative acknowledge, that tells RabbitMQ that the message was not handled as expected. A nack:ed message is by default sent back into the queue. More information can be found here: https://www.rabbitmq.com/amqp-0-9-1-reference.html#basic.nack

## Producer, publisher
A Producer is the application that is sending the messages to the message queue.

## Protocol, Multi-protocol
The protocol defines the communication between the client and the server and has no impact on a message itself. One protocol can be used when publishing and you can consume using another protocol.

RabbitMQ allows clients to connect over a range of different open and standardized protocols such as AMQP, HTTP, STOMP, MQTT and WebSockets/Web-Stomp.

## Queue
A queue is the buffer that stores messages in the message broker.

## RabbitMQ
RabbitMQ is a message queueing software called a message broker or queue manager. It is a software where queues can be defined, applications may connect to the queue and transfer a message onto it.

## Routing key
The routing key is a message attribute. The exchange might look at this key when deciding how to route the message to queues (depending on exchange type). The routing key is like an address for the message.

## Users
It is possible to connect to RabbitMQ with a given username and password. Every user can be assigned permissions such as rights to read, write and configure privileges within the instance. Users can also be assigned permissions to specific virtual hosts.

## Vhost, virtual host
A Virtual host provide a way to segregate applications using the same RabbitMQ instance. Different users can have different access privileges to different vhost and queues and exchanges can be created so they only exists in one vhost.