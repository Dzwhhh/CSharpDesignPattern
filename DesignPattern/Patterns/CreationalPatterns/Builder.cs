namespace DesignPattern.Patterns.CreationalPatterns;

public interface IBuilder
{
    void BuildPartA();

    void BuildPartB();

    void BuildPartC();
}

public class ConcreteBuilder : IBuilder
{
    private Product _product = new Product();

    public ConcreteBuilder()
    {
        Reset();
    }

    private void Reset()
    {
        _product = new Product();
    }
    
    public void BuildPartA()
    {
        _product.Add("PartA");
    }
    
    public void BuildPartB()
    {
        _product.Add("PartB");
    }
    
    public void BuildPartC()
    {
        _product.Add("PartC");
    }

    public Product GetProduct()
    {
        Product result = _product;
        Reset();

        return result;
    }
}

public class Product
{
    private readonly List<object> _parts = new List<object>();

    public void Add(string part)
    {
        this._parts.Add(part);
    }

    public string ListParts()
    {
        string str = string.Empty;

        foreach (var part in  _parts)
        {
            str += part + ", ";
        }

        str = str.Remove(str.Length - 2); // remove last ', '

        return $"Product parts: {str}";
    }
}

public class Director
{
    private IBuilder _builder = null!;

    public IBuilder Builder
    {
        set => _builder = value;
    }

    public void BuildMinimalViableProduct()
    {
        _builder.BuildPartA();
    }

    public void BuildFullFeatureProduct()
    {
        _builder.BuildPartA();
        _builder.BuildPartB();
        _builder.BuildPartC();
    }
}