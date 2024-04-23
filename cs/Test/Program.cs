#define SEQUENTIAL_QUEUE

#if SEQUENTIAL_QUEUE
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
#endif




#if LINKED_STACK
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
#endif




#if SEQUENTIAL_STACK
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
#endif




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
