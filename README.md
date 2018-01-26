# RabbitMQ.Publisher

# Run project

Run the following command into "RabbitMQ.Publisher" directory

Create a bridge network 

```shell
docker network create --driver bridge isolated
```
Build and run the conatiners

```shell
docker-compose build
docker-compose up
```

It will create a single message "Hello Wrold!"
