using DesignPattern.Patterns.CreationalPatterns;

namespace DesignPattern.Client;

public class SingletonClient: IAbstractClient
{
    public void Execute()
    {
        Singleton single = Singleton.GetInstance();
        Console.WriteLine(single.Echo());
        
        Singleton.GetInstance();
        Console.WriteLine(single.Echo());
    }
}