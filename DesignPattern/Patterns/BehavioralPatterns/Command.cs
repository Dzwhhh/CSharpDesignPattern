namespace DesignPattern.Patterns.BehavioralPatterns;

/*
 * 命令模式将触发者（调用方）和执行者（业务逻辑）断直连
 * 触发者将Command对象作为成员属性存储，通过执行Command.Execute()执行命令
 * 命令类中不会实际处理，而是调用业务逻辑获取执行结果后返回
 * 由于命令类继承自公共的接口，触发者可以在运行时动态切换命令
 */

public interface ICommand
{
    void Execute();
}

class SimpleCommand : ICommand
{
    private readonly string _payload;

    public SimpleCommand(string payload)
    {
        _payload = payload;
    }

    public void Execute()
    {
        Console.WriteLine($"SimpleCommand can be done by self, current payload: {_payload}");
    }
}

class ComplexCommand : ICommand
{
    private Receiver _receiver;

    private string _a;

    private string _b;

    public ComplexCommand(Receiver receiver, string a, string b)
    {
        _receiver = receiver;
        _a = a;
        _b = b;
    }

    public void Execute()
    {
        Console.WriteLine($"ComplexCommand can be done by receiver");
        _receiver.DoSomething(_a);
        _receiver.DoSomethingElse(_b);
    }
}

class Receiver
{
    public void DoSomething(string a)
    {
        Console.WriteLine($"Receiver: Working on ({a}.)");
    }

    public void DoSomethingElse(string b)
    {
        Console.WriteLine($"Receiver: Also working on ({b}.)");
    }
}

class Invoker
{
    private ICommand? _startCommand;
    private ICommand? _endCommand;

    public void SetStartCommand(ICommand command)
    {
        _startCommand = command;
    }
    public void SetEndCommand(ICommand command)
    {
        _endCommand = command;
    }

    public void DoSomething()
    {
        Console.WriteLine("Start working...");
        if (_startCommand != null)
        {
            _startCommand.Execute();
        }

        if (_endCommand != null)
        {
            _endCommand.Execute();
        }
        Console.WriteLine("End working...");
    }
}