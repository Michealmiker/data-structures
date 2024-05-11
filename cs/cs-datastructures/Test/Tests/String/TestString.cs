namespace Tests;

using String = DataStructure.Linear.String.String;

public partial class Test
{
    public static void TestString()
    {
        var s = new String(['H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd', '!']);

        Console.WriteLine(s);
        Console.WriteLine();

        var s1 = s.Concat([' ', 'I', '\'', 'm', ' ', 'M', 'i', 'k', 'e', '.']);

        Console.WriteLine(s1);
        Console.WriteLine();

        var sb = new StringBuilder();
        var rand = new Random(DateTime.Now.Millisecond);
        sb.Clear();

        for (int i = 0; i < 255; i++)
        {
            sb.Append((char)rand.Next(0, 128));
        }

        var s2 = s.Concat(sb.ToString().ToCharArray());

        Console.WriteLine(s2.Count);
        Console.WriteLine();

        var s3 = s.SubString(3, 8);

        Console.WriteLine(s3);
        Console.WriteLine();

        var index = s1.IndexOf(s3);

        Console.WriteLine(index);
        Console.WriteLine();

        var index1 = s1.IndexOf(new(['9']));

        Console.WriteLine(index1);
        Console.WriteLine();

        var index3 = s1.IndexOf_KMP(s3);

        Console.WriteLine(index3);
        Console.WriteLine();

        var index4 = s1.IndexOf_KMP(new(['!']));

        Console.WriteLine(index4);
    }
}