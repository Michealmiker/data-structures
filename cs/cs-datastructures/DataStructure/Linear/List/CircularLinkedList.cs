namespace DataStructure.Linear.List;

/// <summary>
/// 循环链表
/// </summary>
/// <typeparam name="T"></typeparam>
public class CircularLinkedList<T>
{
	/// <summary>
	/// 长度
	/// </summary>
	public int Count { get; private set; }

	/// <summary>
	/// 表是否为空
	/// </summary>
	public bool IsEmpty => Count == 0;

	/// <summary>
	/// 表头
	/// </summary>
	private Node _head;

	public CircularLinkedList()
	{
		_head = new()
		{
			dataArea = default
		};
		_head.next = _head;

		Count = 0;
	}

	/// <summary>
	/// 向表尾部插入新元素
	/// </summary>
	/// <param name="element"></param>
	public void Add(T element) => Insert(element, Count + 1);

	/// <summary>
	/// 向表头插入新元素
	/// </summary>
	/// <param name="element"></param>
	public void AddFirst(T element) => Insert(element, 1);

	/// <summary>
	/// [索引基于1]
	/// 插入元素
	/// </summary>
	/// <param name="element"></param>
	/// <param name="index"></param>
	public void Insert(T element, int index)
	{
		if (index < 1 || index > Count + 1)
		{
			throw new ArgumentOutOfRangeException(nameof(index));
		}

		var node = new Node
		{
			dataArea = element
		};

		var ptr = _head;
		for (var i = 0; i < index - 1; i++)
		{
			ptr = ptr!.next;
		}

		node.next = ptr!.next;
		ptr.next = node;

		Count++;
	}

	/// <summary>
	/// 移除尾部元素
	/// </summary>
	public void Remove() => RemoveAt(Count);

	/// <summary>
	/// 移除头部元素
	/// </summary>
	public void RemoveFirst() => RemoveAt(1);

	/// <summary>
	/// [索引基于1]
	/// 移除指定位置的元素
	/// </summary>
	/// <param name="index"></param>
	public void RemoveAt(int index)
	{
		if (index < 1 || index > Count)
		{
			throw new ArgumentOutOfRangeException(nameof(index));
		}

		if (IsEmpty)
		{
			throw new InvalidOperationException("List is empty");
		}

		var ptr = _head;

		for (var i = 0; i < index - 1; i++)
		{
			ptr = ptr!.next;
		}

		var node = ptr!.next;

		ptr!.next = ptr.next!.next;
		node!.next = null;

		Count--;
	}

	public override string ToString()
	{
		if (IsEmpty)
		{
			return "List is empty";
		}

		var ptr = _head.next;
		var sb = new StringBuilder();
		sb.Clear();

		while (ptr != _head)
		{
			sb.Append(ptr!.dataArea);

			if (ptr.next != _head)
			{
				sb.Append(", ");
			}

			ptr = ptr.next;
		}

		return sb.ToString();
	}

	public Common.IEnumerator<T> GetEnumerator() => new CircularLinkedListEnumerator(this);

	/// <summary>
	/// 链表迭代器
	/// </summary>
	public class CircularLinkedListEnumerator : Common.IEnumerator<T>
	{
		public T Current => _pointer.dataArea!;

		private CircularLinkedList<T> _enumerable;
		private Node _pointer;

		public CircularLinkedListEnumerator(CircularLinkedList<T> enumerable)
		{
			_enumerable = enumerable;
			_pointer = _enumerable._head;
		}

		public bool MoveNext()
		{
			_pointer = _pointer.next!;

			if (_pointer == _enumerable._head)
			{
				return false;
			}

			return true;
		}

		public void Reset() => _pointer = _enumerable._head;
	}

	/// <summary>
	/// 链表节点
	/// </summary>
	private class Node
	{
		/// <summary>
		/// 数据域
		/// </summary>
		public T? dataArea;

		/// <summary>
		/// 指针域
		/// </summary>
		public Node? next;
	}
}