using System.Numerics;
using KontrolRabRunec;

public class Program
{
    static void Main()
    {
        SchoolBag schoolBag = new SchoolBag();
        string filePath = "schoolBag.xml";
        schoolBag = SchoolBag.DeserializeFromXml(filePath);
        Console.WriteLine("Deserialized School Bag");
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Sort Items");
            Console.WriteLine("3. Show Contents");
            Console.WriteLine("4. Check Notebook with PageCount > 12");
            Console.WriteLine("5. Total Weight All TextBook");
            Console.WriteLine("6. Remove Item");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an action (1-6): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ItemService.AddItem(schoolBag);
                    schoolBag.SerializeToXml(filePath);
                    Console.WriteLine($"Serialized to {filePath}");

                    break;
                case "2":
                    schoolBag.SortItems();
                    break;
                case "3":
                    ItemService.ShowContents(schoolBag);
                    break;
                case "4":
                    ItemService.ChechPageCount(schoolBag);
                    break;
                case "5":
                    Console.WriteLine("Total weight all textbook: " + schoolBag.TotalWeightAllTextBook());
                    break;
                case "6":
                    ItemService.RemoveItem(schoolBag);
                    schoolBag.SerializeToXml(filePath);
                    Console.WriteLine($"Serialized to {filePath}");
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}