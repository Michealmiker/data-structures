namespace DataStructure.Common;

/// <summary>
/// 可迭代集合接口
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IEnumerable<T>
{
	/// <summary>
	/// 获取迭代器
	/// </summary>
	/// <returns></returns>
	public IEnumerator<T> GetEnumerator();
}