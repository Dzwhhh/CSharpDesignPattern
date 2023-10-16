using System;
using DesignPattern.Patterns.CreationalPatterns;

namespace DesignPattern.Client;

public class AbstractFactory: IAbstractClient
{
    public void Execute()
    {
        // 创建ProductA 工厂，工厂内包含多个产品的创建，产品之间存在依赖关系
        ConcreteFactory1 factory1 = new ConcreteFactory1();
        
        IAbstractProductA productA1 = factory1.CreateProductA();
        Console.WriteLine(productA1.UsefulFunctionA());
        
        IAbstractProductB productB1 = factory1.CreateProductB();
        Console.WriteLine(productB1.UsefulFunctionB());
        Console.WriteLine(productB1.CollaborateWithProductA(productA1));
        
        // 常见ProductB 工厂
        ConcreteFactory2 factory2 = new ConcreteFactory2();

        IAbstractProductA productA2 = factory2.CreateProductA();
        Console.WriteLine(productA2.UsefulFunctionA());
        
        IAbstractProductB productB2 = factory2.CreateProductB();
        Console.WriteLine(productB2.UsefulFunctionB());
        Console.WriteLine(productB2.CollaborateWithProductA(productA2));
    }
}