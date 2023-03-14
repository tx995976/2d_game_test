namespace Obj.util;

#region signal

public class SignalAct : IAwaitable
{
	private signalawaiter _awaiter = new();
	public event Action? act;
	public bool IsOnce { get; set; } = false;

	public IAwaiter GetAwaiter() => _awaiter;

	public void Invoke() {
		var waiter = _awaiter;
		_awaiter = new();
		waiter.Completed();

		act?.Invoke();
		if (IsOnce)
			act = null;
	}

	public static SignalAct operator +(SignalAct left, Action right) {
		left.act += right;
		return left;
	}

	public static SignalAct operator -(SignalAct left, Action right) {
		left.act -= right;
		return left;
	}

}

public class SignalAct<T> : IAwaitable
{
	private signalawaiter _awaiter = new();
	public event Action<T>? act;
	public bool IsOnce { get; set; } = false;

	public IAwaiter GetAwaiter() => _awaiter;

	public void Invoke(T t) {
		var waiter = _awaiter;
		_awaiter = new();
		waiter.Completed();

		act?.Invoke(t);
		if (IsOnce)
			act = null;
	}

	public static SignalAct<T> operator +(SignalAct<T> left, Action<T> right) {
		left.act += right;
		return left;
	}

	public static SignalAct<T> operator -(SignalAct<T> left, Action<T> right) {
		left.act -= right;
		return left;
	}
}

public class SignalAct<T, T1> : IAwaitable
{
	private signalawaiter _awaiter = new();
	public event Action<T, T1>? act;
	public bool IsOnce { get; set; } = false;

	public IAwaiter GetAwaiter() => _awaiter;

	public void Invoke(T t, T1 t1) {
		var waiter = _awaiter;
		_awaiter = new();
		waiter.Completed();

		act?.Invoke(t, t1);
		if (IsOnce)
			act = null;
	}

	public static SignalAct<T, T1> operator +(SignalAct<T, T1> left, Action<T, T1> right) {
		left.act += right;
		return left;
	}

	public static SignalAct<T, T1> operator -(SignalAct<T, T1> left, Action<T, T1> right) {
		left.act -= right;
		return left;
	}
}

public class SignalAct<T, T1, T2> : IAwaitable
{
	private signalawaiter _awaiter = new();
	public event Action<T, T1, T2>? act;
	public bool IsOnce { get; set; } = false;

	public IAwaiter GetAwaiter() => _awaiter;

	public void Invoke(T t, T1 t1, T2 t2) {
		var waiter = _awaiter;
		_awaiter = new();
		waiter.Completed();

		act?.Invoke(t, t1, t2);
		if (IsOnce)
			act = null;
	}

	public static SignalAct<T, T1, T2> operator +(SignalAct<T, T1, T2> left, Action<T, T1, T2> right) {
		left.act += right;
		return left;
	}

	public static SignalAct<T, T1, T2> operator -(SignalAct<T, T1, T2> left, Action<T, T1, T2> right) {
		left.act -= right;
		return left;
	}

}

public class SignalAct<T, T1, T2, T3> : IAwaitable
{
	private signalawaiter _awaiter = new();
	public event Action<T, T1, T2, T3>? act;
	public bool IsOnce { get; set; } = false;

	public IAwaiter GetAwaiter() => _awaiter;

	public void Invoke(T t, T1 t1, T2 t2, T3 t3) {
		var waiter = _awaiter;
		_awaiter = new();
		waiter.Completed();

		act?.Invoke(t, t1, t2, t3);
		if (IsOnce)
			act = null;
	}

	public static SignalAct<T, T1, T2, T3> operator +(SignalAct<T, T1, T2, T3> left, Action<T, T1, T2, T3> right) {
		left.act += right;
		return left;
	}

	public static SignalAct<T, T1, T2, T3> operator -(SignalAct<T, T1, T2, T3> left, Action<T, T1, T2, T3> right) {
		left.act -= right;
		return left;
	}
}

#endregion

public class signalawaiter : IAwaiter
{
	public bool IsCompleted { get; private set; } = false;
	private Action? _continuation;

	public void GetResult() { }

	public void OnCompleted(Action continuation) {
		if (IsCompleted)
			continuation.Invoke();
		else
		{
			_continuation += continuation;
		}
	}

	public void Completed() {
		IsCompleted = true;
		_continuation?.Invoke();
	}
}

