## RabbitMQ terminology
Quick summary of key concepts and terms.
Original source https://www.cloudamqp.com/blog/RabbitMQ-and-AMQP-concepts-glossary.html


### Clustering 
Clustering allows multiple nodes to work together as a single logical broker, providing increased scalability, availability, and fault tolerance.

# Types of clustering
1. Master-slave clustering: In this configuration, one node acts as the master and handles all incoming connections and messages, while the other nodes act as slaves and replicate the master's state. This configuration provides increased availability, as the slaves can take over if the master goes down.
1. Peer-to-peer clustering: In this configuration, all nodes are equal and handle connections and messages independently. This allows for load balancing and increased scalability, but does not provide the same level of availability as master-slave clustering.
1. Distributed queues: In this configuration, queues are mirrored across multiple nodes in the cluster, allowing for increased availability and fault tolerance. This can be used in combination with either master-slave or peer-to-peer clustering.
1. Shovels and Federation: These are plugins that allow for messages to be moved between clusters or to external systems, providing an additional layer of scalability and flexibility.

1. High-Availability Queues: These queues ensure that messages are never lost even in case of node failure. This type of clustering is also known as "Active-Passive" clustering as it gives active-passive replication of queues.

# Single logical broker
A single logical broker in the context of RabbitMQ is a single instance of the RabbitMQ server software that is responsible for managing and distributing messages within a message queue. A logical broker can handle multiple connections, queues, and exchanges, and can be configured to run on a single physical machine or across multiple machines in a cluster. It can also handle the persistence of messages and can be configured to replicate messages to other brokers for redundancy and high availability.

# How mirrored queues pass messages
Mirrored queues in RabbitMQ are used to provide increased availability by replicating messages across multiple brokers in a cluster. The messages are passed to the mirrored queues in the same way as they would be passed to a regular queue, but they are then replicated to one or more additional brokers, creating a copy of the message on each broker.
When a message is delivered to a mirrored queue, it is first delivered to the "master" queue, which then replicates the message to one or more "slave" queues. The master queue is the one that clients connect to.
If the master queue goes down, one of the slave queues will automatically be promoted to become the new master. This allows for a seamless failover, ensuring that messages are still delivered and queues remain available even in the event of a failure.The mirrored queues pass the messages by replicating the messages to multiple brokers, so that if one broker fails, the message can be still obtained from another broker

# Scalability, Availability, and Fault-tolerance
in RabbitMQ, nodes refer to individual instances of the broker software that are connected together to form a cluster. The use of multiple nodes allows for increased scalability, availability, and fault tolerance in several ways:

Scalability:
+ By adding more nodes to a cluster, the system can handle more connections, queues, and messages.
+ Each node can handle a subset of the traffic, allowing the overall system to scale horizontally as the load increases.

Availability:
+ By having multiple nodes in a cluster, if one node goes down, the other nodes can still handle the traffic, ensuring that the system remains available.
+ Mirrored queues can be used to replicate messages across multiple nodes, so that if one node goes down, the messages can still be retrieved from another node.

Fault tolerance:
+ By having multiple nodes in a cluster, if one node goes down, the other nodes can still handle the traffic, ensuring that the system remains available.
+ RabbitMQ also has built-in support for handling network partitions, which can occur when the connections between nodes are lost. This allows the nodes to continue working even when they can't communicate with each other, and to automatically recover when the connections are restored.

In summary, the use of multiple nodes in a RabbitMQ cluster allows for increased scalability by handling more connections and messages, increased availability by providing redundancy and failover, and increased fault tolerance by handling network partitions and other failure scenarios.

# Can each node in a cluster have its own queues or designated queues?
In a RabbitMQ cluster, each node can have its own queues or be designated to handle specific queues.
Each node in a cluster can have its own independent queues, which are only local to that node and are not replicated to other nodes. This can be useful for managing resources or for handling specific types of traffic.
Alternatively, queues can be designated to specific nodes in a cluster, so that all messages for that queue are only handled by that node. This can be useful for load balancing or for isolating specific queues for monitoring or management.
RabbitMQ also allows for mirrored queues, where a queue is replicated across multiple nodes in a cluster. This allows for increased availability, as messages can still be retrieved from another node if one node goes down.
In a cluster, it's also possible to use policies to assign certain queues to nodes, so that all messages for a given queue are handled by the same node, ensuring that the messages are delivered in order, and also the messages are not lost. This can be useful when you want to isolate certain queues to handle specific types of traffic.
In summary, each node in a RabbitMQ cluster can have its own independent queues, be designated to handle specific queues, or be used for mirrored queues for increased availability.
