namespace DataStructure.Linear.Stack;

/// <summary>
/// 链栈
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkedStack<T> : Common.IEnumerable<T>
{
	/// <summary>
	/// 长度
	/// </summary>
	public int Count { get; private set; }

	/// <summary>
	/// 栈是否为空
	/// </summary>
	public bool IsEmpty => Count == 0;

	/// <summary>
	/// 栈顶指针
	/// </summary>
	private Node _top;

	public LinkedStack()
	{
		_top = default!;

		Count = 0;
	}

	/// <summary>
	/// 入栈
	/// </summary>
	/// <param name="element"></param>
	public void Push(T element)
	{
		var newNode = new Node
		{
			dataArea = element,
			next = _top
		};

		_top = newNode;

		Count++;
	}

	/// <summary>
	/// 出栈
	/// </summary>
	public void Pop()
	{
		if (IsEmpty)
		{
			throw new InvalidOperationException("Stack is empty");
		}

		var node = _top;

		_top = _top.next!;
		node.next = null;

		Count--;
	}

	public override string ToString()
	{
		if (IsEmpty)
		{
			return "Stack is empty";
		}

		var ptr = _top;
		var sb = new StringBuilder();
		sb.Clear();

		while (ptr is not null)
		{
			sb.Append(ptr!.dataArea);

			if (ptr.next is not null)
			{
				sb.Append(", ");
			}

			ptr = ptr.next;
		}

		return sb.ToString();
	}

	public Common.IEnumerator<T> GetEnumerator() => new LinkedStackEnumerator(this);

	/// <summary>
	/// 链栈迭代器
	/// </summary>
	public class LinkedStackEnumerator : Common.IEnumerator<T>
	{
		public T Current => _priorPointer.dataArea!;

		private LinkedStack<T> _enumerable;
		private Node _priorPointer;
		private Node _pointer;

		public LinkedStackEnumerator(LinkedStack<T> enumerable)
		{
			_enumerable = enumerable;
			_pointer = _enumerable._top;
			_priorPointer = default!;
		}

		public bool MoveNext()
		{
			_priorPointer = _pointer;

			if (_pointer is not null)
			{
				_pointer = _pointer.next!;
			}

			if (_priorPointer is null)
			{
				return false;
			}

			return true;
		}

		public void Reset() => _pointer = _enumerable._top;
	}

	/// <summary>
	/// 链栈节点
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
