namespace Obj.resource;

[txtDline]
public class txtDline_timer : ItxtDline
{
	/// <summary>
	///	regex: bbcode | format_str | time | direction_time(1,-1)
	/// </summary>
	public string type => "timer";

	string _bbcode = string.Empty;
	string _format_str = string.Empty;
	TimeSpan _time = TimeSpan.Zero;
	int _time_direction;

	public ItxtDline Paser(string[] args) {
		var line = new txtDline_timer();

		line._bbcode = args[0];
		line._format_str = args[1];
		line._time = TimeSpan.ParseExact(args[2], _format_str, null);
		line._time_direction = int.Parse(args[3]);

		return line;
	}

	public void reset() {
		throw new NotImplementedException();
	}

	public IEnumerator<string> tick_flush(double delta) {
		var time_temp = _time;
		while (true)
		{
			yield return string.Format(_bbcode, time_temp.ToString(_format_str));
			time_temp += TimeSpan.FromSeconds(delta) * _time_direction;
			if (time_temp == TimeSpan.Zero)
			{
				yield break;
			}
		}
	}
}