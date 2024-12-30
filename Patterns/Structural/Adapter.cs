namespace DesignPatterns.Patterns.Structural.Adapter;


class Celsius
{
    public float value;

    public Celsius(float t)
    {
        this.value = t;
    }
}

class Farengate
{
    public float value;

    public Farengate(float t)
    {
        this.value = t;
    }
}

class WeatherReport
{
    public void PrintTempriture(Celsius celsius) => Console.WriteLine($"Today tempriture : {celsius.value}");
}

class CelsiousFarengateAdapter
{
    public Celsius CelsiusToFarengate(Farengate farengate)
    {
        return new Celsius( (float)Math.Round( ((farengate.value - 32) * 5) / 9, 0) );
    }
}

class Client
{
    public void Main()
    {
        var celsius = new Celsius(33);
        var farengate = new Farengate(33);
        var adapter = new CelsiousFarengateAdapter();

        var weather = new WeatherReport();
        Console.WriteLine("No adapter used");
        weather.PrintTempriture(celsius);

        Console.WriteLine();

        Console.WriteLine("Adapting");
        weather.PrintTempriture(adapter.CelsiusToFarengate(farengate));
    }
}