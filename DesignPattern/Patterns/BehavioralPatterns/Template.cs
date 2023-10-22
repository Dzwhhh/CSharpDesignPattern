namespace DesignPattern.Patterns.BehavioralPatterns;

/*
 * 算法可以被拆分成多个子步骤
 * 子类可以针对子步骤进行不同的实现
 * 子类继承自抽象类，抽象类中定义模版方法，描述算法抽象实现
 */

abstract class AbstractClass
{
    public void TemplateMethod()
    {
        BaseOperation1();
        RequiredOperations1();
        Hook1();
        Hook2();
    }

    protected void BaseOperation1()
    {
        Console.WriteLine("AbstractClass says: I am doing the bulk of the work");
    }
    
    // THis operation have to be implemented in subclasses.
    protected abstract void RequiredOperations1();
    
    
    // These are "hooks." It's not mandatory for subclassed to override them
    //  since the hooks already have default implementation.
    protected virtual void Hook1() {}
    
    protected virtual void Hook2() {}
}

class ConcreteClass1 : AbstractClass
{
    protected override void RequiredOperations1()
    {
        Console.WriteLine("ConcreteClass1 says: Implemented Operation1");
    }

    protected override void Hook1()
    {
        Console.WriteLine("ConcreteClass1 says: Overridden Hook1");
    }
}

class ConcreteClass2 : AbstractClass
{
    protected override void RequiredOperations1()
    {
        Console.WriteLine("ConcreteClass2 says: Implemented Operation1");
    }
    
    protected override void Hook2()
    {
        Console.WriteLine("ConcreteClass2 says: Overridden Hook2");
    }
}