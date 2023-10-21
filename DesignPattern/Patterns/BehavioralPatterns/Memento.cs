namespace DesignPattern.Patterns.BehavioralPatterns;

/*
 * 备忘录模式允许编辑器生成并备份快照，或者从快照还原状态
 * 包含三个角色：编辑器（原发器）、快照（备忘录）、用户（负责人）
 * 负责人负责触发备份、备份还原等操作
 * 原发器负责生成备忘录、从制定备忘录还原等操作
 * 备忘录通常作为不可变的值对象，存储一次快照中的相关状态
 */

public interface IMemento
{
    string GetName();

    string GetState();

    DateTime GetDate();
}

class ConcreteMemento : IMemento
{
    private string _state;

    private DateTime _date;

    public ConcreteMemento(string state)
    {
        _state = state;
        _date = DateTime.Now;
    }
    
    public string GetState()
    {
        return _state;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public string GetName()
    {
        return $"{_date} / ({_state.Substring(0, 9)})...";
    }
}

class Originator
{
    private string _state;

    public Originator(string state)
    {
        _state = state;
        Console.WriteLine("Originator: My initial state is: " + state);
    }

    public void DoSomething()
    {
        Console.WriteLine("Originator: I'm doing something important.");
        _state = GenerateRandomString(30);
        Console.WriteLine($"Originator: and my state has changed to: {_state}");
    }

    private string GenerateRandomString(int length = 10)
    {
        string allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string result = string.Empty;

        while (length > 0)
        {
            result += allowedSymbols[new Random().Next(0, allowedSymbols.Length)];
            Thread.Sleep(10);
            length--;
        }

        return result;
    }

    public IMemento Save()
    {
        return new ConcreteMemento(state: _state);
    }

    public void Restore(IMemento memento)
    {
        if (!(memento is ConcreteMemento))
        {
            throw new Exception("Unknown memento class " + memento.ToString());
        }

        _state = memento.GetState();
        Console.Write($"Originator: My state has restored to: {_state}");
    }
}

class CareTaker
{
    private readonly List<IMemento> _mementos = new List<IMemento>();
    
    private readonly Originator _originator;

    public CareTaker(Originator originator)
    {
        _originator = originator;
    }

    public void Backup()
    {
        _mementos.Add(_originator.Save());
    }

    public void Undo()
    {
        if (_mementos.Count <= 0)
        {
            return;
        }

        IMemento mem = _mementos.Last();
        _mementos.Remove(mem);
        Console.WriteLine("Caretaker: Restoring state to: " + mem.GetName());
        
        try
        {
            _originator.Restore(mem);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Undo();
        }
    }

    public void ShowHistory()
    {
        Console.WriteLine("Caretaker: Here's the list of mementos:");

        foreach (var memento in _mementos)
        {
            Console.WriteLine(memento.GetName());
        }
    }
}



