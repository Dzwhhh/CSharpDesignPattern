using System;

using DesignPattern.Client;

/*创建者模式示例:*/
Console.WriteLine("工厂方法模式");
FactoryMethod factory = new FactoryMethod();
factory.Execute();

Console.WriteLine("抽象工厂模式");
AbstractFactory abstractFactory = new AbstractFactory();
abstractFactory.Execute();

Console.WriteLine("建造者模式");
Builder builder = new Builder();
builder.Execute();

Console.WriteLine("原型模式");
ProtoType protoType = new ProtoType();
protoType.Execute();

Console.WriteLine("单例模式");
SingletonClient singleton = new SingletonClient();
singleton.Execute();


/*结构型模式示例*/
