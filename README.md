# .NET-Applicaiton-RabbitMQ-monitoring-
.NET, API, RabbitMQ, Prometheus-net (custom metrics), Prometheus, Grafana, Terraform, GraffanaAPI, Docker, 

# Overview
This is a .NET7 application that uses RabbitMQ to implement the publish/subscribe messaging pattern. The application leverages the RabbitMQ .NET client library to connect to the RabbitMQ server and interact with the message broker. The publish/subscribe pattern allows messages to be published to a topic exchange and routed to multiple queues based on a defined topic routing key. This enables a flexible and efficient way to handle different types of messages and distribute them to the appropriate subscribers.
Publishers can send messages to the topic exchange using the defined routing key, and subscribers can consume messages from the queues they are interested in. The RabbitMQ server ensures that messages are delivered to all subscribed consumers in a reliable and efficient manner.

In addition, the project utilizes the following technologies:

- API: The application provides an API that allows clients to interact with the messaging system and send/receive messages. The API is built using .NET7.
- Prometheus-net (custom metrics): Prometheus-net is used to collect custom metrics related to the messaging system's performance and health. These metrics are exposed via the API.
- Prometheus: Prometheus is a monitoring system that is used to collect, store, and query metrics. Prometheus is configured to scrape metrics from the API and store them for analysis.
- Grafana: Grafana is a tool that is used to visualize metrics collected by Prometheus. Grafana is configured to connect to the Prometheus instance and display relevant dashboards.
- Terraform: Terraform is used to manage the infrastructure required to run the messaging system. In this case it is used for the Grafana server.
- GrafanaAPI: The Grafana API is used to automate the creation and management of Grafana dashboards.

Additionally, the project is containerized using Docker to provide a consistent and isolated environment for the application and its dependencies. The Docker containers include the RabbitMQ server, API server, Prometheus server, and Grafana server. This allows for easy deployment and scaling of the messaging system. The use of Docker also ensures that the application can be run on any platform that supports Docker, providing increased portability and flexibility.

Overall, this project provides a robust and scalable messaging system that can be easily customized to meet the specific requirements of any application. The integration of additional technologies such as Prometheus, Grafana, and Terraform ensures that the messaging system is monitored, maintained, and deployed efficiently.

# Requirements
- .NET7
- RabbitMQ
- C#
- Prometheus
- Grafana
- Prometheus-net

# Tutorial
1. You can run rabbitmq, Pormetheus and Grafana using docker-compose file located in the misc/docker folder or you can run them on your local machine. If are running on the local machine and want RabbitMQ metrics you need to use the RabbitMQ exporter found in the db/prometheus/exporter. 
2. You can run the application by running the .sln file in the ide folder or by using dotner run command in the terminal.
3. there are files in the misc folder that explain how to use terform and alerts in Grafana.
