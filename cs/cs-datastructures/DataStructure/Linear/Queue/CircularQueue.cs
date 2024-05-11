namespace DataStructure.Linear.Queue;

/// <summary>
/// 循环队列
/// </summary>
/// <typeparam name="T"></typeparam>
public class CircularQueue<T> : Common.IEnumerable<T>
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

	public CircularQueue(int capacity)
	{
		_elements = new T[capacity];

		Capacity = capacity;
		Count = 0;

		_front = 0;
		_rear = 0;
	}

	/// <summary>
	/// 入栈
	/// </summary>
	/// <param name="element"></param>
	public void EnQueue(T element)
	{
		if (Count == Capacity)
		{
			throw new InvalidOperationException("Queue is full");
		}

		_elements[_rear] = element;
		_rear = (_rear + 1) % Capacity;

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
		_front = (_front + 1) % Capacity;

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
		var isStart = true;

		while (cur != _rear || isStart)
		{
			if (isStart)
			{
				isStart = false;
			}

			var nextCur = (cur + 1) % Capacity;

			sb.Append(_elements[cur]);

			if (nextCur != _rear)
			{
				sb.Append(", ");
			}

			cur = nextCur;
		}

		return sb.ToString();
	}

	public Common.IEnumerator<T> GetEnumerator() => new CircularQueueEnumerator(this);

	/// <summary>
	/// 顺序队列迭代器
	/// </summary>
	public class CircularQueueEnumerator : Common.IEnumerator<T>
	{
		public T Current => _enumerable._elements[_priorIndex];

		private CircularQueue<T> _enumerable;

		private int _priorIndex;
		private int _index;
		private bool _isStart;

		public CircularQueueEnumerator(CircularQueue<T> enumerable)
		{
			_enumerable = enumerable;
			_index = _enumerable._front;
			_isStart = true;
			_priorIndex = Global.InvalidIndex;
		}

		public bool MoveNext()
		{
			_priorIndex = _index;

			if (_index != _enumerable._rear || _isStart)
			{
				_index = (_index + 1) % _enumerable.Capacity;
			}

			if (_priorIndex == _enumerable._rear && !_isStart)
			{
				return false;
			}

			if (_isStart)
			{
				_isStart = false;
			}

			return true;
		}

		public void Reset() => (_index, _isStart) = (_enumerable._front, true);
	}
}