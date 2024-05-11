namespace Tests;

public partial class Test
{
    public static void TestCircularLinkedList()
    {
        var clList = new CircularLinkedList<int>();

        for (var i = 0; i < 10; i++)
        {
            clList.Add(i);
        }

        Console.WriteLine(clList);
        Console.WriteLine();

        clList.Remove();
        clList.RemoveFirst();
        clList.AddFirst(100);

        foreach (var elem in clList)
        {
            Console.WriteLine(elem);
        }
    }
}