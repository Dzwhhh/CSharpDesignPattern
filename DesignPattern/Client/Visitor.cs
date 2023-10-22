using DesignPattern.Patterns.BehavioralPatterns;

namespace DesignPattern.Client;

public class VisitorClient: IAbstractClient
{
    public void Execute()
    {
        ConcreteManagerA managerA = new ConcreteManagerA();
        ConcreteVisitor1 visitor1 = new ConcreteVisitor1();
        managerA.Accept(visitor1);

        ConcreteManagerB managerB = new ConcreteManagerB();
        ConcreteVisitor2 visitor2 = new ConcreteVisitor2();
        managerB.Accept(visitor1);
        managerB.Accept(visitor2);
    }
}