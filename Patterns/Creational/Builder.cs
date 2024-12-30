using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns.Creational.Builder
{
    interface IBuilder
    {
        void Reset();
        void SetProcessor(IProcessor processor);
        void SetRAM(uint count);
        void SetGraphics(bool isCard);
    }

    class DeviceBuilder : IBuilder
    {
        private Device _computer = new();

        public DeviceBuilder() => this.Reset();

        public void Reset()
        {
            this._computer = new Device();
        }

        public void SetProcessor(IProcessor? processor)
        {
            this._computer!.processor = processor!;
        }

        public void SetRAM(uint count)
        {
            this._computer!.RAM = count;
        }

        public void SetGraphics(bool isCard)
        {
            this._computer!.isGraphiscDiscrete = isCard;
        }

        public Device GetResult()
        {
            Device result = this._computer;
            this.Reset();
            return result!;
        }
    }

    interface IProcessor
    {
    }

    class ProcessorAMD : IProcessor
    {
    }

    class ProcessorIntel : IProcessor 
    { 
    }     

    class Device
    {
        public IProcessor processor;
        public uint RAM;
        public bool isGraphiscDiscrete;

        public string ToString()
        {
            StringBuilder sb = new ();
            sb.AppendLine("Processor : " + (this.processor is ProcessorAMD ? "AMD" : "INTEL"));
            sb.AppendLine($"RAM : {this.RAM}");
            sb.AppendLine("GPU is " + (isGraphiscDiscrete ? "discrete" : "integrated"));
            return sb.ToString();
        }
    }

    class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set => this._builder = value;
        }

        public void CreateComputer()
        {
            _builder.Reset();
            _builder.SetProcessor(new ProcessorAMD());
            _builder.SetRAM(32);
            _builder.SetGraphics(true);
        }

        public void CreateSmartphone()
        {
            _builder.SetProcessor(new ProcessorIntel());
            _builder.SetRAM(8);
            _builder.SetGraphics(false);
        }
    }

    class Client
    {
        public void Main()
        {
            var director = new Director();
            var builder = new DeviceBuilder();
            director.Builder = builder;

            Console.WriteLine("Creating Computer...");
            director.CreateComputer();
            Console.WriteLine(builder.GetResult().ToString());

            Console.WriteLine();
            Console.WriteLine("Creating Smartphone...");
            director.CreateSmartphone();
            Console.WriteLine(builder.GetResult().ToString());

            Console.WriteLine("Creating Custom device...");
            builder.SetProcessor(new ProcessorAMD());
            builder.SetRAM(16);
            builder.SetGraphics(false);
            Console.WriteLine(builder.GetResult().ToString());
        }
    }
}
