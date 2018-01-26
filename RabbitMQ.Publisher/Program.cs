using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {

            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq",
                UserName = "guest",
                Password = "guest",
                Port = 5672
            };

            // The RabbitMQ container starts before endpoints but it may
            // take several seconds for the broker to become reachable.
            Thread.Sleep(TimeSpan.FromSeconds(5));

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("docker.test.queue", false, false, false, null);

                    var message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(String.Empty, "docker.test.queue", null, body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }
            Console.ReadLine();
        }
    }
}
