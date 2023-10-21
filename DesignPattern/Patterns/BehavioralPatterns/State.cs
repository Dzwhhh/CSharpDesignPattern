namespace DesignPattern.Patterns.BehavioralPatterns;

/*
 * 能够针对当前的应用模型抽离出有限状态机（对象存在多个状态转换，不同状态行为不同）
 * 将原先的主对象作为上下文，抽象出各个状态之间公共的方法，并依赖于State成员属性
 * 将原先多个状态作为独立的类，继承自基类State，State描述一组公共方法
 * 具体的State类依赖于上下文成员属性，能够在方法调用内切换上下文的当前状态，完成状态转换
 */

public class Context
{
    private State _state;

    public Context(State state)
    {
        TransitionTo(state);
    }

    public void TransitionTo(State state)
    {
        Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
        _state = state;
        _state.SetContext(this);
    }

    public void Request1()
    {
        _state.Handle1();
    }

    public void Request2()
    {
        _state.Handle2();
    }
}

public abstract class State
{
    protected Context Context;

    public void SetContext(Context context)
    {
        Context = context;
    }

    public abstract void Handle1();

    public abstract void Handle2();
}

public class ConcreteStateA : State
{
    public override void Handle1()
    {
        Console.WriteLine("ConcreteStateA handles request1.");
        Console.WriteLine("ConcreteStateA wants to change the state of the context.");
        Context.TransitionTo(new ConcreteStateB());
    }

    public override void Handle2()
    {
        Console.WriteLine("ConcreteStateA handles request2.");
    }
}

public class ConcreteStateB : State
{
    public override void Handle1()
    {
        Console.WriteLine("ConcreteStateB handles request1.");
    }

    public override void Handle2()
    {
        Console.WriteLine("ConcreteStateB handles request2.");
        Console.WriteLine("ConcreteStateB wants to change the state of the context.");
        Context.TransitionTo(new ConcreteStateA());
    }
}