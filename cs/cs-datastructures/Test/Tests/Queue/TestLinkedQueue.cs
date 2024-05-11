namespace Tests;

public partial class Test
{
    public static void TestLinkedQueue()
    {
        var lQueue = new LinkedQueue<int>();

        for (int i = 0; i < 10; i++)
        {
            lQueue.EnQueue(i);
        }

        Console.WriteLine(lQueue);
        Console.WriteLine();

        lQueue.DeQueue();

        foreach (int elem in lQueue)
        {
            Console.WriteLine(elem);
        }
    }
}