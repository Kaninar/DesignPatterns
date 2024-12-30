using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns.Creational.Factory
{
    interface ITransport
    {
        void MakeSound();
    }

    class Car : ITransport
    {
        public void MakeSound() => Console.WriteLine("Wroom wroom");
    }

    class Ship : ITransport
    {
        public void MakeSound() => Console.WriteLine("Tooo tooo");
    }

    abstract class Factory
    {
        public abstract ITransport CreateTransport();
    }

    class CarFactory : Factory
    {
        public override Car CreateTransport()
        {
            return new Car();
        }
    }

    class ShipFactory : Factory
    {
        public override Ship CreateTransport()
        {
            return new Ship();
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: testing client...");
            GetInfo(new ShipFactory());

            Console.WriteLine();

            Console.WriteLine("Client: testing client...");
            GetInfo(new CarFactory());
        }

        public static void GetInfo(Factory factory)
        {
            ITransport transport = factory.CreateTransport();
            transport.MakeSound();
        }
    }
}
