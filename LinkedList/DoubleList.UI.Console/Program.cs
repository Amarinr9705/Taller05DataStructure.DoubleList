using DoubleList;

var list = new DoubleLinkedList<string>();
var opc = "0";

do
{
    opc = Menu();
    switch (opc)
    {
        case "1":
            Console.Write("Enter a value: ");
            var value = Console.ReadLine() ?? string.Empty;
            list.OrderedInsert(value);
            break;

        case "2":
            Console.WriteLine("List forward:");
            Console.WriteLine(list.ShowForward());
            break;

        case "3":
            Console.WriteLine("List backward:");
            Console.WriteLine(list.ShowBackward());
            break;

        case "4":
            Console.Write("Enter a value to delete the first coincidence: ");
            var valueDelete = Console.ReadLine() ?? string.Empty;
            list.RemoveFirstCoincidence(valueDelete);
            break;

        case "5":
            Console.Write("Enter a value to delete all the coincidences: ");
            var valueToDeleteAll = Console.ReadLine() ?? string.Empty;
            list.RemoveAllCoindicences(valueToDeleteAll);
            break;

        case "6":
            Console.Write("Enter a value to search: ");
            var valueSearch = Console.ReadLine() ?? string.Empty;
            Console.WriteLine(list.Exists(valueSearch));
            break;

        case "7":
            Console.WriteLine("Sort Descending:");
            list.SortDescending();
            break;

        case "8":
            Console.WriteLine("Show modes:");
            Console.WriteLine(list.ShowMode());
            break;
        case "9":
            Console.WriteLine("Show modes:");
            Console.WriteLine(list.ShowGraphicMode());
            break;

        case "0":
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}
while (opc != "0");

string Menu()
{
    Console.WriteLine("1. Instert ordered value");
    Console.WriteLine("2. Show list forward");
    Console.WriteLine("3. Show list backward");
    Console.WriteLine("4. Delete first coindicence");
    Console.WriteLine("5. Delete all coindicences");
    Console.WriteLine("6. Exists");
    Console.WriteLine("7. Sort descending");
    Console.WriteLine("8. Show modes");
    Console.WriteLine("9. Show graph");
    Console.WriteLine("0. Exit");
    Console.Write("Select an option: ");
    return Console.ReadLine() ?? "0";
}