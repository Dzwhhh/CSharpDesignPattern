namespace DesignPattern.Patterns.CreationalPatterns;

// 定义产品基类
public interface IAbstractProductA
{
    string UsefulFunctionA();
}

public interface IAbstractProductB
{
    string UsefulFunctionB();
    string CollaborateWithProductA(IAbstractProductA collaborator);
}

// 定义产品实现类
public class ConcreteProductA1 : IAbstractProductA
{
    public string UsefulFunctionA()
    {
        return "The result of the product A1.";
    }
}

public class ConcreteProductA2 : IAbstractProductA
{
    public string UsefulFunctionA()
    {
        return "The result of the product A2.";
    }
}

public class ConcreteProductB1 : IAbstractProductB
{
    public string UsefulFunctionB()
    {
        return "The result of the product B1.";
    }

    public string CollaborateWithProductA(IAbstractProductA collaborator)
    {
        var result = collaborator.UsefulFunctionA();
        return $"The result of the B1 collaborating with the ({result})";
    }
}

public class ConcreteProductB2 : IAbstractProductB
{
    public string UsefulFunctionB()
    {
        return "The result of the product B2.";
    }
    
    public string CollaborateWithProductA(IAbstractProductA collaborator)
    {
        var result = collaborator.UsefulFunctionA();
        return $"The result of the B2 collaborating with the ({result})";
    }
}

// 定义抽象工厂接口
public interface IAbstractFactory
{
    IAbstractProductA CreateProductA();
    IAbstractProductB CreateProductB();
}

// 定义工厂实现类
public class ConcreteFactory1 : IAbstractFactory
{
    public IAbstractProductA CreateProductA()
    {
        return new ConcreteProductA1();
    }

    public IAbstractProductB CreateProductB()
    {
        return new ConcreteProductB1();
    }
}

public class ConcreteFactory2 : IAbstractFactory
{
    public IAbstractProductA CreateProductA()
    {
        return new ConcreteProductA2();
    }

    public IAbstractProductB CreateProductB()
    {
        return new ConcreteProductB2();
    }
}
