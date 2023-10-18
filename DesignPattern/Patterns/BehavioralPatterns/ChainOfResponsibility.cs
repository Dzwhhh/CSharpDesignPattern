namespace DesignPattern.Patterns.BehavioralPatterns;

/*
 * 存在多个处理者，每个处理者负责独立的事情
 * 当某处理者无法处理该任务时，会将该任务交给后继的处理者处理
 * 处理者之间的串联关系构成了责任链，责任链无法保证任务一定会被处理
 * 不同特性的处理者继承自公共处理者，公共处理者实现了包含execute方法的接口
 * 公共处理者的execute方法，会判断是否存在后继结点，若存在则调用后继结点的execute
 * 特性处理者会判断自身能否处理任务，不能处理的话则调用公共处理者的execute方法，交给后继
 */

public interface IHandler
{
    IHandler SetNext(IHandler handler);

    object Handle(object request);
}

abstract class AbstractHandler : IHandler
{
    private IHandler? _nextHandler;

    public IHandler SetNext(IHandler handler)
    {
        _nextHandler = handler;
        return _nextHandler;
    }

    public virtual object Handle(object request)
    {
        if (_nextHandler != null)
        {
            return _nextHandler.Handle(request);
        }
        return $"Can't Handle: {request as string}";
    }
}

class MonkeyHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        if ((request as string) == "Banana")
        {
            return $"Monkey: I'll eat the {request}";
        }
        return base.Handle(request);
    }   
}

class SquirrelHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        if ((request as string) == "Nut")
        {
            return $"Squirrel: I'll eat the {request}";
        }
        return base.Handle(request);
    }   
}

class DogHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        if ((request as string) == "Shit")
        {
            return $"Dog: I'll eat the {request}";
        }
        return base.Handle(request);
    }   
}