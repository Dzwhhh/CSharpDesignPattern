using DesignPattern.Patterns.BehavioralPatterns;

namespace DesignPattern.Client;

public class Memento: IAbstractClient
{
    public void Execute()
    {
        Originator editor = new Originator("beginState");
        CareTaker taker = new CareTaker(editor);
        
        editor.DoSomething();
        taker.Backup();
        editor.DoSomething();
        taker.Backup();
        
        taker.ShowHistory();;
        taker.Undo();
        taker.ShowHistory();
    }
}