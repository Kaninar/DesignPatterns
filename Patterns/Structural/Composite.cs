namespace DesignPatterns.Patterns.Structural.Composite;

interface IGraphics
{
    void Move(int x, int y);
    void Draw();
}

class Point(int x, int y) : IGraphics
{
    public int x = x;
    public int y = y;

    public void Move(int x, int y)
    {
        this.x += x;
        this.y += y;
    }

    public virtual void Draw()
    {
        Console.WriteLine($"Точка нарисована на ({this.x} : {this.y})");
    }
}

class Circle(int x, int y, double radius) : Point(x, y)
{
    public double Radius = radius;

    public override void Draw()
    {
        Console.WriteLine($"Окружность с r = {this.Radius} нарисована на ({base.x} : {base.y})");
    }
}

class CompositeGraphics : IGraphics
{
    private List<IGraphics> _children = new List<IGraphics>();

    public void Add(IGraphics graphics)
    {
        _children.Add(graphics);
    }

    public void Remove(IGraphics graphics)
    {
        _children.Remove(graphics);
    }

    public void Move(int x, int y)
    {
        this._children.ForEach(child => child.Move(x, y));
    }

    public void Draw()
    {
        this._children.ForEach(child => child.Draw());
    }
}

class Client
{
    public void Main()
    {
        Point point1 = new Point(0, 0);
        Point point2 = new Point(-4, 9);
        Circle circle1 = new Circle(10, 10, 5);

        CompositeGraphics composite1 = new CompositeGraphics();
        CompositeGraphics composite2 = new CompositeGraphics();

        composite1.Add(point1);
        composite1.Add(point2);
        composite1.Add(circle1);
        
        composite1.Move(3, -6);
        
        composite2.Add(new Circle(4, 12, 7));
        
        composite2.Add(composite1);
        
        composite2.Draw();
    }
}