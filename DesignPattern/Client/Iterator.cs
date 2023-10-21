using DesignPattern.Patterns.BehavioralPatterns;

namespace DesignPattern.Client;

public class IteratorClient: IAbstractClient
{
    public void Execute()
    {
        WordsCollection wordsCollection = new WordsCollection();
        wordsCollection.AddItem("Apple");
        wordsCollection.AddItem("Banana");
        wordsCollection.AddItem("Cargo");
       
        foreach (var item in wordsCollection)
        {
            Console.WriteLine(item as string);
        }
        
        wordsCollection.ReverseDirection();
        foreach (var item in wordsCollection)
        {
            Console.WriteLine(item as string);
        }
    }
}