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

Console.WriteLine("组合模式");
Composite composite = new Composite();
composite.Execute();

Console.WriteLine("外观模式");
FacadeClient facadeClient = new FacadeClient();
facadeClient.Execute();

Console.WriteLine("享元模式");
FlyweightClient flyweightClient = new FlyweightClient();
flyweightClient.Execute();


/*行为型模式示例*/
Console.WriteLine("责任链模式");
ChainOfResponsibility chain = new ChainOfResponsibility();
chain.Execute();

Console.WriteLine("命令模式");
CommandClient commandClient = new CommandClient();
commandClient.Execute();

Console.WriteLine("迭代器模式");
IteratorClient iteratorClient = new IteratorClient();
iteratorClient.Execute();

Console.WriteLine("中介者模式");
MediatorClient mediatorClient = new MediatorClient();
mediatorClient.Execute();

Console.WriteLine("备忘录模式");
Memento memento = new Memento();
memento.Execute();

Console.WriteLine("观察者模式");
ObserverClient observerClient = new ObserverClient();
observerClient.Execute();

Console.WriteLine("状态模式");
StateClient stateClient = new StateClient();
stateClient.Execute();

Console.WriteLine("策略模式");
Strategy strategy = new Strategy();
strategy.Execute();