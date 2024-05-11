namespace Tests;

public partial class Test
{
    public static void TestSequentialQueue()
    {
        var sQueue = new SequentialQueue<int>();

        for (int i = 0; i < 10; i++)
        {
            sQueue.EnQueue(i);
        }

        Console.WriteLine(sQueue);
        Console.WriteLine();

        sQueue.DeQueue();

        foreach (int elem in sQueue)
        {
            Console.WriteLine(elem);
        }
    }
}