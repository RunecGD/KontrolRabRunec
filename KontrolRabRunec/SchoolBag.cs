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

    public void Remove()
    {
        if (Weight > 3000) // 3 kg = 3000 grams
        {
            var heaviestItem = Items.OrderByDescending(item => item.Weight).FirstOrDefault();
            if (heaviestItem != null)
            {
                Items.Remove(heaviestItem);
            }
        }
    }
    public bool SearchMasamatic()
    {
        return Items.OfType<TextBook>().Any(tb => tb.Name.Equals("Математика", StringComparison.OrdinalIgnoreCase));

    }
    public void SerializeToXml(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SchoolBag));
        using (TextWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, this);
        }
    }

    // Метод для десериализации из XML
    public static SchoolBag DeserializeFromXml(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SchoolBag));
        using (TextReader reader = new StreamReader(filePath))
        {
            return (SchoolBag)serializer.Deserialize(reader);
        }
    }
}