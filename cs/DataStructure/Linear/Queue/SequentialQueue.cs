namespace DataStructure.Linear.Queue;

/// <summary>
/// 顺序队列
/// </summary>
/// <typeparam name="T"></typeparam>
public class SequentialQueue<T> : Common.IEnumerable<T>
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
	/// 队列是否为空
	/// </summary>
	public bool IsEmpty => Count == 0;

	/// <summary>
	/// 队头游标
	/// </summary>
	private int _front;

	/// <summary>
	/// 队尾游标
	/// </summary>
	private int _rear;

	private T[] _elements;

	public SequentialQueue(int capacity)
	{
		_elements = new T[capacity];

		Capacity = capacity;
		Count = 0;

		_front = 0;
		_rear = 0;
	}

	public SequentialQueue() : this(2)
	{
	}

	/// <summary>
	/// 入栈
	/// </summary>
	/// <param name="element"></param>
	public void EnQueue(T element)
	{
		CheckCapacity();

		_elements[_rear++] = element;

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

		var elem = _elements[_front];

		for (int i = 0; i <= Count; i++)
		{
			_elements[i] = _elements[i + 1];
		}

		_rear--;
		Count--;

		return elem;
	}

	public override string ToString()
	{
		if (IsEmpty)
		{
			return "Queue is empty";
		}

		var sb = new StringBuilder();
		sb.Clear();

		var cur = _front;

		while (cur != _rear)
		{
			sb.Append(_elements[cur]);

			if (cur + 1 != _rear)
			{
				sb.Append(", ");
			}

			cur++;
		}

		return sb.ToString();
	}

	public Common.IEnumerator<T> GetEnumerator() => new SequentialQueueEnumerator(this);

	/// <summary>
	/// 检查容量
	/// </summary>
	private void CheckCapacity()
	{
		if (Count < Capacity)
		{
			return;
		}

		var newCapacity = Capacity * Global.IncrementMultiple;

		try
		{
			Array.Resize(ref _elements, newCapacity);
			Capacity = newCapacity;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.StackTrace);
		}
	}

	/// <summary>
	/// 顺序队列迭代器
	/// </summary>
	public class SequentialQueueEnumerator : Common.IEnumerator<T>
	{
		public T Current => _enumerable._elements[_priorIndex];

		private SequentialQueue<T> _enumerable;

		private int _priorIndex;
		private int _index;

		public SequentialQueueEnumerator(SequentialQueue<T> enumerable)
		{
			_enumerable = enumerable;
			_index = _enumerable._front;
			_priorIndex = Global.InvalidIndex;
		}

		public bool MoveNext()
		{
			_priorIndex = _index;

			if (_index != _enumerable._rear)
			{
				_index++;
			}

			if (_priorIndex == _enumerable._rear)
			{
				return false;
			}

			return true;
		}

		public void Reset() => _index = _enumerable._front;
	}
}
