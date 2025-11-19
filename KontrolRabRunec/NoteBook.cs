namespace KontrolRabRunec;
[Serializable]
public class NoteBook : Item
{
    public int PageCount { get; set; }
    public NoteBook():base(){}
    public NoteBook(int weight, int pageCount) : base(weight)
    {
        if (pageCount <= 0) throw new ArgumentOutOfRangeException(nameof(pageCount));
        PageCount = pageCount;
    }

    public override string ToString()
    {
        return base.ToString() + $" PageCount: {PageCount}";
    }
}