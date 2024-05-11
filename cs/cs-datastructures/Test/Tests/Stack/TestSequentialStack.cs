namespace Tests;

public partial class Test
{
    public static void TestSequentialStack()
    {
        var sStack = new SequentialStack<int>();

        for (int i = 0; i < 10; i++)
        {
            sStack.Push(i);
        }

        Console.WriteLine(sStack);
        Console.WriteLine();

        sStack.Pop();

        foreach (int elem in sStack)
        {
            Console.WriteLine(elem);
        }
    }
}