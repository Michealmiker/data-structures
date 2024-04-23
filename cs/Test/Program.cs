#define DOUBLE_LINKED_LIST

#if DOUBLE_LINKED_LIST
var dlList = new DoubleLinkedList<int>();

for (var i = 0; i < 10; i++)
{
    dlList.Add(i);
}

Console.WriteLine(dlList);
Console.WriteLine();

dlList.Remove();
dlList.RemoveFirst();
dlList.AddFirst(100);

foreach (var elem in dlList)
{
    Console.WriteLine(elem);
}
#endif




#if CIRCULAR_LINKED_LIST
var clList = new CircularLinkedList<int>();

for (var i = 0; i < 10; i++)
{
    clList.Add(i);
}

Console.WriteLine(clList);
Console.WriteLine();

clList.Remove();
clList.RemoveFirst();
clList.AddFirst(100);

foreach (var elem in clList)
{
    Console.WriteLine(elem);
}
#endif




#if STATIC_LINKED_LIST
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
#endif




#if LINKED_LIST
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
#endif




#if SEQUENTIAL_LIST
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
#endif
