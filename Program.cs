using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Messaging;
using System.Messaging.MessageQueue;
using NServiceBus.Serializers.Binary;

namespace Application2
{
    public class Program
    {
        public void Main(string[] args)
        {
            Console.WriteLine("Welcome to Wonga.Com");

            MessageQueue MyQueue;
            MyQueue = new MessageQueue(@".\Private$\MyQueue");

            Message MyMessage = MyQueue.Receive();
            MyMessage.Formatter = new BinaryMessageFormatter();

            Console.WriteLine(MyMessage.Body.ToString());
            Console.ReadKey();

        }
    }
}