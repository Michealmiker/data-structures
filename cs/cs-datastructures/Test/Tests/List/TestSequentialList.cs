namespace Tests;

public partial class Test
{
    public static void TestSequentialList()
    {
        var seqList = new SequentialList<int>();

        for (var i = 0; i < 10; i++)
        {
            seqList.Add(i);
        }

        Console.WriteLine(seqList);
        Console.WriteLine();

        seqList.Remove();
        seqList.RemoveFirst();
        seqList.AddFirst(100);

        foreach (var elem in seqList)
        {
            Console.WriteLine(elem);
        }
    }
}