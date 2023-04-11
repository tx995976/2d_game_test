namespace Obj.util;

public sealed class tscnPool<T> : objectPool<T> where T : Node, new()
{
	const int default_size = 20;

	PackedScene tscn;

	public tscnPool(PackedScene _tscn, int size = default_size)
	: base(size) {
		tscn = _tscn;
		init();
	}

	public tscnPool(PackedScene _tscn, Action<T> action, int size = default_size)
	: base(action, size) {
		tscn = _tscn;
		initAction = action;
		init();
	}

	public override T init_instance() {
		var instance = tscn.Instantiate<T>();
		initAction?.Invoke(instance);
		return instance;
	}

	public override T shortageAction() {
		return init_instance();
	}


}