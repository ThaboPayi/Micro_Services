using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using System.Messaging.MessageQueue;

namespace Application1
{
    public class Program
    {
        public void Main(string[] args)
        {
            Console.WriteLine("Welcome to Wonga.Com");
            Console.WriteLine("Please write a message you want to send");
            string Message = Console.ReadLine();

            MessageQueue MyQueue;
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                MyQueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                MyQueue = MessageQueue.Create(@".\Private$\MyQueue");
            }

            Message MyMessage = new Message();

            MyMessage.Formatter = new BinaryMessageFormatter();
            MyMessage.Body = Message;
            MyMessage.Label = "MessagFromApplication1";

            MyQueue.Send(MyMessage);
            Console.WriteLine("Message Sent");
            Console.ReadKey();
        }
    }
}
