using DesignPattern.Patterns.StructuralPatterns;

namespace DesignPattern.Client;

public class FacadeClient: IAbstractClient
{
    public void Execute()
    {
        SubSystemA systemA = new SubSystemA();
        SubSystemB systemB = new SubSystemB();

        Facade facade = new Facade(systemA, systemB);
        facade.DoOperation();
    }
}