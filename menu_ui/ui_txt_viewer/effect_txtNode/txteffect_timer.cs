
using Obj.ui;

namespace Obj.effect.txtSolver;

[Obsolete]
[txtEffectSolver]
public class txtEffect_timer : ItxtEffectSolver
{
	public string rule_type => "timer";

	/// <summary>
	///	type_time:(timespan) | format_str | direction_time(1,-1) | ticks_time
	/// </summary>
	public Action<txtNode> compile_expression(string rule) {
		var args = rule.Split('|');

		var format_str = args[1];
		var time = TimeSpan.ParseExact(args[0], format_str, null);
		var tick_time = TimeSpan.FromSeconds(double.Parse(args[3]));

		var dir = int.Parse(args[2]);

		return async (node) =>
		{
			var txt = node!.txt!.text_bbcode;
			while (true)
			{
				await Task.Delay(tick_time);
				node.Text = string.Format(txt, time.ToString(format_str));
				time += tick_time * dir;
				// if (!node.isActive || time == TimeSpan.Zero)
				// {
				// 	break;
				// }
			}
		};
	}
}
