namespace Obj.util;

public class cacheQueue<T> where T : class
{
	Queue<T> queue = new();
	int limit = 0;

	public cacheQueue(int _limit) {
		limit = _limit;
	}

    public void add(T item) {
        queue.Enqueue(item);
        if (queue.Count > limit) {
            queue.Dequeue();
        }
    }

    public T? get() {
        return queue.Count > 0 ? queue.Dequeue() : null;
    }

}
