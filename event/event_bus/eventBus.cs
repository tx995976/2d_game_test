namespace Obj.Event;

public static class eventBus<T> where T : Ievent
{
    static Action<T>? _handler;

    public static void Subscribe(Action<T> handler)
    {
        _handler += handler;
    }

    public static void Unsubscribe(Action<T> handler)
    {
        _handler -= handler;
    }

}