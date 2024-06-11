# Newsfeed: A social media private for enterprise 

A private social media platform for enterprises includes the following functions:

+ Category management
    + Create
    + Update
    + Delete
+ Post management
    + List
    + Update
    + Add
    + Delete
+ Group management
 
The project is developed following the **Domain Driven Design**  approach, with **Onion Clean Architecture**, **CQRS pattern** and using the follow libraries:

+ **MediatR**
+ **SignalR** for bell notification
+ RabbitMQ using **Masstransit** library
+ Schedule tasks with **Quartz.Net** library
+ **Identity** for authentication and authorization
+ ORM **Entity Framework Core** for database manipulation





