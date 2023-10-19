using System;
namespace DesignPattern.Patterns.StructuralPatterns
{
	abstract class AbstractComponent
    {
		public AbstractComponent(){ }

		public abstract string Operation();

		public virtual void Add(AbstractComponent component)
		{
			throw new NotImplementedException();
		}

		public virtual void Remove(AbstractComponent component)
		{
            throw new NotImplementedException();
        }

		public virtual bool IsComposite()
		{
			return true;
		}
	}

    class Leaf: AbstractComponent
    {
        private readonly string _leafName;

        public Leaf(string leafName)
        {
            _leafName = leafName;
        }

        public override bool IsComposite()
        {
            return false;
        }

        public override string Operation()
        {
            return $"Leaf: {_leafName}";
        }
    }

    class CompositeNode: AbstractComponent
    {
        protected List<AbstractComponent> children = new List<AbstractComponent>();

        public override void Add(AbstractComponent component)
        {
            children.Add(component);
        }

        public override void Remove(AbstractComponent component)
        {
            if (children.Contains(component))
            {
                children.Remove(component);
            }
        }

        public override string Operation()
        {
            string result = "Branch(";

            int i = 0;
            foreach (AbstractComponent component in children)
            {
                result += component.Operation();
                if (i != children.Count - 1)
                {
                    result += "+";
                }
                i++;
            }
            result += ")";

            return result;
        }
    }
}

