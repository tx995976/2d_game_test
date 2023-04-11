namespace Obj.tool;

public class tool_log
{
	public static readonly int _Buffer_Limit = 50;

	public static tool_log _instance = new();

	public Dictionary<string, Queue<string>> _tag_buffer = new();
	public Dictionary<string, Queue<string>> _level_buffer = new();

	public Func<logLine, bool>? fliter = (data) =>
	{
		return (int)data.level >= (int)logLevel.info ? true : false;
	};

	public void log(logLine data) {
		var flag = fliter?.Invoke(data) ?? true;

		var tag = data.tag;
		var level = data.level.ToString();
		var line = data.ToString();

		insert_buffer(tag, level, line);

		if (flag)
			GD.PrintRich(line);
	}

	public void insert_buffer(string tag, string level, string message) {
		if(!_tag_buffer.ContainsKey(tag))
			_tag_buffer.Add(tag, new(_Buffer_Limit));
		if(!_level_buffer.ContainsKey(level))
			_level_buffer.Add(level, new(_Buffer_Limit));

		_tag_buffer[tag].Enqueue(message);
		_level_buffer[level].Enqueue(message);

		if(_tag_buffer.Count > _Buffer_Limit)
			_tag_buffer[tag].Dequeue();
		if(_level_buffer.Count > _Buffer_Limit)
			_level_buffer[level].Dequeue();
	}
}

public enum logLevel : int
{
	debug,
	info,
	warning
}


public record class logLine
{
	public logLevel level;
	public string tag = string.Empty;
	public string message = string.Empty;

	public DateTime time = DateTime.MinValue;

	public static Action<logLine>? pushAction;

	public static objectPool<logLine> pool = new();

	public static void debug(string _tag, string _message) {
		var data = pool.get();

		data.tag = _tag;
		data.message = _message;
		data.level = logLevel.debug;
		data.time = DateTime.Now;

		pushAction?.Invoke(data);
	}

	public static void info(string _tag, string _message) {
		var data = pool.get();

		data.tag = _tag;
		data.message = _message;
		data.level = logLevel.info;
		data.time = DateTime.Now;

		pushAction?.Invoke(data);
	}

	public static void warning(string _tag, string _message) {
		var data = pool.get();

		data.tag = _tag;
		data.message = _message;
		data.level = logLevel.warning;
		data.time = DateTime.Now;

		pushAction?.Invoke(data);
	}


	public override string ToString() {
		var color = this.level switch
		{
			logLevel.debug => "yellow",
			logLevel.info => "green",
			logLevel.warning => "red",
			_ => ""
		};
		var str = $"[color={color}][{this.tag}] {this.time.ToString("H:mm")}[/color] {this.message}";

		pool.push(this);

		return str;
	}

}