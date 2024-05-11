namespace Tests;

public partial class Test
{
    public static void TestLinkedStack()
    {
        var lStack = new LinkedStack<int>();

        for (int i = 0; i < 10; i++)
        {
            lStack.Push(i);
        }

        Console.WriteLine(lStack);
        Console.WriteLine();

        lStack.Pop();

        foreach (int elem in lStack)
        {
            Console.WriteLine(elem);
        }
    }
}