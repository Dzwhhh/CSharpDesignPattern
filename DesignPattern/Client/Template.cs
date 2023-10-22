using DesignPattern.Patterns.BehavioralPatterns;

namespace DesignPattern.Client;

public class Template: IAbstractClient
{
    public void Execute()
    {
        ConcreteClass1 concreteClass1 = new ConcreteClass1();
        concreteClass1.TemplateMethod();

        ConcreteClass2 concreteClass2 = new ConcreteClass2();
        concreteClass2.TemplateMethod();
    }
}