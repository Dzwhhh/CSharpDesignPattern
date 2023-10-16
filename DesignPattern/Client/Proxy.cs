using System;
using DesignPattern.Patterns.StructuralPatterns;

namespace DesignPattern.Client
{
	public class Proxy: IAbstractClient
	{
		public Proxy()
		{
		}

        public void Execute()
        {
            RealSubject realSubject = new RealSubject();
            ProxySubject proxy = new ProxySubject(realSubject);
            proxy.Request();
        }
    }
}

