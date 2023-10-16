namespace DesignPattern.Patterns.StructuralPatterns;

public interface IDevice
{
    bool IsEnabled();
    void Enable();
    void Disable();
    string GetChannel();
    void SetChannel(int channel);
}

public class Radio : IDevice
{
    private bool _isEnabled;
    private int _currentChannel;

    public bool IsEnabled()
    {
        return _isEnabled;
    }

    public void Enable()
    {
        _isEnabled = true;
    }

    public void Disable()
    {
        _isEnabled = false;
    }

    public string GetChannel()
    {
        return $"Current Radio Channel: {_currentChannel}";
    }

    public void SetChannel(int channel)
    {
        _currentChannel = channel;
    }
}

public class Tv : IDevice
{
    private bool _isEnabled;
    private int _currentChannel;

    public bool IsEnabled()
    {
        return _isEnabled;
    }

    public void Enable()
    {
        _isEnabled = true;
    }

    public void Disable()
    {
        _isEnabled = false;
    }

    public string GetChannel()
    {
        return $"Current TV Channel: {_currentChannel}";
    }

    public void SetChannel(int channel)
    {
        _currentChannel = channel;
    }
}

public abstract class Remote
{
    protected IDevice Device;

    protected Remote(IDevice device)
    {
        Device = device;
    }
    
    public abstract void TogglePower();

    public abstract void ChannelDown();

    public abstract void ChannelUp();
}

public class AdvancedRemote : Remote
{
    private int _initChannel;
    private int _currentChannel;
    
    public AdvancedRemote(IDevice device, int initChannel) : base(device)
    {
        _initChannel = initChannel;
        _currentChannel = _initChannel;
    }

    public void SwitchDevice(IDevice newDevice)
    {
        Device = newDevice;
        
        // reset channel and device state
        _currentChannel = _initChannel;
        Device.Disable();
    }
    
    public override void TogglePower()
    {
        if (Device.IsEnabled()) Device.Disable();
        else Device.Enable();
    }

    public override void ChannelDown()
    {
        if (!Device.IsEnabled())
        {
            Console.WriteLine("Current device is disabled, can not change channel");
            return;
        }
        
        _currentChannel += 1;
        Device.SetChannel(_currentChannel);
        Console.WriteLine($"With Channel Down: {Device.GetChannel()}");
    }
    
    public override void ChannelUp()
    {
        if (!Device.IsEnabled())
        {
            Console.WriteLine("Current device is disabled, can not change channel");
            return;
        }
        
        _currentChannel -= 1;
        Device.SetChannel(_currentChannel);
        Console.WriteLine($"With Channel Up: {Device.GetChannel()}");
    }
}