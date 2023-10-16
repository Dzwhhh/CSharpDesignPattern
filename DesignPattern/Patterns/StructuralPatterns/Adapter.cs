using System;
namespace DesignPattern.Patterns.StructuralPatterns
{
	public interface ITarget
	{
		string GetRequest();
	}

	class Adaptee
	{
		public string GetSpecificRequest()
		{
			return "Specific request.";
        }
	}

    class Adapter : ITarget
    {
		private readonly Adaptee? _adaptee;

		public Adapter(Adaptee adaptee)
		{
			_adaptee = adaptee;
		}

        public string GetRequest()
        {
			// 针对adaptee的原始返回做处理，返回上层兼容的格式
            return $"This is '{_adaptee!.GetSpecificRequest()}'";
        }
    }
}

