namespace DataStructure.Common;

/// <summary>
/// 迭代器接口
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IEnumerator<out T>
{
	/// <summary>
	/// 当前被迭代元素
	/// </summary>
	public T Current { get; }

	/// <summary>
	/// 是否能向下一位移动
	/// </summary>
	/// <returns></returns>
	bool MoveNext();

	/// <summary>
	/// 重置
	/// </summary>
	void Reset();
}
