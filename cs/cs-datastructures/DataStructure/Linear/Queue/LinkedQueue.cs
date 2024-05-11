namespace DataStructure.Linear.Queue;

/// <summary>
/// 链队
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkedQueue<T> : Common.IEnumerable<T>
{
	/// <summary>
	/// 长度
	/// </summary>
	public int Count { get; private set; }

	/// <summary>
	/// 队列是否为空
	/// </summary>
	public bool IsEmpty => Count == 0;

	/// <summary>
	/// 队首指针
	/// </summary>
	private Node _front;

	/// <summary>
	/// 队尾指针
	/// </summary>
	private Node _rear;

	public LinkedQueue()
	{
		_rear = new()
		{
			dataArea = default!,
			next = default!
		}!;

		_front = _rear;

		Count = 0;
	}

	/// <summary>
	/// 入栈
	/// </summary>
	/// <param name="element"></param>
	public void EnQueue(T element)
	{
		var newNode = new Node
		{
			dataArea = element
		};

		if (Count == 0)
		{
			_front = newNode;
		}

		if (_rear.next is not null)
		{
			_rear.next.next = newNode;
		}

		newNode.next = _rear;
		_rear.next = newNode;

		Count++;
	}

	/// <summary>
	/// 出栈
	/// </summary>
	/// <returns></returns>
	public T DeQueue()
	{
		if (IsEmpty)
		{
			throw new InvalidOperationException("Queue is empty");
		}

		var node = _front;
		var elem = node.dataArea;

		_front = _front.next!;
		node.next = null;

		return elem!;
	}

	public override string ToString()
	{
		if (IsEmpty)
		{
			return "Queue is empty";
		}

		var sb = new StringBuilder();
		sb.Clear();

		var ptr = _front;

		while (ptr != _rear)
		{
			sb.Append(ptr!.dataArea);

			if (ptr.next != _rear)
			{
				sb.Append(", ");
			}

			ptr = ptr.next;
		}

		return sb.ToString();
	}

	public Common.IEnumerator<T> GetEnumerator() => new LinkedQueueEnumerator(this);

	/// <summary>
	/// 链队迭代器
	/// </summary>
	public class LinkedQueueEnumerator : Common.IEnumerator<T>
	{
		public T Current => _priorPointer.dataArea!;

		private LinkedQueue<T> _enumerable;

		private Node _priorPointer;
		private Node _pointer;

		public LinkedQueueEnumerator(LinkedQueue<T> enumerable)
		{
			_enumerable = enumerable;
			_pointer = _enumerable._front;
			_priorPointer = default!;
		}

		public bool MoveNext()
		{
			_priorPointer = _pointer;

			if (_pointer != _enumerable._rear)
			{
				_pointer = _pointer.next!;
			}

			if (_priorPointer == _enumerable._rear)
			{
				return false;
			}

			return true;
		}

		public void Reset() => _pointer = _enumerable._front;
	}

	/// <summary>
	/// 链队节点
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