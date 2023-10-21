using System.Linq;
using System.Collections;

namespace DesignPattern.Patterns.BehavioralPatterns;

/*
 * 需要对class A进行集合的迭代遍历，client不需要关心遍历的细节
 * class A实现IEnumerable接口，实现GetEnumerator方法，返回迭代器
 * 返回的迭代器B实现自IEnumerator接口，包含Current，MoveNext和Reset方法
 * foreach循环开始时，先获取A的迭代器实例B
 * foreach循环执行时，执行B的MoveNext方法，将迭代器移动到集合的下一个元素
 * 之后执行B的Current方法，获取迭代器所在的当前元素
 */

abstract class Iterator : IEnumerator
{

    object IEnumerator.Current => Current();

    public abstract int Key();

    public abstract object Current();

    public abstract bool MoveNext();

    public abstract void Reset();
}

abstract class IteratorAggregate : IEnumerable
{
    public abstract IEnumerator GetEnumerator();
}

class AlphabeticalOrderIterator : Iterator
{
    private readonly List<string> _collection;

    private int _position = -1;

    private readonly bool _reverse;

    public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
    {
        _collection = new List<string>(collection.GetItems());
        _collection.Sort();
        _reverse = reverse;

        if (_reverse)
        {
            _position = collection.GetItems().Count;
        }
    }
    
    public override int Key()
    {
        return _position;
    }
    
    public override object Current()
    {
        return _collection[_position];
    }

    public override bool MoveNext()
    {
        if (_reverse)
        {
            _position -= 1;
            return _position >= 0;
        }
        else
        {
            _position += 1;
            return _position <= _collection.Count - 1;
        }
    }

    public override void Reset()
    {
        _position = _reverse ? _collection.Count - 1 : 0;
    }
}

class WordsCollection : IteratorAggregate
{
    private readonly List<string> _collection = new List<string>();

    private bool _direction;

    public void ReverseDirection()
    {
        _direction = !_direction;
    }

    public List<string> GetItems()
    {
        return _collection;
    }

    public void AddItem(string item)
    {
        _collection.Add(item);
    }

    public override IEnumerator GetEnumerator()
    {
        return new AlphabeticalOrderIterator(this, _direction);
    }
}