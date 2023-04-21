namespace Obj.util;

public sealed class tscnPool<T> : objectPool<T> where T : Node, new()
{

	PackedScene tscn;

	public tscnPool(PackedScene _tscn, Action<T, Action<T>>? action = null, int size = default_size)
	: base(action, 0) {
		tscn = _tscn;
		init(size);
	}

	protected override T init_instance() {
		var instance = tscn.Instantiate<T>();
		initAction?.Invoke(instance, push);
		return instance;
	}

	protected override T shortageAction() {
		return init_instance();
	}

}