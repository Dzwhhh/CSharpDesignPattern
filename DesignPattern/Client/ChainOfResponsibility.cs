using DesignPattern.Patterns.BehavioralPatterns;

namespace DesignPattern.Client;

public class ChainOfResponsibility: IAbstractClient
{
    public void Execute()
    {

        AbstractHandler monkey = new MonkeyHandler();
        AbstractHandler squirrel = new SquirrelHandler();
        AbstractHandler dog = new DogHandler();
        
        monkey.SetNext(squirrel).SetNext(dog);
        
        string food = "Shit";
        Console.WriteLine(monkey.Handle(food));

        food = "Rubbish";
        Console.WriteLine(squirrel.Handle(food));
    }
}