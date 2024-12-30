using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns.Creational.Prototype
{
    class Shape : ICloneable
    {
        int X;
        int Y;
        string Color;

        public Shape(int x = 0, int y = 0, string color = "black")
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
        }

        public Shape(Shape source)
        {
            this.X = source.X;
            this.Y = source.Y;
            this.Color = source.Color;
        }

        public object Clone()
        { 
            return new Shape(this); 
        }
    }

    class Rectangle : Shape, ICloneable
    {
        private int Height;
        private int Width;

        public Rectangle(int height = 1, int width = 1) : base()
        {
            this.Height = height;
            this.Width = width;
        }

        public Rectangle(Shape shape, int height = 1, int width = 1) : base(shape!)
        {
            ArgumentNullException.ThrowIfNull(shape);

            this.Height = height;
            this.Width = width;
        }

        public Rectangle(Rectangle rectangle) : base(rectangle) 
        {
            this.Height = rectangle.Height;
            this.Width = rectangle.Width;
        }

        public new object Clone()
        {
            return this.MemberwiseClone();
        }

        public Rectangle DeepClone()
        {
            Rectangle clone = (Rectangle) this.MemberwiseClone();
            clone.Width = this.Width;
            clone.Height = this.Height;
            return clone;
        }
    }

    class Circle : Shape, ICloneable
    {
        private int Radius;

        public Circle(int radius = 1) : base () 
        {
            this.Radius = radius;
        }

        public Circle(Circle circle) : base(circle)
        {
            this.Radius = circle.Radius;
        }

        public new object Clone()
        {
            return this.MemberwiseClone();
        }

        public Circle DeepClone()
        {
            Circle clone = (Circle) Clone();
            clone.Radius = this.Radius;
            return clone;
        }
    }
}
