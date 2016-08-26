using System;
using System.Threading.Tasks;
using Amqp;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run().Wait();
        }
        static async Task Run()
        {
            string address = "amqp://guest:guest@localhost:5672";
            string queue = "jms.queue.test";

            Connection connection = await Connection.Factory.CreateAsync(new Address(address));
            Session session = new Session(connection);
            SenderLink sender = new SenderLink(session, "test-sender", queue);

            Message message1 = new Message("Hello AMQP!");
            await sender.SendAsync(message1);

            ReceiverLink receiver = new ReceiverLink(session, "test-receiver", queue);
            Message message2 = await receiver.ReceiveAsync();
            Console.WriteLine(message2.GetBody<string>());
            receiver.Accept(message2);

            await sender.CloseAsync();
            await receiver.CloseAsync();
            await session.CloseAsync();
            await connection.CloseAsync();
        }
    }
}
