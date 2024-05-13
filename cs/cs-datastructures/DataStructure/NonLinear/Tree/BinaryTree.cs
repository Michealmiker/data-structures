namespace DataStructure.NonLinear.Tree;

/// <summary>
/// 二叉树
/// </summary>
public class BinaryTree : Common.IEnumerable<uint>
{
    /// <summary>
	/// 长度
	/// </summary>
	public int Count { get; private set; }

    /// <summary>
    /// 树是否为空
    /// </summary>
    public bool IsEmpty => Count == 0;

    private Node? _root = null;

    public BinaryTree(string definition) => InitTree(definition);

    public BinaryTree() : this(string.Empty) => Count = 0;

    /// <summary>
    /// 初始化树
    /// [广度遍历]
    /// </summary>
    /// <remarks>
    /// 节点为uint类型
    /// -1为空节点
    /// </remarks>
    /// <example>
    /// input: 0>1>2>3>4>-1>5
    /// tree:
    ///      0
    ///    /   \
    ///   1     2
    ///  / \     \
    /// 3   4     5
    /// </example>
    /// <param name="definition"></param>
    private void InitTree(string definition)
    {
        Count = 0;

        if (definition is null
            || string.IsNullOrWhiteSpace(definition))
        {
            return;
        }

        var indexArray = definition.Split('>').Select(int.Parse).ToArray();
        var span = (Span<int>)indexArray;
        var length = indexArray.Length;

        var ptr = _root;
        var nodeList = new List<Node>();
        var isPreNodeEmpty = false;

        for (var i = 0; i < length; i++)
        {
            if (nodeList.Count > 0)
            {
                ptr = nodeList[0];

                // Console.WriteLine($"\n\n\n\ncurrent output node: {ptr!.dataArea}");
            }

            var val = span[i];

            // Console.WriteLine($"current node: {val}");

            if (val != Global.InvalidIndex)
            {
                var newNode = new Node
                {
                    dataArea = (uint)val
                };

                if (ptr is null)
                {
                    ptr = newNode;

                    // Console.WriteLine("into root");
                }
                else if (!isPreNodeEmpty && ptr.leftChild is null)
                {
                    ptr.leftChild = newNode;

                    // Console.WriteLine("into left child");
                }
                else
                {
                    ptr.rightChild = newNode;

                    nodeList.Remove(ptr);

                    if (ptr.leftChild is not null)
                    {
                        nodeList.Add(ptr.leftChild);
                    }

                    nodeList.Add(ptr.rightChild);

                    // Console.WriteLine("into right child");
                }

                isPreNodeEmpty = false;
            }
            else
            {
                if (ptr!.leftChild is null)
                {
                    nodeList.Insert(0, ptr);

                    // Console.WriteLine("into left child empty");
                }

                isPreNodeEmpty = true;
            }

            if (Count == 0)
            {
                _root = ptr;
            }

            // PrintList(nodeList);

            Count++;
        }

        nodeList.Clear();
        nodeList = null;
    }

    /// <summary>
    /// 清空二叉树
    /// </summary>
    public void ClearAll()
    {
        if (IsEmpty)
        {
            return;
        }

        _root = null;
        Count = 0;
    }

    /// <summary>
    /// 基于先序遍历进行打印
    /// </summary>
    public void PrintWithPreOrder()
    {
        var results = GetTopologicalOrder(TraversalOrder.PreOrder);

        Console.WriteLine("先序遍历");
        Console.WriteLine(string.Join(", ", results));
    }

    /// <summary>
    /// 基于中序遍历进行打印
    /// </summary>
    public void PrintWithInOrder()
    {
        var results = GetTopologicalOrder(TraversalOrder.InOrder);

        Console.WriteLine("中序遍历");
        Console.WriteLine(string.Join(", ", results));
    }

    /// <summary>
    /// 基于中序遍历进行打印
    /// </summary>
    public void PrintWithPostOrder()
    {
        var results = GetTopologicalOrder(TraversalOrder.PostOrder);

        Console.WriteLine("后序遍历");
        Console.WriteLine(string.Join(", ", results));
    }

    /// <summary>
    /// 获取拓扑顺序
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    private uint?[] GetTopologicalOrder(TraversalOrder order)
        => order switch
        {
            TraversalOrder.PreOrder => GetPreOrder(),
            TraversalOrder.InOrder => GetInOrder(),
            TraversalOrder.PostOrder => GetPostOrder(),
            _ => throw new NotImplementedException()
        };

    /// <summary>
    /// 获取先序遍历拓扑顺序
    /// </summary>
    /// <returns></returns>
    private uint?[] GetPreOrder()
    {
        if (IsEmpty)
        {
            return Array.Empty<uint?>();
        }

        var checkStack = new Stack<Node>();
        var resultQueue = new Queue<uint?>();

        checkStack.Push(_root!);

        while (checkStack.Any())
        {
            var ptr = checkStack.Pop();

            if (ptr is not null)
            {
                resultQueue.Enqueue(ptr.dataArea);
            }
            else
            {
                continue;
            }

            if (ptr!.rightChild is not null)
            {
                checkStack.Push(ptr.rightChild);
            }

            if (ptr!.leftChild is not null)
            {
                checkStack.Push(ptr.leftChild);
            }
        }

        return resultQueue.ToArray();
    }

    /// <summary>
    /// 获取中序遍历拓扑顺序
    /// </summary>
    /// <returns></returns>
    private uint?[] GetInOrder()
    {
        if (IsEmpty)
        {
            return Array.Empty<uint?>();
        }

        var checkStack = new Stack<Node>();
        var resultQueue = new Queue<uint?>();

        checkStack.Push(_root!);

        while (checkStack.Any())
        {
            var ptr = checkStack.Pop();

            if (ptr.leftChild is not null
                && !checkStack.Contains(ptr.leftChild)
                && !resultQueue.Contains(ptr.leftChild.dataArea)
                || ptr.rightChild is not null
                && !checkStack.Contains(ptr.rightChild)
                && !resultQueue.Contains(ptr.rightChild.dataArea))
            {
                if (ptr.rightChild is not null)
                {
                    checkStack.Push(ptr.rightChild);
                }

                checkStack.Push(ptr);

                if (ptr.leftChild is not null)
                {
                    checkStack.Push(ptr.leftChild);
                }

                continue;
            }

            resultQueue.Enqueue(ptr.dataArea);
        }

        return resultQueue.ToArray();
    }

    /// <summary>
    /// 获取后序遍历拓扑顺序
    /// </summary>
    /// <returns></returns>
    private uint?[] GetPostOrder()
    {
        if (IsEmpty)
        {
            return Array.Empty<uint?>();
        }

        var checkStack = new Stack<Node>();
        var resultQueue = new Queue<uint?>();

        checkStack.Push(_root!);

        while (checkStack.Any())
        {
            var ptr = checkStack.Pop();

            if (ptr.leftChild is not null
                && !checkStack.Contains(ptr.leftChild)
                && !resultQueue.Contains(ptr.leftChild.dataArea)
                || ptr.rightChild is not null
                && !checkStack.Contains(ptr.rightChild)
                && !resultQueue.Contains(ptr.rightChild.dataArea))
            {
                checkStack.Push(ptr);

                if (ptr.rightChild is not null)
                {
                    checkStack.Push(ptr.rightChild);
                }

                if (ptr.leftChild is not null)
                {
                    checkStack.Push(ptr.leftChild);
                }

                continue;
            }

            resultQueue.Enqueue(ptr.dataArea);
        }

        return resultQueue.ToArray();
    }

    public Common.IEnumerator<uint> GetEnumerator() => new BinaryTreeEnumerator(this);

    /// <summary>
    /// 二叉树迭代器
    /// </summary>
    public class BinaryTreeEnumerator : Common.IEnumerator<uint>
    {
        public uint Current => _topologicalOrder[_index]!.Value;

        private uint?[] _topologicalOrder;

        private int _index = Global.InvalidIndex;

        public BinaryTreeEnumerator(BinaryTree enumerable) => _topologicalOrder = enumerable.GetTopologicalOrder(TraversalOrder.PreOrder);

        public bool MoveNext()
        {
            _index++;

            if (_index == _topologicalOrder.Length)
            {
                return false;
            }

            return true;
        }

        public void Reset() => _index = Global.InvalidIndex;
    }

    /// <summary>
    /// 二叉树节点
    /// </summary>
    private class Node
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public uint? dataArea;

        /// <summary>
        /// 左孩子指针
        /// </summary>
        public Node? leftChild;

        /// <summary>
        /// 右孩子指针
        /// </summary>
        public Node? rightChild;
    }

    /// <summary>
    /// 遍历顺序
    /// </summary>
    private enum TraversalOrder
    {
        /// <summary>
        /// 先序遍历
        /// </summary>
        PreOrder,
        /// <summary>
        /// 中序遍历
        /// </summary>
        InOrder,
        /// <summary>
        /// 后续遍历
        /// </summary>
        PostOrder
    }
}