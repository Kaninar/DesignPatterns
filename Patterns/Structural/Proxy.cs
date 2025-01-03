namespace DesignPatterns.Patterns.Structural.Proxy;

interface IServer
{
    string GET();
}

class Server : IServer
{
    private string _data = "I am a data";
    public string GET()
    {
        Console.WriteLine("Looking for data...");
        Thread.Sleep(3000);
        Console.WriteLine("Here is your data!");
        return _data;
    }
}

class ProxyServer(Server server) : IServer
{
    private Server _server = server;
    private string _data = string.Empty;

    public string GET()
    {
        if(this._data == string.Empty)
        {
            Console.WriteLine("New data request...");
            this._data = _server.GET();
        }
        else
        {
            Console.WriteLine("Data is already here.");
        }

        return this._data;
    }
}

class Client
{
    public void Main()
    {
        Server server = new Server();
        ProxyServer proxy = new ProxyServer(server);
        
        string data = server.GET();
        Console.WriteLine(data);
        Console.WriteLine();
        data = server.GET();
        Console.WriteLine(data);
        Console.WriteLine();
        Console.WriteLine("Too long, isn't it?");
        Console.WriteLine();
        data = proxy.GET();
        Console.WriteLine(data);
        Console.WriteLine();
        data = proxy.GET();
        Console.WriteLine(data);
        Console.WriteLine();
        Console.WriteLine("Now it is better!");
    }
}
