#define STRING

#if STRING
using String = DataStructure.Linear.String.String;

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
#endif




#if CIRCULAR_QUEUE
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
#endif




#if LINKED_QUEUE
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
#endif




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
