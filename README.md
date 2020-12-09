# Microservice-sample-event-driven-architecture

This project is basic sample to understand communication between microservices.

There are three microservices in the repository and every single on of them has own responsibility.

1- Identity microservice just inserts user entity to its database  
2- Customer microservice just updates customer entity in its database 
3- Notification microservice just consumes events and  inserts or updates related data in its database

When creating a user in the Identity microservice, it publishes an event to queue, Notification, and Customer projects consume this event.
When updating a customer in the Customer microservice, it publishes an event to queue, Notification, and Identity projects consume this event.

​	 Run this command `docker-compose up` in MicroservicesSample root folder before runnig the projects. This compose file includes postgresql, rabbitmq, redis containers.

# Use Case

* Create a user in the Identity project and see it in Notification and Customer projects.
* Update the user in Customer project and check the entity in Identity and Notification



![microservices](https://github.com/AkinSabriCam/Microservice-sample-event-driven-architecture/tree/master/MicroservicesSample/microservices.png)

##  

# Tech Stack

.Net Core 3.1
EntityFrameworkCore
RabbitMQ with MassTransit Framework
MediatR
Redis Cache tool
Swagger
Docker Container
Command Handlers Patterns
CQS
OOP
Microservices
SOLID
