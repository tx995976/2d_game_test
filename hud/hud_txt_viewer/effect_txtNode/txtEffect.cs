using Obj.hud;

namespace Obj.effect;

public class txtEffect
{
	public static readonly Dictionary<string, ItxtEffectSolver> effect_list = new()
	{
		{txtEffect_timer.rule_type,new txtEffect_timer()},
	};

	public Action<txtNode> solve(res_txtEffect data) {
		return effect_list[data.type].compile_expression(data.rule);
		
	}

}