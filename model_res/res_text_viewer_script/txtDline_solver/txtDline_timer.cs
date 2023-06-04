namespace Obj.resource;

[txtDline]
public class txtDline_timer : ItxtDline
{
	/// <summary>
	///	regex:  format_str | time | direction_time(1,-1)
	/// </summary>
	public string type => "timer";

	public res_txtLine? line_data;

	string _format_str = string.Empty;
	TimeSpan _time = TimeSpan.Zero;
	int _time_direction;
	double _tick__time = 0.5;

	public ItxtDline Paser(string[] args) {
		var line = new txtDline_timer();

		line._format_str = args[1];
		line._time = TimeSpan.ParseExact(args[0], line._format_str, null);
		line._time_direction = int.Parse(args[2]);
		line._tick__time = double.Parse(args[3]);

		return line;
	}

	public txtDlineEnum init_enum(res_txtLine line) {
		return txtDlineEnum.get(tick_flush(line.text_bbcode));
	}

	public IEnumerator<string> tick_flush(string bbcode) {
		var _bbcode = bbcode;
		var time_temp = _time;
		while (true)
		{
			yield return string.Format(_bbcode, time_temp.ToString(_format_str));
			if (time_temp == TimeSpan.Zero)
			{
				yield break;
			}
			time_temp += TimeSpan.FromSeconds(ObjMain.PhysicsTime) * _time_direction;
		}
	}


}