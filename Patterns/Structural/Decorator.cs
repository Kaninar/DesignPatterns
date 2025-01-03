namespace DesignPatterns.Patterns.Structural.Decorator;

interface IFile
{
    void Write(string data);
    string Read();
}

class File : IFile
{
    public void Write(string data)
    {
        Console.WriteLine($"Запись {data}");
    }

    public string Read()
    {
        return "Чтение из файла";
    }
}

abstract class FileEditor(IFile file) : IFile
{
    protected IFile _file = file;

    public void Write(string data)
    {
        Console.WriteLine($"Запись {data} в файл");
    }

    public string Read()
    {
        return "Обычное чтение из файла";
    }
}

class JSON(IFile file) : FileEditor(file)
{
    public void Write(string data)
    {
        Console.WriteLine($"Запись {data} в JSON");
    }

    public string Read()
    {
        return "Чтение из JSON";
    }
}

class PDF(IFile file) : FileEditor(file)
{
    public void Write(string data)
    {
        Console.WriteLine($"Запись {data} в PDF");
    }

    public string Read()
    {
        return "Чтение из PDF";
    }
}

public class Client
{
    public void Main()
    {
        File file = new File();
        PDF pdf = new PDF(file);
        Console.WriteLine("RESULT: " + pdf.Read());
    }
}