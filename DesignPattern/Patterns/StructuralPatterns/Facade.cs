namespace DesignPattern.Patterns.StructuralPatterns;

/*
 存在多个子系统，子系统之间可能相互作用，逻辑较为复杂，
 客户端如何直接调用子系统的接口，传参角度，同时需要关心子系统的逻辑关系；
 考虑在子系统之上建立Facade类，子系统A、子系统B作为Facade类的成员，Facade类对外提供接口
 */

public class Facade
{
    private readonly SubSystemA _subSystemA;
    private readonly SubSystemB _subSystemB;

    public Facade(SubSystemA subSystemA, SubSystemB subSystemB)
    {
        this._subSystemA = subSystemA;
        this._subSystemB = subSystemB;
    }

    public void DoOperation()
    {
        // 编排子系统的行为
        _subSystemA.Operation1();
        _subSystemB.Operation2();
        
        _subSystemA.Operation2();
        _subSystemB.Operation1();
    }
}

public class SubSystemA
{
    public void Operation1()
    {
        Console.WriteLine("SubSystemA do operation1");
    }
    
    public void Operation2()
    {
        Console.WriteLine("SubSystemA do operation2");
    }
}

public class SubSystemB
{
    public void Operation1()
    {
        Console.WriteLine("SubSystemB do operation3");
    }
    
    public void Operation2()
    {
        Console.WriteLine("SubSystemB do operation4");
    }
}