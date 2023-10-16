using System;

namespace DesignPattern.Patterns.CreationalPatterns;

public class Singleton
{
    private static Singleton? _singleton;
    private static int initCount = 0;

    private Singleton()
    {
        initCount += 1;
        Console.WriteLine("Initialize Singleton");
    }

    public static Singleton GetInstance()
    {
        _singleton ??= new Singleton();
        return _singleton;
    }

    public string Echo()
    {
        return $"singleton has been initialized {initCount} times";
    }
}