namespace DesignPattern.Patterns.CreationalPatterns;

// 定义接口
public interface IProduct
{
    string Operation();
}

// 定义具体的接口实现类
class ConcreteProduct1 : IProduct
{
    public string Operation()
    {
        return "{Result of ConcreteProduct1}";
    }
}

class ConcreteProduct2 : IProduct
{
    public string Operation()
    {
        return "{Result of ConcreteProduct2}";
    }
}

// 定义工厂基类
abstract class Creator
{
    public abstract IProduct FactoryMethod();

    public string DoSomeOperation()
    {
        var product = FactoryMethod();
        var result = "Creator: The same creator's code has just worked with" + product.Operation();

        return result;
    }
}

// 定义工厂子类
class ConcreteCreator1 : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct1();
    }
}

class ConcreteCreator2 : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct2();
    }
}
