using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aktor
{
    class Program
    {
        static void Main(string[] args)
        {
            var actors = ActorSystem.Create("MyActors");

            var greeter = actors.ActorOf<GreetingActor>("greeter");
            greeter.Tell(new Greet("world"));

            Console.ReadLine();
        }
    }

    public class GreetingActor:ReceiveActor
    {
        public GreetingActor()
        {
            Receive<Greet>(greet => Console.WriteLine("Hello worl from: {0}", greet.Who));
        }
    }

    public class Greet
    {
        public Greet(string who)
        {
            Who = who;
        }

        public string Who { get; private set; }
    }
}
