namespace DesignPattern.Patterns.BehavioralPatterns;

/*
 * 针对完成同一目标，不同的条件下需要使用不同的策略或者算法变体
 * 声明该算法所有变体的通用策略接口，并将各个策略作为独立的类，实现包含Execute方法的接口
 * 上下文Context类支持在运行时设置或者切换当前选择的策略（关联关系）
 * 客户端负责初始化上下文，并按照条件设置策略，调用上下文的Exec方法，其内部封装了策略的Execute方法
 */

public class StrategyContext
{
    private IStrategy? _strategy;

    public StrategyContext(IStrategy strategy)
    {
        SetStrategy(strategy);
    }

    public void SetStrategy(IStrategy strategy)
    {
        Console.WriteLine($"Current Strategy: {strategy.GetType().Name}");
        _strategy = strategy;
    }

    public void DoSomething()
    {
        var rawList = new List<string>() { "a", "c", "b", "e", "d" };
        var resultList = _strategy!.Execute(rawList);

        string result = "";
        foreach (var elem in resultList)
        {
            result += $"{elem} ";
        }
        result.TrimEnd();

        Console.WriteLine($"After sort: {result}");
    }
}

public interface IStrategy
{
    List<string> Execute(List<string> strList);
}

public class AutoSortDescStrategy : IStrategy
{
    public List<string> Execute(List<string> strList)
    {
        var resultList = new List<string>(strList);
        resultList.Sort();
        resultList.Reverse();

        return resultList;
    }
}

public class ManualSortAscStrategy : IStrategy
{
    public List<string> Execute(List<string> strList)
    {
        for (int i = 1; i < strList.Count; i++)
        {
            string tempElem = strList[i];
            int j = i - 1;
            while (j >= 0 &&
                   string.Compare(strList[j], strList[j + 1], StringComparison.CurrentCulture) > 0)
            {
                strList[j + 1] = strList[j];
                j--;
            }
            strList[j + 1] = tempElem;
        }
        
        return strList;
    }
}