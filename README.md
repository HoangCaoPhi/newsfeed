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
+ Manage User and Role
+ Authentication and Authorization
 
The project is developed following the [**Domain Driven Design**](https://learn.microsoft.com/en-us/archive/msdn-magazine/2009/february/best-practice-an-introduction-to-domain-driven-design)  approach, with [**Onion Clean Architecture**](https://code-maze.com/onion-architecture-in-aspnetcore/), [**CQRS pattern**](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs) and using the follow libraries:

+ [**MediatR**](https://github.com/jbogard/MediatR)
+ [**SignalR**](https://learn.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-8.0) for bell notification
+ [**RabbitMQ**](https://www.rabbitmq.com/) using [**Masstransit**](https://masstransit.io/) library
+ Schedule tasks with [**Quartz.Net**](https://www.quartz-scheduler.net/) library
+ [**Identity**](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0&tabs=visual-studio) for authentication and authorization
+ ORM [**Entity Framework Core**](https://learn.microsoft.com/en-us/ef/core/) for database manipulation
+ Distribution Cache with [**Redis**](https://redis.io/) and [**Cache in-memory**](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-8.0)





