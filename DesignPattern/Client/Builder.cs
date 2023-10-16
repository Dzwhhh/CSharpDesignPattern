using System;
using DesignPattern.Patterns.CreationalPatterns;

namespace DesignPattern.Client;

public class Builder: IAbstractClient
{
    public void Execute()
    {
        IBuilder builder = new ConcreteBuilder();
        Director director = new Director
        {
            Builder = builder
        };
        director.BuildMinimalViableProduct();

        if (builder is ConcreteBuilder cBuilder)
        {
            Product product = cBuilder.GetProduct();
            Console.WriteLine(product.ListParts());
        }
        
        director.BuildFullFeatureProduct();
        if (builder is ConcreteBuilder concreteBuilder)
        {
            Product product = concreteBuilder.GetProduct();
            Console.WriteLine(product.ListParts());
        }
    }
}