using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns.Creational.AbstractFactory
{
    interface IChair
    {
        void Say();
    }
    interface ISofa
    {
        void Say();
    }
    //interface ITable
    //{
    //    void Say();
    //}

    class ModernChair : IChair
    {
        public void Say() => Console.WriteLine("I am a Modern Chair");
    }
    class VintageChair : IChair
    {
        public void Say() => Console.WriteLine("I am a Vintage Chair");
    }
    class ModernSofa : ISofa
    {
        public void Say() => Console.WriteLine("I am a Modern Sofa");
    }
    class VintageSofa : ISofa
    {
        public void Say() => Console.WriteLine("I am a Vintage Sofa");
    }
    //class Table : ITable
    //{

    //}

    interface IFactory
    {
        IChair CreateChair();
        ISofa CreateSofa();
    }

    class ModernFactory : IFactory 
    {
        public IChair CreateChair()
        {
            return new ModernChair();
        }
        public ISofa CreateSofa()
        {
            return new ModernSofa();
        }
    }

    class VintageFactory : IFactory
    {
        public IChair CreateChair()
        {
            return new VintageChair();
        }
        public ISofa CreateSofa()
        {
            return new VintageSofa();
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: testing client...");
            GetInfo(new ModernFactory());

            Console.WriteLine();

            Console.WriteLine("Client: testing client...");
            GetInfo(new VintageFactory());
        }

        public static void GetInfo(IFactory factory)
        {
            IChair chair = factory.CreateChair();
            ISofa sofa = factory.CreateSofa();
            chair.Say();
            sofa.Say();
        }
    }
}
