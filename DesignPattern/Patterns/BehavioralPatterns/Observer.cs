namespace DesignPattern.Patterns.BehavioralPatterns;

/*
 * 当一个对象状态的改变会影响其他对象，或者其他对象需要观察某对象时，可使用观察者模式
 * 观察者模式包含发布者和订阅者，发布者中维护订阅者的集合（List，Hashmap）
 * 发布者支持添加或者从集合中移除订阅者；根据事件类型管理订阅者；根据事件变化通知相关订阅者
 * 订阅者实现自相同的接口，实现相同的update方法，用于根据触发事件信息更新自身信息
 * 客户端负责创建发布者和订阅者对象，未订阅者注册发布者更新
 */

public enum EventType
{
    SportEvent = 0,
    TechEvent = 1
    
}
public interface IObserver
{
    void Update(IMessage message);
}

public interface ISubject
{
    void Attach(IObserver observer, EventType eventType);

    void Detach(IObserver observer, EventType eventType);

    void Notify(EventType eventType, IMessage message);
}

public interface IMessage
{
    string GetMsgTitle();

    string GetMsgContent();
}

public class Subject : ISubject
{
    private readonly Dictionary<EventType, List<IObserver>> _subscribers = new 
        Dictionary<EventType, List<IObserver>>();

    public Subject()
    {
        _subscribers.Add(EventType.SportEvent, new List<IObserver>());
        _subscribers.Add(EventType.TechEvent, new List<IObserver>());
    }

    public void Attach(IObserver observer, EventType eventType)
    {
        if (!_subscribers[eventType].Contains(observer))
        {
            Console.WriteLine($"Attach new Subscriber: {observer} for event: {eventType}");
            _subscribers[eventType].Add(observer);
        }
    }

    public void Detach(IObserver observer, EventType eventType)
    {
        if (_subscribers[eventType].Contains(observer))
        {
            Console.WriteLine($"Detach new Subscriber: {observer} for event: {eventType}");
            _subscribers[eventType].Remove(observer);
        }
    }

    public void ProcessDailyEvent()
    {
        var newSportMessage = new SportMessage(
            "DamianDai has won the World Wide Prize for tennis!");
        Notify(EventType.SportEvent, newSportMessage);

        var newTechMessage = new TechMessage(
            "DamianDai Has been the first man going on the Moon");
        Notify(EventType.TechEvent, newTechMessage);
    }
    
    public void Notify(EventType eventType, IMessage message)
    {
        var eventSubscribers = _subscribers[eventType];

        foreach (var subscriber in eventSubscribers)
        {
            subscriber.Update(message);
        }
    }
}

public class SportMessage : IMessage
{
    private readonly string _messageContent;

    public SportMessage(string content)
    {
        _messageContent = content;
    }
    
    public string GetMsgTitle()
    {
        string today = DateTime.Today.ToString("yy/MM/dd");
        return $"{today} - Daily Sport News!";
    }

    public string GetMsgContent()
    {
        return _messageContent;
    }
}

public class TechMessage : IMessage
{
    private readonly string _messageContent;

    public TechMessage(string content)
    {
        _messageContent = content;
    }
    
    public string GetMsgTitle()
    {
        string today = DateTime.Today.ToString("yy/MM/dd");
        return $"{today} - Daily Technology News!";
    }

    public string GetMsgContent()
    {
        return _messageContent;
    }
}

public class SportFans: IObserver
{
    private readonly string _fans;

    public SportFans(string fans)
    {
        _fans = fans;
    }
    
    public void Update(IMessage message)
    {
        Console.WriteLine($"{_fans} received sport news...");
        Console.WriteLine(message.GetMsgTitle());
        Console.WriteLine(message.GetMsgContent());
    }
}

public class TechFans: IObserver
{
    private readonly string _fans;

    public TechFans(string fans)
    {
        _fans = fans;
    }
    
    public void Update(IMessage message)
    {
        Console.WriteLine($"{_fans} received technology news...");
        Console.WriteLine(message.GetMsgTitle());
        Console.WriteLine(message.GetMsgContent());
    }
}