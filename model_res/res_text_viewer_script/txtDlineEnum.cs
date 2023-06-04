namespace Obj.resource;

public class txtDlineEnum : IpoolManage<txtDlineEnum>
{
	static objectPool<txtDlineEnum> pool = new();

	string Current { get; set; } = string.Empty;
	IEnumerator<string>? _Enumerator;

	public txtDlineEnum() { }

	public static txtDlineEnum get() => throw new NotImplementedException();

	public static txtDlineEnum get(IEnumerator<string> data) {
		var Dline = pool.get();
		Dline._Enumerator = data;
		return Dline;
	}

	public void enPool() {
		_Enumerator = null;
		pool.push(this);
	}

	public string next() {
		if (_Enumerator!.MoveNext())
		{
			Current = _Enumerator.Current;
			return Current;
		}
		return Current;
	}
}