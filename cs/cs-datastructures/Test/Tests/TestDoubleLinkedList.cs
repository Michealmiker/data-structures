namespace Tests;

public partial class Test
{
    public static void TestDoubleLinkedList()
    {
        var dlList = new DoubleLinkedList<int>();

        for (var i = 0; i < 10; i++)
        {
            dlList.Add(i);
        }

        Console.WriteLine(dlList);
        Console.WriteLine();

        dlList.Remove();
        dlList.RemoveFirst();
        dlList.AddFirst(100);

        foreach (var elem in dlList)
        {
            Console.WriteLine(elem);
        }
    }
}