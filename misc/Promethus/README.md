
## Prometheus
Prometheus is an open-source monitoring and alerting system. It is used to collect metrics from various systems and services, and then allows users to query and visualize that data.
Prometheus is built around the concept of metrics and labels. Metrics are the values that are being tracked, such as the number of requests per second to a web server. Labels are key-value pairs that can be added to metrics to provide more context, such as the hostname of the server the metric is coming from. This allows for powerful querying and aggregation of metrics.
Prometheus uses a pull-based architecture, where the Prometheus server periodically scrapes metrics from exporters. Exporters are special-purpose programs that collect metrics from a specific service or application and expose them in a format that Prometheus can scrape.
Prometheus also has a built-in alerting system that can be used to trigger alerts based on the values of metrics. Alerts can be sent to various endpoints, such as email, slack, or PagerDuty.
Prometheus also provides a web UI for querying and visualizing metrics, as well as a powerful query language called PromQL that can be used to filter and aggregate metrics.
Prometheus is commonly used in conjunction with other open-source tools such as Grafana, which is a visualization tool that can be used to create dashboards and alerts based on Prometheus metrics.
Overall Prometheus is a powerful, flexible monitoring and alerting system that is widely used in cloud-native and containerized environments.


## Monitoring systems
Monitoring systems are tools and technologies used to collect, analyse, and report on data related to the performance and health of various systems and services. These systems are critical for ensuring the availability and reliability of IT infrastructure and can help to identify and troubleshoot issues before they become critical.
There are several types of monitoring systems, each with their own specific use cases and capabilities. Some of the most common types include:
1.	Network monitoring systems: These systems are used to monitor the performance and availability of network devices such as routers, switches, and firewalls. They can provide information such as network traffic, packet loss, and latency.
2.	Server monitoring systems: These systems are used to monitor the performance and availability of servers, including hardware and software metrics such as CPU usage, memory usage, and disk space.
3.	Application monitoring systems: These systems are used to monitor the performance and availability of specific applications, such as web servers or databases. They can provide detailed information about the performance of specific components of an application, such as response times, error rates, and throughput.
4.	Infrastructure monitoring systems: These systems are used to monitor the performance and availability of the underlying infrastructure, such as virtual machines, containers, and storage. They can provide detailed information about the performance of infrastructure components, such as CPU, memory, and disk usage.
5.	Log monitoring systems: These systems are used to collect and analyse log data, which can be used to troubleshoot issues and identify patterns.
6.	Synthetic monitoring systems: These systems are used to proactively test the availability and performance of systems and services. They simulate user actions, such as visiting a website or accessing a database, and report any failures or errors.
All these systems can be used for both real-time monitoring and historical analysis. They can also be configured to send alerts to various endpoints, such as email, slack, or pager duty when certain thresholds are exceeded or certain events occur.
Overall, monitoring systems are essential for ensuring the availability and reliability of IT infrastructure and can help to prevent and troubleshoot issues. They can also provide valuable insights into the performance and usage of systems and services, which can be used to make informed decisions about capacity planning and optimization.

## Alerting systems 
Alerting systems are a critical component of monitoring systems, used to notify users of potential issues or problems with systems and services. These systems are configured to monitor specific metrics or log data and trigger alerts when certain thresholds or conditions are met.
There are several types of alerts that can be configured, including:
1.	Threshold-based alerts: These alerts are triggered when a metric exceeds a specific threshold. For example, an alert could be configured to trigger when the CPU usage on a server exceeds 90%.
2.	Anomaly-based alerts: These alerts are triggered when a metric deviates significantly from its normal behaviour. For example, an alert could be configured to trigger when the number of error messages in a log file increases significantly.
3.	Heartbeat alerts: These alerts are triggered when a system or service fails to send a periodic heartbeat. This can be used to detect when a system or service is down or unresponsive.
Alerts can be sent to various endpoints, such as email, slack, or pager duty, and can also be configured to trigger specific actions, such as restarting a service or scaling up a cluster.
Some alerting systems also provide a web UI for managing and acknowledging alerts, as well as a history of previous alerts.
Overall, alerting systems are an essential component of monitoring systems, and are critical for ensuring that potential issues are identified and addressed in a timely manner. They can also be configured to trigger automated actions, such as scaling up a cluster, which can help to minimize the impact of an issue on systems and services.

## Metrics
In Prometheus, metrics are the core concept and are represented as time-series data. Each metric is identified by a unique name, such as "http_request_duration_seconds" and has a set of key-value pairs called labels that provide additional context, such as the "handler" or "instance" that the metric relates to. This allows for powerful querying and aggregation of metrics.
Prometheus supports a wide range of metric types, including:
1.	Counter: A counter is a metric that only increases over time and can be used to track things like request or error count.
2.	Gauge: A gauge is a metric that can increase or decrease over time and can be used to track things like CPU usage or memory usage.
3.	Histogram: A histogram is a metric that samples observations and provides information about the distribution of those observations, such as the count, sum, and bucketed quantiles.
4.	Summary: A summary is similar to a histogram, but it also provides the total count of observations and the sum of all observations.
Prometheus uses a pull-based architecture, where the Prometheus server periodically scrapes metrics from exporters. Exporters are special-purpose programs that collect metrics from a specific service or application and expose them in a format that Prometheus can scrape. Prometheus supports a wide range of exporters for various systems and services, such as Node Exporter for collecting metrics from Linux systems, and Blackbox Exporter for probing endpoints over HTTP, HTTPS, DNS, TCP and ICMP.
Prometheus also provides a powerful query language called PromQL that can be used to filter and aggregate metrics. PromQL allows you to select, filter and aggregate time series data, you can use mathematical expressions to combine or transform metrics and create new metrics.
In addition to this, Prometheus also provides a web UI for querying and visualizing metrics and alerting system that can be used to trigger alerts based on the values of metrics.
Overall, Prometheus provides a powerful and flexible metrics system that allows you to collect, store, and query metrics from various systems and services. The ability to label metrics, the powerful query language PromQL and the built-in alerting system, make Prometheus a widely used monitoring tool in cloud-native and containerized environments.

## Labels
In Prometheus, labels are key-value pairs that can be added to metrics to provide additional context. They allow for powerful querying and aggregation of metrics by allowing users to filter and group metrics based on specific label values.
For example, let's say you have a metric called "http_request_duration_seconds" which measures the duration of HTTP requests. You can add labels to this metric such as "handler", "instance", and "status" to provide additional context. The "handler" label could indicate the specific endpoint that handled the request, the "instance" label could indicate the specific instance of the service that handled the request, and the "status" label could indicate whether the request was successful or not.
Once you have added labels to metrics, you can use PromQL, Prometheus's query language, to filter and aggregate metrics based on specific label values. For example, you can use the following query to find the average request duration of all requests to the "search" endpoint:
“avg(http_request_duration_seconds{handler="search"})“
Or to find the average request duration for each instance of the service:
“avg(http_request_duration_seconds) by (instance) “
Labels can also be used to group metrics together for visualization purposes, for example, you can use Grafana, a visualization tool that can be integrated with Prometheus, to create a graph that displays the request duration for each instance of the service and groups them by the "handler" label.
Labels are also a key concept when it comes to Prometheus's alerting system. You can use labels to define alerting rules that trigger alerts based on specific label values. For example, you can define an alert that triggers when the request duration for any instance of the service exceeds a specific threshold.
Overall, labels are a powerful feature of Prometheus that allows users to add additional context to metrics and provide more granular querying and aggregation capabilities. They also play an important role in Prometheus's alerting system, allowing alerts to be triggered based on specific label values.

## Pull-Based architecture
Prometheus uses a pull-based architecture, which means that the Prometheus server periodically scrapes metrics from exporters rather than having exporters push metrics to the server. This architecture is designed to be simple, scalable, and efficient, and allows for a loosely coupled system where the Prometheus server and exporters can be deployed and updated independently.
In a pull-based architecture, the Prometheus server is responsible for discovering and scraping metrics from exporters. The server periodically sends HTTP requests to a specific endpoint on the exporters, known as the metrics endpoint, and the exporter responds with the metrics in a specific format that Prometheus can understand. This format is typically in a plain text format, but it can also be in protobuf, json or other formats.
Exporters are special-purpose programs that collect metrics from a specific service or application and expose them in a format that Prometheus can scrape. There are a wide range of exporters available for various systems and services, such as Node Exporter for collecting metrics from Linux systems, and Blackbox Exporter for probing endpoints over HTTP, HTTPS, DNS, TCP and ICMP.
One of the advantages of pull-based architecture is that the Prometheus server has full control over when and how metrics are collected, which allows for fine-grained control over the resources used by the system. This is particularly useful in environments where resources are limited, such as in containerized or cloud-native environments.
Another advantage of pull-based architecture is that it allows for easy scaling of the monitoring system. As the number of systems and services being monitored increases, additional exporters can be added to the system without having to make changes to the Prometheus server.
Additionally, in a pull-based architecture, the exporters are responsible for collecting metrics, which means that they can be deployed independently of the Prometheus server. This allows for a loosely coupled system where the exporters and the Prometheus server can be deployed and updated independently.
Overall, Prometheus's pull-based architecture provides a simple, scalable, and efficient way to collect metrics from various systems and services. It allows for fine-grained control over the resources used by the system, easy scaling of the monitoring system and a loosely coupled system where the Prometheus server and exporters can be deployed and updated independently.
Exporters 
Exporters are special-purpose programs that collect metrics from a specific service or application and expose them in a format that Prometheus can scrape. In Prometheus, the exporters act as a bridge between the service or application being monitored and the Prometheus server, allowing Prometheus to collect metrics from a wide range of systems and services.
Exporters typically run as separate processes on the same machine as the service or application being monitored, but can also be run on a separate machine. They expose metrics via an HTTP endpoint, which is known as the metrics endpoint, and Prometheus server periodically scrapes this endpoint to collect the metrics.
There are a wide range of exporters available for various systems and services, such as:
1.	Node Exporter: Collects metrics about the system, such as CPU, memory, and disk usage.
2.	JMX Exporter: Collects metrics from Java applications that expose metrics via JMX (Java Management Extensions).
3.	Blackbox Exporter: Probes endpoints over HTTP, HTTPS, DNS, TCP and ICMP, and exports the results in a format that Prometheus can scrape.
4.	MySQL Exporter: Collects metrics from MySQL databases, such as query performance and replication status.
5.	PostgreSQL Exporter: Collects metrics from PostgreSQL databases, such as query performance and replication status.
6.	HAProxy Exporter: Collects metrics from HAProxy, such as request rate and response time.
7.	Kubernetes Exporter: Collects metrics from Kubernetes clusters, such as pod and node usage.
Exporters are typically implemented in a lightweight and efficient way, and are designed to have minimal impact on the performance of the service or application being monitored. They can also be configured to collect and expose only the metrics that are relevant to the service or application being monitored.
Exporters are an essential component of Prometheus's monitoring system, as they allow Prometheus to collect metrics from a wide range of systems and services. They are typically easy to install, configure and maintain, and can be deployed independently of the Prometheus server. Overall, Prometheus's exporters provide a flexible and powerful way to collect metrics from various systems and services, and are a key component of Prometheus's monitoring system.

## PromQL
PromQL (Prometheus Query Language) is a powerful query language that is used to filter and aggregate metrics in Prometheus. It allows users to select, filter and aggregate time-series data, and perform mathematical operations on metrics to create new metrics.
PromQL is a functional language, which means that it uses functions to filter and aggregate metrics. Some of the most commonly used functions in PromQL include:
1.	avg(): Returns the average value of a metric over a specified time range.
2.	sum(): Returns the sum of the values of a metric over a specified time range.
3.	min(): Returns the minimum value of a metric over a specified time range.
4.	max(): Returns the maximum value of a metric over a specified time range.
5.	count(): Returns the number of data points in a metric over a specified time range.
PromQL also provides powerful filtering capabilities. For example, you can filter metrics based on label values:
“http_request_duration_seconds{handler="search"}”
This query returns the http_request_duration_seconds metric only for requests that have been handled by the "search" endpoint.
PromQL also supports aggregation functions such as group by, without and by which allows you to group and aggregate metrics based on specific label values. For example, the following query returns the average request duration for each instance of the service:
“avg(http_request_duration_seconds) by (instance)”
PromQL also supports more advanced operations like Arithmetic, logical, comparison and set-membership operations, this allows you to perform mathematical operations on metrics, like calculating rate of change, or calculate the difference between two metrics.

## Weakness of Prometheus
Prometheus is a widely used and powerful monitoring system, but it does have some limitations and weaknesses that should be considered when evaluating it for use in a specific environment. Some of the most notable weaknesses of Prometheus include:
1.	Limited storage capacity: Prometheus stores all metrics in a local storage, this can become a bottleneck when dealing with large amounts of metrics, high-resolution metrics or long retention periods. There are solutions to this problem such as use of remote storage systems like Thanos and Cortex, but they require additional setup and maintenance.
2.	Limited querying capabilities: Prometheus uses a simple pull-based architecture for collecting metrics, which can make it difficult to perform complex queries and analysis on metrics. This can be a limitation when dealing with large and diverse datasets.
3.	Limited built-in visualization and alerting: Prometheus provides a basic web UI for querying and visualizing metrics, but it lacks the advanced visualization and alerting capabilities of other monitoring systems. This can make it difficult to quickly identify and respond to issues.
4.	Limited scalability: Prometheus is designed to handle a large number of metrics, but it can become challenging to scale when dealing with extremely high-traffic environments. This can be mitigated by using remote storage, but it still requires additional setup and maintenance.
5.	Limited security features: Prometheus does not have built-in security features such as authentication and authorization. This can be a concern for environments that require a high

## prometheus with RabbitMQ
Prometheus can be used to monitor RabbitMQ by using an exporter, which is a special-purpose program that collects metrics from a specific service or application and exposes them in a format that Prometheus can scrape. The most commonly used exporter for RabbitMQ is the Prometheus RabbitMQ Exporter. This exporter is a simple and lightweight program that can be installed on the same machine as the RabbitMQ server and it exports RabbitMQ metrics in a format that Prometheus can scrape.
The exporter can be configured to scrape metrics from the RabbitMQ management API, which provides a wide range of metrics such as queue length, message rate, and consumer count. These metrics can be used to monitor the health and performance of the RabbitMQ server and to identify potential issues.
Prometheus can also be used to create alerts based on the values of RabbitMQ metrics, for example, you can set an alert to trigger when the number of unacknowledged messages in a queue exceeds a certain threshold. This can help to identify and respond to issues in a timely manner.
Prometheus can also be used in conjunction with Grafana, a visualization tool that can be integrated with Prometheus, to create graphs and dashboards that display RabbitMQ metrics. This can be useful for identifying patterns and trends in the metrics and for identifying potential issues.


