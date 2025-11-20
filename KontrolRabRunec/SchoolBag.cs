using System.Xml.Serialization;

namespace KontrolRabRunec;
[Serializable]

public class SchoolBag
{
    public List<Item> Items { get; set; }
    
    public SchoolBag()
    {
        Items=new List<Item>();
    }
    public void Add(Item item)
    {
        Items.Add(item);
    }
    public int Weight => Items.Sum(item => item.Weight);

    public override string ToString()
    {
        return string.Join(Environment.NewLine, Items);
    }
    public void SortItems()
    {
        Items.Sort();
    }
    
    public bool HasNoteBooksWithPagesMoreThan12()
    {
        return Items.OfType<NoteBook>().Any(notebook => notebook.PageCount > 12);
    }

    public int TotalWeightAllTextBook()
    {
        return Items.OfType<TextBook>().Sum(textbook => textbook.Weight);
    }
    public void SerializeToXml(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SchoolBag));
        using (TextWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, this);
        }
    }

    public static SchoolBag DeserializeFromXml(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SchoolBag));
        using (TextReader reader = new StreamReader(filePath))
        {
            return (SchoolBag)serializer.Deserialize(reader);
        }
    }
    public void Remove(int index)
    {
        if (index < 0 || index >= Items.Count) throw new ArgumentOutOfRangeException("Index out of range.");
        Items.RemoveAt(index);
    }
    public List<Item> GetItems()
    {
        return Items;
    }
    public int ItemCount => Items.Count;

}