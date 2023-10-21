using DesignPattern.Patterns.BehavioralPatterns;

namespace DesignPattern.Client;

public class Strategy: IAbstractClient
{
    public void Execute()
    {
        IStrategy autoSortAlgo = new AutoSortDescStrategy();
        StrategyContext context = new StrategyContext(autoSortAlgo);
        context.DoSomething();
        
        context.SetStrategy(new ManualSortAscStrategy());
        context.DoSomething();
    }
}