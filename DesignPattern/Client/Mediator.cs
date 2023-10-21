using DesignPattern.Patterns.BehavioralPatterns;

namespace DesignPattern.Client;

public class MediatorClient: IAbstractClient
{
    public void Execute()
    {
        ConcreteMediator mediator = new ConcreteMediator();
        Component1 c1 = new Component1();
        Component2 c2 = new Component2();
        
        // 建立对象和中介者的双向绑定关系
        c1.SetMediator(mediator);
        c2.SetMediator(mediator);
        
        c1.DoA();
        c2.DoD();
    }
}