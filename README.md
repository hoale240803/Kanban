# Kanban

# Domain Driven Design

## Application Layer
- This layer to handle requests from client ,we devide into request two type "Command" and "Query". It's called CQRS(command and query responsibility segregation).  
"Command" is something like PUT, POST, DELETE methods them make change data. "Query" like GET method, It's only want select record and return not make update anything.
Each "Command and Query" we write a function handle. And We use Mediator library to communicate between
## Domain Layer
- This layer to take responsibility of handling business logic of application. Every action should be tackling on Aggregate Model

## Infrastructure Layer
- This layer works with database, get data following the model of Domain Layer

##References

[Series useful Microservices](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/microservice-application-design)
