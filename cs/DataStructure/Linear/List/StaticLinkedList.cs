namespace DataStructure.Linear.List;

/// <summary>
/// 静态链表
/// </summary>
/// <typeparam name="T"></typeparam>
public class StaticLinkedList<T> : Common.IEnumerable<T>
{
	/// <summary>
	/// 容量
	/// </summary>
	public int Capacity { get; private set; }

	/// <summary>
	/// 长度
	/// </summary>
	public int Count { get; private set; }

	/// <summary>
	/// 起始游标
	/// </summary>
	private int _startCursor;

	/// <summary>
	/// 未使用节点的起始游标
	/// </summary>
	private int _unusedCursor;

	/// <summary>
	/// 元素集合
	/// </summary>
	private Node[] _elements;

	/// <summary>
	/// 表是否为空
	/// </summary>
	public bool IsEmpty => Count == 0;

	public StaticLinkedList(int capacity)
	{
		Capacity = capacity;
		Count = 0;
		_startCursor = Global.InvalidIndex;
		_elements = new Node[capacity];

		Refresh();
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
			throw new ArgumentOutOfRangeException("index");
		}

		var newCur = GetUnusedNode();
		_elements[newCur].dataArea = element;

		if (newCur == Global.InvalidIndex)
		{
			throw new OutOfMemoryException();
		}

		_elements[newCur].dataArea = element;

		if (_startCursor == Global.InvalidIndex)
		{
			_elements[newCur].cursor = Global.InvalidIndex;
			_startCursor = newCur;

			Count++;

			return;
		}

		var cur = _startCursor;

		for (var i = 0; i < index - 2; i++)
		{
			cur = _elements[cur].cursor;
		}

		if (index == 1)
		{
			_elements[newCur].cursor = cur;
			_startCursor = newCur;
		}
		else
		{
			_elements[newCur].cursor = _elements[cur].cursor;
			_elements[cur].cursor = newCur;
		}

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

		if (Count == 0)
		{
			throw new InvalidOperationException("List is empty");
		}

		var delCur = Global.InvalidIndex;

		if (index == 1)
		{
			delCur = _startCursor;
			_startCursor = _elements[delCur].cursor;
		}
		else
		{
			var cur = _startCursor;

			for (var i = 0; i < index - 2; i++)
			{
				cur = _elements[cur].cursor;
			}

			delCur = _elements[cur].cursor;

			_elements[cur].cursor = _elements[delCur].cursor;
		}

		FreeNode(delCur);

		Count--;
	}

	public override string ToString()
	{
		if (IsEmpty)
		{
			return "List is empty";
		}

		var cur = _startCursor;
		var sb = new StringBuilder();
		sb.Clear();

		while (cur != Global.InvalidIndex)
		{
			sb.Append(_elements[cur].dataArea);

			if (cur != Global.InvalidIndex)
			{
				sb.Append(", ");
			}

			cur = _elements[cur].cursor;
		}

		return sb.ToString();
	}

	public Common.IEnumerator<T> GetEnumerator() => new StaticLinkedListEnumerator(this);

	/// <summary>
	/// 刷新
	/// </summary>
	private void Refresh()
	{
		var length = _elements.Length;

		_unusedCursor = Global.InvalidIndex;

		for (var i = 0; i < length; i++)
		{
			_elements[i] = new()
			{
				cursor = Global.InvalidIndex
			};

			if (i == 0)
			{
				_unusedCursor = i;
			}
			else
			{
				_elements[i - 1].cursor = i;
			}
		}
	}

	/// <summary>
	/// 获取未使用节点的游标
	/// </summary>
	/// <returns></returns>
	private int GetUnusedNode()
	{
		if (_unusedCursor == Global.InvalidIndex)
		{
			throw new OutOfMemoryException("No more unused node");
		}

		var cursor = _unusedCursor;

		_unusedCursor = _elements[_unusedCursor].cursor;

		return cursor;
	}

	/// <summary>
	/// 释放节点
	/// </summary>
	private void FreeNode(int cursor)
	{
		_elements[cursor].cursor = _unusedCursor;
		_unusedCursor = cursor;
	}

	/// <summary>
	/// 链表迭代器
	/// </summary>
	public class StaticLinkedListEnumerator : Common.IEnumerator<T>
	{
		public T Current => _enumerable._elements[_cursor].dataArea;

		private StaticLinkedList<T> _enumerable;
		private int _cursor = Global.InvalidIndex;

		public StaticLinkedListEnumerator(StaticLinkedList<T> enumerable)
		{
			_enumerable = enumerable;
		}

		public bool MoveNext()
		{
			if (_cursor == Global.InvalidIndex)
			{
				_cursor = _enumerable._startCursor;
			}
			else
			{
				_cursor = _enumerable._elements[_cursor].cursor;
			}

			if (_cursor == Global.InvalidIndex)
			{
				return false;
			}

			return true;
		}

		public void Reset() => _cursor = Global.InvalidIndex;
	}

	/// <summary>
	/// 链表节点
	/// </summary>
	private struct Node
	{
		/// <summary>
		/// 数据域
		/// </summary>
		public T dataArea;

		/// <summary>
		/// 游标域
		/// </summary>
		public int cursor;
	}
}
