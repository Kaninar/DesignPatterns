using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DesignPatterns.Patterns.Structural.Bridge;

interface IDevice
{
    bool IsEnabled();
    void Enable();
    void Disable();
    int GetVolume();
    void SetVolume(int volume);
}

class Remote(IDevice device)
{
    protected IDevice _device = device;

    public bool TogglePower()
    {
        if(_device.IsEnabled())
        {
            _device.Disable();
        }
        else
        {
            _device.Enable();
        }

        return _device.IsEnabled();
    }

    public int VolumeUp()
    {
        int volume =_device.GetVolume();
        _device.SetVolume(volume + 10);
        return _device.GetVolume();
    }

    public int VolumeDown()
    {
        int volume = _device.GetVolume();
        _device.SetVolume(volume - 10);
        return _device.GetVolume();
    }
}

class AdvancedRemote(IDevice device) : Remote(device)
{
    public void Mute()
    {
        _device.SetVolume(0);
    }

    public void PrintInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Power : " + (_device.IsEnabled() ? "On" : "Off"));
        sb.AppendLine($"Volume : {_device.GetVolume()}");
        Console.WriteLine( sb.ToString() );
    }
}

class Device : IDevice
{
    private int _volume = 50;

    bool _enabled = false;

    public int Volume = 0;

    public bool IsEnabled() 
    { 
        return _enabled; 
    }

    public void Enable()
    { 
        _enabled = true; 
    }

    public void Disable()
    {
        _enabled = false;
    }

    public int GetVolume()
    {
        return _volume;
    }

    public void SetVolume(int volume)
    {
        _volume = volume;
    }
}

class Client
{
    public void Main()
    {
        var device = new Device();
        var remote = new Remote(device);
        var advancedremote = new AdvancedRemote(device);

        advancedremote.TogglePower();

        remote.VolumeUp();
        remote.VolumeUp();

        advancedremote.PrintInfo();
    }
}
