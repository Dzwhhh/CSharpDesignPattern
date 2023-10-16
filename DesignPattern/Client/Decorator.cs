using System;
using DesignPattern.Patterns.StructuralPatterns;

namespace DesignPattern.Client
{
	public class DecoratorClient: IAbstractClient
	{
		public DecoratorClient()
		{
        }

		public void Execute()
		{
            Component concreteComponent = new ConcreteComponent();
            // A wraps Component
            Decorator decoratorA = new ConcreteDecoratorA(component: concreteComponent);
            Console.WriteLine(decoratorA.Operation());

            // B wraps A, A wraps Component
            Decorator decoratorB = new ConcreteDecoratorB(component: decoratorA);
            Console.WriteLine(decoratorB.Operation());
        }
	}
}

