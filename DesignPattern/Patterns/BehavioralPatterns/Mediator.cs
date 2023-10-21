namespace DesignPattern.Patterns.BehavioralPatterns;

/*
 * 存在一组对象紧密耦合
 * 中介者模式使各对象仅与中介者交流
 * 对象可通过中介者通知其他对象
 * 实际中介者继承自中介者接口，定义Notify方法
 * 具体对象实现自Component类，依赖于中介者成员属性
 */

public interface IMediator
{
    void Notify(object sender, string ev);
    void BindComponent(BaseComponent component);
}

public class BaseComponent
{
    protected IMediator? Mediator;

    public void SetMediator(IMediator mediator)
    {
        Mediator = mediator;
        Mediator.BindComponent(this);
    }
}

public class Component1 : BaseComponent
{
    public void DoA()
    {
        Console.WriteLine("Component 1 does A");
        Mediator.Notify(this, "A");
    }

    public void DoB()
    {
        Console.WriteLine("Component 1 does B");
        Mediator.Notify(this, "B");
    }

    public override string ToString()
    {
        return "Component1";
    }
}

public class Component2 : BaseComponent
{
    public void DoC()
    {
        Console.WriteLine("Component 2 does C");
        Mediator.Notify(this, "C");
    }

    public void DoD()
    {
        Console.WriteLine("Component 2 does D");
        Mediator.Notify(this, "D");
    }
    
    public override string ToString()
    {
        return "Component2";
    }
}

public class ConcreteMediator : IMediator
{
    private Component1 _component1;

    private Component2 _component2;

    public void BindComponent(BaseComponent component)
    {
        if (component is Component1 c1)
        {
            _component1 = c1;
        }

        if (component is Component2 c2)
        {
            _component2 = c2;
        }
    }
    
    public void Notify(object sender, string ev)
    {
        Console.WriteLine($"sender: {sender}");
        // 控制对象之间的交流关系
        if (ev == "A")
        {
            Console.WriteLine("Mediator reacts on A and triggers following operations:");
            _component2.DoC();
        }
        if (ev == "D")
        {
            Console.WriteLine("Mediator reacts on D and triggers following operations:");
            _component1.DoB();
        }
    }
}