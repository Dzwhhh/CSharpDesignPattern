using DesignPattern.Patterns.CreationalPatterns;

namespace DesignPattern.Client;

public class ProtoType: IAbstractClient
{
    public void Execute()
    {
        Person p1 = new Person();
        p1.Age = 24;
        p1.Name = "Damian Dai";
        p1.BirthDate = Convert.ToDateTime("1999-11-22");
        p1.IdInfo = new IdInfo(666);
        Console.WriteLine($"before modified, p1.IdNumber: {p1.IdInfo.IdNumber}");
        
        Person p2 = p1.ShallowCopy();
        Person p3 = p1.DeepCopy();
        
        p2.IdInfo.IdNumber = 888;
        Console.WriteLine($"after modified, p1.IdNumber: {p1.IdInfo.IdNumber}");
        Console.WriteLine($"p3.IdNumber: {p3.IdInfo.IdNumber}");
    }
}