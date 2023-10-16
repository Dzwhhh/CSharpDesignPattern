using System;
namespace DesignPattern.Patterns.StructuralPatterns
{
	public interface ISubject
	{
		void Request();
	}

    class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    class ProxySubject : ISubject
    {
        private RealSubject? _realSubject;

        public ProxySubject(RealSubject realSubject)
        {
            _realSubject = realSubject;
        }

        public bool CheckAccess()
        {
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");

            return true;
        }

        public void Request()
        {
            if (CheckAccess())
            {
                _realSubject!.Request();
            }
            else
            {
                Console.WriteLine("Check failed, don't request");
            }
        }
    }
}

