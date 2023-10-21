using DesignPattern.Patterns.BehavioralPatterns;

namespace DesignPattern.Client;

public class StateClient: IAbstractClient
{
    public void Execute()
    {
        State initState = new ConcreteStateA();
        Context context = new Context(initState);
        
        context.Request1();
        context.Request2();
        context.Request2();
    }
}