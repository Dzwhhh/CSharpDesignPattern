using System.Net.Sockets;

namespace DesignPattern.Patterns.StructuralPatterns;

public class Facade
{
    protected SubSystemA subSystemA;
    protected SubSystemB subSystemB;

    public Facade(SubSystemA subSystemA, SubSystemB subSystemB)
    {
        this.subSystemA = subSystemA;
        this.subSystemB = subSystemB;
    }

    public void DoOperation()
    {
        // 编排子系统的行为
        subSystemA.Operation1();
        subSystemB.Operation2();
        
        subSystemA.Operation2();
        subSystemB.Operation1();
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