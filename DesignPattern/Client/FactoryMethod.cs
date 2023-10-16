using System;
using DesignPattern.Patterns.CreationalPatterns;

namespace DesignPattern.Client;

public class FactoryMethod: IAbstractClient
{
    public void Execute()
    {
        var creator1 = new ConcreteCreator1();
        Console.WriteLine(creator1.DoSomeOperation());

        var creator2 = new ConcreteCreator2();
        Console.WriteLine(creator2.DoSomeOperation());
    }
}