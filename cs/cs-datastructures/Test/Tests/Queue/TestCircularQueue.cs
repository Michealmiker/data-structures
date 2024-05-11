namespace Tests;

public partial class Test
{
    public static void TestCircularQueue()
    {
        var cQueue = new CircularQueue<int>(10);

        for (int i = 0; i < 10; i++)
        {
            cQueue.EnQueue(i);
        }

        Console.WriteLine(cQueue);
        Console.WriteLine();

        cQueue.DeQueue();
        cQueue.DeQueue();
        cQueue.EnQueue(100);
        cQueue.EnQueue(28);

        foreach (int elem in cQueue)
        {
            Console.WriteLine(elem);
        }
    }
}