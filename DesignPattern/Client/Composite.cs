using System;
using DesignPattern.Patterns.StructuralPatterns;

namespace DesignPattern.Client
{
	public class Composite: IAbstractClient
	{
		public void Execute()
		{
			AbstractComponent leafA = new Leaf("leafA");
			AbstractComponent leafB = new Leaf("leafB");

			AbstractComponent LowerNode = new CompositeNode();
            LowerNode.Add(leafA);
            LowerNode.Add(leafB);

			AbstractComponent leafC = new Leaf("leafC");
            AbstractComponent HigherNode = new CompositeNode();
			HigherNode.Add(leafC);
			HigherNode.Add(LowerNode);

			Console.WriteLine(HigherNode.Operation());
        }
	}
}

