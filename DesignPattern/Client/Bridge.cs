using System.Collections.Generic;
using DesignPattern.Patterns.StructuralPatterns;

namespace DesignPattern.Client;

public class Bridge: IAbstractClient
{
    public void Execute()
    {
        List<IDevice> devices = new List<IDevice>
        {
            new Radio(),
            new Tv()
        };

        AdvancedRemote remoteController = new AdvancedRemote(device: devices[0], initChannel: 10);
        foreach (var curDevice in  devices)
        {
            remoteController.SwitchDevice(curDevice);
            remoteController.TogglePower();  // 启动设备
            remoteController.ChannelUp();
            remoteController.TogglePower();  // 关闭设备
            remoteController.ChannelDown();
        }
    }
}