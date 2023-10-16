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
SingletonClient singletonClient = new SingletonClient();
singletonClient.Execute();


/*结构型模式示例*/
Console.WriteLine("适配器模式");
AdapterClient adapterClient = new AdapterClient();
adapterClient.Execute();

Console.WriteLine("代理模式");
Proxy proxy = new Proxy();
proxy.Execute();

Console.WriteLine("装饰器模式");
DecoratorClient decoratorClient = new DecoratorClient();
decoratorClient.Execute();

Console.WriteLine("桥接模式");
Bridge bridge = new Bridge();
bridge.Execute();