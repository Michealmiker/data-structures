namespace DataStructure.Linear.Stack;

/// <summary>
/// 顺序栈
/// </summary>
/// <typeparam name="T"></typeparam>
public class SequentialStack<T>
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
	/// 栈是否为空
	/// </summary>
	public bool IsEmpty => Count == 0;

	/// <summary>
	/// 栈顶游标
	/// </summary>
	private int _top;

	/// <summary>
	/// 元素集合
	/// </summary>
	private T[] _elements;

	public SequentialStack(int capacity)
	{
		_elements = new T[capacity];

		Capacity = capacity;
		Count = 0;
		_top = 0;
	}

	public SequentialStack() : this(2)
	{
	}

	/// <summary>
	/// 入栈
	/// </summary>
	/// <param name="element"></param>
	public void Push(T element)
	{
		CheckCapacity();

		_elements[_top++] = element;

		Count++;
	}

	/// <summary>
	/// 出栈
	/// </summary>
	/// <returns></returns>
	public T Pop()
	{
		if (IsEmpty)
		{
			throw new InvalidOperationException("Stack is empty");
		}

		var elem = _elements[--_top];

		Count--;

		return elem;
	}

	public override string ToString()
	{
		if (IsEmpty)
		{
			return "Stack is empty";
		}

		var sb = new StringBuilder();
		sb.Clear();

		for (var i = _top - 1; i >= 0; i--)
		{
			sb.Append(_elements[i]);

			if (i != 0)
			{
				sb.Append(", ");
			}
		}

		return sb.ToString();
	}

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

	public Common.IEnumerator<T> GetEnumerator() => new SequentialStackEnumerator(this);

	/// <summary>
	/// 顺序栈迭代器
	/// </summary>
	public class SequentialStackEnumerator : Common.IEnumerator<T>
	{
		public T Current => _enumerable._elements[_index];

		private SequentialStack<T> _enumerable;

		private int _index;

		public SequentialStackEnumerator(SequentialStack<T> enumerable)
		{
			_enumerable = enumerable;
			_index = _enumerable._top;
		}

		public bool MoveNext()
		{
			_index--;

			if (_index == Global.InvalidIndex)
			{
				return false;
			}

			return true;
		}

		public void Reset() => _index = _enumerable._top;
	}
}
