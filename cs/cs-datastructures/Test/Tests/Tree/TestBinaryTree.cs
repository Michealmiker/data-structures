namespace Tests;

public partial class Test
{
    public static void TestBinaryTree()
    {
        var bt = new BinaryTree("0>1>2>3>4>-1>5");

        bt.PrintWithPreOrder();
        bt.PrintWithInOrder();
        bt.PrintWithPostOrder();
    }
}