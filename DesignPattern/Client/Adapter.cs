﻿using System;
using DesignPattern.Patterns.StructuralPatterns;

namespace DesignPattern.Client
{
	public class AdapterClient: IAbstractClient
    {
		public AdapterClient()
		{
		}

        public void Execute()
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");

            Console.WriteLine(target.GetRequest());
        }
    }
}

