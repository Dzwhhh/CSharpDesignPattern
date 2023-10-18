using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DesignPattern.Patterns.StructuralPatterns;

/*
 程序需要创建非常多重复的对象（粒子系统），对内存有很大的消耗。
 这些重复对象可以抽离出不会变化的部分（内在状态）和会变化的部分（外在状态），
 那对于N个对象，可能内在状态只有常量C个（C << N），
 这C个内在状态就能够作为享元，仅被享元工厂初始化一次，作为列表/字典缓存在享元工厂。
 这些享元存在公共方法，接受外在状态作为参数，去实现不同的外在状态的行为。
 */

// 重点关注 形参 uniqueState, sharedState
public class Car
{
    public string? Owner { get; set; }
    
    public string? Number { get; set; }
    
    public string? Company { get; set; }
    
    public string? Model { get; set; }
    
    public string? Color { get; set; }
}

public class Flyweight
{
    private readonly Car _sharedState;

    public Flyweight(Car car)
    {
        _sharedState = car;
    }

    public void Operation(Car uniqueState)
    {
        string s = JsonConvert.SerializeObject(_sharedState);
        string u = JsonConvert.SerializeObject(uniqueState);
        
        Console.WriteLine($"Flyweight: Displaying shared {s} and unique {u} state.");
    }
}

public class FlyweightFactory
{
    private readonly List<Tuple<Flyweight, string>>? _flyweights = new();

    public FlyweightFactory(params Car[] cars)
    {
        foreach (var car in cars)
        {
            string key = CalculateKey(car);
            _flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(car), key));
        }
    }

    private string CalculateKey(Car car)
    {
        List<string> elements = new List<string>();
        
        elements.Add(car.Model);
        elements.Add(car.Color);
        elements.Add(car.Company);

        if (car.Owner != null && car.Number != null)
        {
            elements.Add(car.Owner);
            elements.Add(car.Number);
        }

        return string.Join('_', elements);
    }

    public Flyweight GetFlyweight(Car sharedState)
    {
        string key = CalculateKey(sharedState);

        if (!_flyweights.Any(t => t.Item2 == key))
        {
            Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
            _flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
        }
        else
        {
            Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
        }

        return _flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
    }

    public void ListFlyweights()
    {
        var count = _flyweights.Count;
        Console.WriteLine($"FlyweightFactory: I have {count} flyweights:");
        foreach (var flyweight in _flyweights)
        {
            Console.WriteLine(flyweight.Item2);
        }
    }
}