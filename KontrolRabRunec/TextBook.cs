namespace KontrolRabRunec;
[Serializable]

public class TextBook : Item
{
    public TextBook():base(){}
    public string Name { get; set; }
    public TextBook(int weight, string name) : base(weight)
    {
        Name = name;
    }

    public override string ToString()
    {
        return base.ToString() + $" Name: {Name}";
    }
}