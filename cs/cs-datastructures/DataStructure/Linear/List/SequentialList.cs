namespace DataStructure.Linear.List;

/// <summary>
/// 顺序表
/// </summary>
/// <typeparam name="T"></typeparam>
public class SequentialList<T> : Common.IEnumerable<T>
{
    public T this[int index]
	{
		get
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}

			return this[index];
		}
		set
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException(nameof(index));
			}

			this[index] = value;
		}
	}

    /// <summary>
	/// 长度
	/// </summary>
	public int Count { get; private set; }

	/// <summary>
	/// 表是否为空
	/// </summary>
	public bool IsEmpty => Count == 0;

	/// <summary>
	/// 容量
	/// </summary>
	public int Capacity { get; private set; }

	/// <summary>
	/// 元素集合
	/// </summary>
	private T[]? _elements;

    public SequentialList(int capacity)
	{
		_elements = new T[capacity];

		Capacity = capacity;
		Count = 0;
	}

	public SequentialList() : this(2)
	{

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

		CheckCapacity();

		var realIndex = index - 1;
		for (var i = Count - 1; i > realIndex; i--)
		{
			_elements![i] = _elements[i - 1];
		}

		_elements![realIndex] = element;

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

		for (var i = index; i < Count; i++)
		{
			_elements![i - 1] = _elements[i];
		}

		Count--;
	}

    public override string ToString()
	{
		if (IsEmpty)
		{
			return "List is empty";
		}

		return string.Join(", ", _elements![..Count]);
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

    public Common.IEnumerator<T> GetEnumerator() => new SequentialListEnumerator(this);

	/// <summary>
	/// 顺序表迭代器
	/// </summary>
	public class SequentialListEnumerator : Common.IEnumerator<T>
	{
		public T Current => _enumerable._elements![_index];

		private SequentialList<T> _enumerable;

		private int _index = Global.InvalidIndex;

		public SequentialListEnumerator(SequentialList<T> enumerable) => _enumerable = enumerable;

		public bool MoveNext()
		{
			_index++;

			if (_index == _enumerable.Count)
			{
				return false;
			}

			return true;
		}

		public void Reset() => _index = Global.InvalidIndex;
	}
}