using DesignPattern.Patterns.StructuralPatterns;

namespace DesignPattern.Client;

public class FlyweightClient: IAbstractClient
{
    public void Execute()
    {
        var factory = new FlyweightFactory
        (
            new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
            new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
            new Car { Company = "BMW", Model = "X6", Color = "white" }
        );
        
        factory.ListFlyweights();
        Car concreteCar = new Car()
        {
            Owner = "Damian",
            Number = "L6868R",
            Company = "Mercedes Benz",
            Model = "C500",
            Color = "red"
        };
        var flyweight = factory.GetFlyweight(new Car()
        {
            Company = "Mercedes Benz",
            Model = "C500",
            Color = concreteCar.Color
        });
        
        flyweight.Operation(concreteCar);
    }
}