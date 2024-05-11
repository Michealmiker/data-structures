namespace Tests;

public partial class Test
{
    public static void TestLinkedList()
    {
        var lList = new DataStructure.Linear.List.LinkedList<int>();

        for (var i = 0; i < 10; i++)
        {
            lList.Add(i);
        }

        Console.WriteLine(lList);
        Console.WriteLine();

        lList.Remove();
        lList.RemoveFirst();
        lList.AddFirst(100);

        foreach (var elem in lList)
        {
            Console.WriteLine(elem);
        }
    }
}