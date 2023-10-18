using DesignPattern.Patterns.BehavioralPatterns;

namespace DesignPattern.Client;

public class CommandClient: IAbstractClient
{
    public void Execute()
    {

        ICommand simpleCmd = new SimpleCommand(payload: "say hello");
        ICommand complexCmd = new ComplexCommand(
            receiver: new Receiver(),
            a: "work1",
            b: "work2"
        );
        
        var invoker = new Invoker();
        invoker.SetStartCommand(simpleCmd);
        invoker.SetEndCommand(complexCmd);
        
        invoker.DoSomething();
    }
}