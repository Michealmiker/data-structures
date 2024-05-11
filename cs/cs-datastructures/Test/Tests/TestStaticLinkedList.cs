namespace Tests;

public partial class Test
{
    public static void TestStaticLinkedList()
    {
        var slList = new StaticLinkedList<int>(10);

        for (var i = 0; i < 10; i++)
        {
            slList.Add(i);
        }

        Console.WriteLine(slList);
        Console.WriteLine();

        slList.Remove();
        slList.RemoveFirst();
        slList.AddFirst(100);

        foreach (var elem in slList)
        {
            Console.WriteLine(elem);
        }
    }
}