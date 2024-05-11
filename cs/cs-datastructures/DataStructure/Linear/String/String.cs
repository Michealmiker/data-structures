namespace DataStructure.Linear.String;

/// <summary>
/// 串
/// </summary>
public class String : Common.IEnumerable<char>, IComparable<String>
{
	public char this[int index]
	{
		get
		{
			if (index >= Count)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}

			return _chars[index];
		}
	}

	/// <summary>
	/// 串的最大长度
	/// </summary>
	public const int MaxCount = 255;

	/// <summary>
	/// 长度
	/// </summary>
	public int Count { get; private set; }

	/// <summary>
	/// 字符集合
	/// </summary>
	private readonly char[] _chars;

	public String(char[] chars)
	{
		if (chars == null)
		{
			throw new ArgumentNullException(nameof(chars));
		}

		Count = chars.Length < MaxCount ? chars.Length : MaxCount;

		_chars = new char[Count];

		Refresh(chars);
	}

	/// <summary>
	/// 连接串
	/// </summary>
	/// <param name="ch"></param>
	/// <returns></returns>
	public String Concat(char[] ch)
	{
		var length = ch.Length;
		char[] result;

		if (Count == MaxCount)
		{
			result = new char[MaxCount];

			for (var i = 0; i < Count; i++)
			{
				result[i] = _chars[i];
			}
		} // 串超长，ch连接失败
		else if (Count + length <= MaxCount)
		{
			result = new char[Count + length];

			var i = 0;
			for (; i < Count; i++)
			{
				result[i] = _chars[i];
			}

			for (var j = 0; j < length; i++, j++)
			{
				result[i] = ch[j];
			}
		} // 连接完整的两串
		else
		{
			result = new char[MaxCount];

			var i = 0;
			for (; i < Count; i++)
			{
				result[i] = _chars[i];
			}

			for (var j = 0; i < MaxCount; i++, j++)
			{
				result[i] = ch[j];
			}
		} // 截断超长的ch部分

		return new(result);
	}

	/// <summary>
	/// [基于1]
	/// 获取子串
	/// </summary>
	/// <param name="startIndex"></param>
	/// <param name="length"></param>
	/// <returns></returns>
	public String SubString(int startIndex, int length)
	{
		if (startIndex < 0
			|| Count < startIndex
			|| length <= 0
			|| startIndex + length - 1 > Count)
		{
			throw new ArgumentOutOfRangeException();
		}

		var result = new char[length];

		for (int i = 0, j = startIndex - 1; i < length; i++, j++)
		{
			result[i] = _chars[j];
		}

		return new String(result);
	}

	/// <summary>
	/// 获取子串所在位置
	/// </summary>
	/// <param name="subStr"></param>
	/// <returns></returns>
	public int IndexOf(String subStr)
	{
		if (subStr.Count == 0)
		{
			return Global.InvalidIndex;
		}

		var length = subStr.Count;
		var i = 0;
		var j = 0;

		while (i < Count && j < length)
		{
			if (_chars[i] == subStr[j])
			{
				i++;
				j++;
			}
			else
			{
				i = i - j + 2;
				j = 0;
			}
		}

		if (j == length)
		{
			return i - length;
		}

		return Global.InvalidIndex;
	}

	/// <summary>
	/// 获取子串所在位置（KMP算法）
	/// </summary>
	/// <param name="subStr"></param>
	/// <returns></returns>
	public int IndexOf_KMP(String subStr)
	{
		var nextArray = PrefixFunction(subStr);
		var i = 0;
		var j = Global.InvalidIndex;
		var length = subStr.Count;

		while (i < Count && j < length)
		{
			if (j == Global.InvalidIndex || _chars[i] == subStr[j])
			{
				i++;
				j++;

				continue;
			}

			j = nextArray[j];
		}

		if (j == length)
		{
			return i - j;
		}

		return Global.InvalidIndex;
	}

	/// <summary>
	/// 比较串
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public int CompareTo(String? other)
	{
		if (other is null || other.Count <= 0)
		{
			return Count > 0 ? 1 : 0;
		}

		for (var i = 0; i < Count && i < other.Count; i++)
		{
			if (_chars[i] != other[i])
			{
				return _chars[i] > other[i] ? 1 : (_chars[i] == other[i] ? 0 : -1);
			}
		}

		return Count > other.Count ? 1 : (Count == other.Count ? 0 : -1);
	}

	public override string ToString() => new string(_chars);

	/// <summary>
	/// 刷新
	/// </summary>
	/// <param name="chars"></param>
	private void Refresh(char[] chars)
	{
		for (var i = 0; i < Count; i++)
		{
			_chars[i] = chars[i];
		}
	}

	/// <summary>
	/// 前缀函数
	/// </summary>
	/// <param name="str"></param>
	/// <returns></returns>
	private int[] PrefixFunction(String str)
	{
		var length = str.Count;
		var i = Global.InvalidIndex;
		var j = 0;
		var nextArray = new int[length];

		nextArray[0] = -1;

		while (j < length - 1)
		{
			if (i == Global.InvalidIndex
				|| str[i] == str[j])
			{
				i++;
				j++;
				nextArray[j] = i;
			}
			else
			{
				i = nextArray[i];
			}
		}

		return nextArray;
	}

	public Common.IEnumerator<char> GetEnumerator() => new StringEnumerator(this);

	/// <summary>
	/// 串迭代器
	/// </summary>
	public class StringEnumerator : Common.IEnumerator<char>
	{
		public char Current => throw new NotImplementedException();

		private String _str;
		private int _index;

		public StringEnumerator(String str) => (_str, _index) = (str, -1);

		public bool MoveNext()
		{
			_index++;

			if (_index == _str.Count)
			{
				return false;
			}

			return true;
		}

		public void Reset() => _index = -1;
	}
}

public static class StringExtensions
{
	/// <summary>
	/// 连接指定的两个串
	/// </summary>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns></returns>
	public static String Concat(this String a, String b)
	{
		var length1 = a.Count;
		var length2 = b.Count;
		char[] result;

		if (length1 == String.MaxCount)
		{
			result = new char[String.MaxCount];

			for (var i = 0; i < length1; i++)
			{
				result[i] = a[i];
			}
		} // 串超长，ch连接失败
		else if (length1 + length2 <= String.MaxCount)
		{
			result = new char[length1 + length2];

			var i = 0;
			for (; i < length1; i++)
			{
				result[i] = a[i];
			}

			for (var j = 0; j < length2; i++, j++)
			{
				result[i] = b[j];
			}
		} // 连接完整的两串
		else
		{
			result = new char[String.MaxCount];

			var i = 0;
			for (; i < length2; i++)
			{
				result[i] = a[i];
			}

			for (var j = 0; i < String.MaxCount; i++, j++)
			{
				result[i] = b[j];
			}
		} // 截断超长的ch部分

		return new(result);
	}

	/// <summary>
	/// 比较指定的两个串
	/// </summary>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns></returns>
	public static int Compare(this String a, String b)
	{
		if (a is null && b is null)
		{
			return 0;
		}

		if (a is null || a.Count <= 0)
		{
			return b!.Count > 0 ? -1 : 0;
		}

		if (b is null || b.Count <= 0)
		{
			return a!.Count > 0 ? 1 : 0;
		}

		for (var i = 0; i < a.Count && i < b.Count; i++)
		{
			if (a[i] != b[i])
			{
				return a[i] > b[i] ? 1 : (a[i] == b[i] ? 0 : -1);
			}
		}

		return a.Count > b.Count ? 1 : (a.Count == b.Count ? 0 : -1);
	}
}
