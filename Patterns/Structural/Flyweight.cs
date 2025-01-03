using System.Text;

namespace DesignPatterns.Patterns.Structural.Flyweight;

public class Flyweight(Cucumber car)
{
    private Cucumber _sharedState = car;
}

public class FlyweightFactory
{
    private List<Tuple<Flyweight, string>> flyweights = [];

    public FlyweightFactory(params Cucumber[] args)
    {
        args.ToList()
            .ForEach(ccmbr => flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(ccmbr), this.GetKey(ccmbr))));
    }

    public string GetKey(Cucumber key)
    {
        List<string> elements = [key.Weight.ToString(), key.Color, key.Length.ToString(), key.Width.ToString(), key.Owner];
 
        elements.Sort();

        return string.Join("_", elements);
    }

    public Flyweight GetFlyweight(Cucumber sharedState)
    {
        string key = this.GetKey(sharedState);

        if(flyweights.Where(t => t.Item2 == key).Count() == 0)
        {
            Console.WriteLine("Создан новый");
            this.flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
        }
        else
        {
            Console.WriteLine("Есть существующий");
        }

        return flyweights.FirstOrDefault(t => t.Item2 == key).Item1;
    }

    public void ListFlyweights()
    {
        var sb = new StringBuilder();
        var count = flyweights.Count;

        for(int i = 0; i < count; i++)
        {
            sb.AppendLine($"{i + 1}. {flyweights[i].Item2}");
        }

        sb.AppendLine($"Всего {count}");
        Console.WriteLine(sb.ToString());
    }
}

public class Cucumber
{
    public string Owner
    {
        get; set;
    }

    public int Weight
    {
        get; set;
    }

    public int Width
    {
        get; set;
    }

    public int Length
    {
        get; set;
    }

    public string Color
    {
        get; set;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var factory = new FlyweightFactory(
            new Cucumber { },
            new Cucumber { },
            new Cucumber { },
            new Cucumber { },
            new Cucumber { }
        );

        factory.ListFlyweights();
    }
}