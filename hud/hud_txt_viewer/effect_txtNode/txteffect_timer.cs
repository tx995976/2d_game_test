using Obj.hud;

namespace Obj.effect;



public class txtEffect_timer : ItxtEffectSolver
{
	public static readonly string rule_type = "timer";

	/// <summary>
	///	type_time:(timespan) | format_str | direction_time(1,-1) | ticks_time
	/// </summary>
	public Action<txtNode> compile_expression(string rule) {
		var args = rule.Split('|');

		var time = TimeSpan.Parse(args[0]);
 
		var format_str = args[1];
		var dir = int.Parse(args[2]);
		var tick_time = TimeSpan.FromSeconds(double.Parse(args[3]));
		
		return async (node) => {
			PeriodicTimer tick = new(tick_time);
			while(true){
				await tick.WaitForNextTickAsync();
				node.Text = string.Format(node.Text,time.ToString(format_str));
				time -= tick_time;
				if(!node.isActive || time == TimeSpan.Zero)
					break;
			}
			tick.Dispose();
		};
	}
}