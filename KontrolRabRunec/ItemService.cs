namespace KontrolRabRunec;

public class ItemService
{
    public static void AddItem(SchoolBag schoolBag)
        {
            Item item = null;

            while (item == null) 
            {
                Console.WriteLine("Choose an item to add:");
                Console.WriteLine("1. NoteBook");
                Console.WriteLine("2. TextBook");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        item = CreateNoteBook();
                        break;
                    case "2":
                        item = CreateTextBook();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            schoolBag.Add(item);
            Console.WriteLine($"{item.GetType().Name} added.");
        }

        static NoteBook CreateNoteBook()
        {
            int weight = GetPositiveInteger("Enter weight of the NoteBook (in grams): ");
            int pages = GetPositiveInteger("Enter number of pages: ");
            return new NoteBook(weight, pages);
        }

        static TextBook CreateTextBook()
        {
            int weight = GetPositiveInteger("Enter weight of the TextBook (in grams): ");
            Console.Write("Enter subject of the TextBook: ");
            string subject;

            while (true)
            {
                subject = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(subject)) break;
                Console.Write("Subject cannot be empty. Please enter a valid subject: ");
            }

            return new TextBook(weight, subject);
        }

        static int GetPositiveInteger(string prompt)
        {
            int value = 0;

            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    value = int.Parse(Console.ReadLine());
                    if (value <= 0) throw new ArgumentOutOfRangeException("Value must be greater than 0.");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return value;
        }

    public static void ShowContents(SchoolBag schoolBag)
    {
        Console.WriteLine("Contents of the School Bag:");
        Console.WriteLine(schoolBag);
        Console.WriteLine($"Total Weight: {schoolBag.Weight} grams");
    }

    public static void ChechPageCount(SchoolBag schoolBag)
    {
        if (schoolBag.HasNoteBooksWithPagesMoreThan12())
            Console.WriteLine("There are notebooks with more than 12 pages in the backpack.");
        else
            Console.WriteLine("There are no notebooks with more than 12 pages.");
    }
    public static void RemoveItem(SchoolBag schoolBag)
    {
        if (schoolBag.ItemCount == 0)
        {
            Console.WriteLine("The school bag is empty. Nothing to remove.");
            return;
        }

        Console.WriteLine("Contents of the School Bag:");
        var items = schoolBag.GetItems();
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.Write("Enter the number of the item to remove: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= items.Count)
        {
            schoolBag.Remove(index - 1); 
            Console.WriteLine("Item removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid number. Please try again.");
        }
    }
}