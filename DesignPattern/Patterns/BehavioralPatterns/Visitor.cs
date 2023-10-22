namespace DesignPattern.Patterns.BehavioralPatterns;

/*
 * 访问者的目的是为类的层次结构添加外部操作，而无需修改类已有代码
 * 访问者作为独立类，封装一系列对其他类的数据访问和操作方法，针对不同类重写不同的visit方法
 * 其他具体类实现自公共接口Element，实现Accept方法，接受Visitor作为参数
 * 在Accept内部，将自身类的信息（this，...）交给Visitor（调用.visit(this)）
 * 可将访问者作为接口，以此实现不同的具体的访问者，实现具体的visit方法
 */

public interface IVisitor
{
    void VisitManager(ConcreteManagerA managerA);
    void VisitManager(ConcreteManagerB managerB);
}

public class ConcreteVisitor1: IVisitor
{
    public void VisitManager(ConcreteManagerA managerA)
    {
        Console.WriteLine("Visitor1 say hello to managerA.");
        Console.WriteLine($"{managerA.ShakeHand()}");
    }

    public void VisitManager(ConcreteManagerB managerB)
    {
        Console.WriteLine("Visitor1 say hello to managerB.");
        Console.WriteLine($"{managerB.RemainSilent()}");
    }
}

public class ConcreteVisitor2: IVisitor
{
    public void VisitManager(ConcreteManagerA managerA)
    {
        Console.WriteLine("Visitor2 say goodbye to managerA.");
        Console.WriteLine($"{managerA.SayGoodbye()}");
    }

    public void VisitManager(ConcreteManagerB managerB)
    {
        Console.WriteLine("Visitor2 is a friend to managerB.");
        Console.WriteLine($"{managerB.TellASecret()}");
    }
}

public interface IManager
{
    void Accept(IVisitor visitor);
}

public class ConcreteManagerA : IManager
{
    public string ShakeHand()
    {
        return "ManagerA shakes his hand.";
    }
    
    public string SayGoodbye()
    {
        return "ManagerA says goodbye to him.";
    }
    
    public void Accept(IVisitor visitor)
    {
        visitor.VisitManager(this);
    }
}

public class ConcreteManagerB : IManager
{
    public string RemainSilent()
    {
        return "ManagerB remains silent...";
    }
    
    public string TellASecret()
    {
        return "ManagerB tells a secret to him.";
    }
    
    public void Accept(IVisitor visitor)
    {
        visitor.VisitManager(this);
    }
}