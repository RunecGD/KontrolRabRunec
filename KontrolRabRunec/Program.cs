using KontrolRabRunec;

public class Program
{
    static void Main()
    {
        SchoolBag schoolBag=new SchoolBag();
        schoolBag.Add(new TextBook(1000, "Математика"));
        schoolBag.Add(new NoteBook(2000, 10));
        schoolBag.Add(new NoteBook(1000, 20));
        Console.WriteLine(schoolBag);
        Console.WriteLine();
        schoolBag.SortItems();
        Console.WriteLine(schoolBag);
        Console.WriteLine();
        schoolBag.Remove();
        Console.WriteLine(schoolBag);
        if (schoolBag.SearchMasamatic())
        {
            Console.WriteLine("В рюкзаке лежит учебник математики");
        }
        else
        {
            Console.WriteLine("Нет учебника по математике");
        }
        string filePath = "schoolBag.xml";
        schoolBag.SerializeToXml(filePath);
        Console.WriteLine($"Serialized to {filePath}");

        // Десериализация из XML
        SchoolBag deserializedBag = SchoolBag.DeserializeFromXml(filePath);
        Console.WriteLine("Deserialized School Bag:");
        Console.WriteLine(deserializedBag);
    }
    
}