namespace DesignPattern.Patterns.CreationalPatterns;

public class Person
{
    public int Age;
    public DateTime BirthDate;
    public string Name;
    public IdInfo IdInfo;

    public Person ShallowCopy()
    {
        return (Person)MemberwiseClone();
    }

    public Person DeepCopy()
    {
        Person clone = (Person)MemberwiseClone();
        clone.IdInfo = new IdInfo(IdInfo.IdNumber);

        return clone;
    }
}

public class IdInfo
{
    public int IdNumber { get; set; }

    public IdInfo(int idNumber)
    {
        IdNumber = idNumber;
    }
}