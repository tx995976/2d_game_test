namespace Obj.tool;

public class tool_log
{
	public static readonly int _Buffer_Limit = 500;

	public static tool_log _instance = new();

	public Queue<string> _log_buffer = new(_Buffer_Limit);

	public Func<logLine, bool>? fliter = (data) =>
	{
		return (int)data.level >= (int)logLevel.debug ? true : false;
	};

	public void log(logLine data) {
		var flag = fliter?.Invoke(data) ?? true;

		var tag = data.tag;
		var level = data.level;
		
		var (color_line, line) = data.render();

		insert_buffer(line);

		if (flag)
			GD.PrintRich(color_line);
	}

	public string dump(string path) {
		var time = DateTime.Now.ToString("yyyy-MM-dd.HH-mm-ss");
		var filepath = $"{path}/{time}.txt";
		logLine.debug("tool_log", $"file name : {filepath}");

		using var file = FileAccess.Open(filepath, FileAccess.ModeFlags.Write);
		foreach (var line in _log_buffer)
		{
			file.StoreLine(line);
		}
		return filepath;
	}

	public void insert_buffer(string message) {
		if (_log_buffer.Count >= _Buffer_Limit)
			_ = _log_buffer.Dequeue();

		_log_buffer.Enqueue(message);
	}
}


public enum logLevel : int
{
	debug,
	info,
	warning
}


public record class logLine : IpoolManage<logLine>
{
	public logLevel level;
	public string tag = string.Empty;
	public string message = string.Empty;

	public DateTime time = DateTime.MinValue;

	public static Action<logLine>? pushAction;

	public static objectPool<logLine> pool = new();

	public static logLine get() => pool.get();

	public void enPool() => pool.push(this);

	#region short constructor

	public static void debug(string _tag, string _message) {
		var data = get();

		data.tag = _tag;
		data.message = _message;
		data.level = logLevel.debug;
		data.time = DateTime.Now;

		pushAction?.Invoke(data);
	}

	public static void info(string _tag, string _message) {
		var data = get();

		data.tag = _tag;
		data.message = _message;
		data.level = logLevel.info;
		data.time = DateTime.Now;

		pushAction?.Invoke(data);
	}

	public static void warning(string _tag, string _message) {
		var data = get();

		data.tag = _tag;
		data.message = _message;
		data.level = logLevel.warning;
		data.time = DateTime.Now;

		pushAction?.Invoke(data);
	}

	#endregion

	public (string color_str, string str) render() {
		var color = this.level switch
		{
			logLevel.debug => "yellow",
			logLevel.info => "green",
			logLevel.warning => "red",
			_ => ""
		};

		var color_str = $"[{this.time.ToString("HH:mm:ss")}] [color={color}][{this.tag}][/color] {this.message}";
		var str = $"[{this.time.ToString("HH:mm:ss")}] [{level.ToString()}] [{this.tag}] {this.message}";

		enPool();

		return (color_str, str);
	}

}