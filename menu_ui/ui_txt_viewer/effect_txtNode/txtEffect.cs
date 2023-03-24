using Obj.effect.txtSolver;
using Obj.ui;

namespace Obj.effect;

public class txtEffect
{
	/// ADDON Assembly load
	public static readonly Dictionary<string, ItxtEffectSolver> effect_list = new()
	{
		{txtEffect_timer.rule_type,new txtEffect_timer()},
	};

	public Action<txtNode> solve(res_txtEffect data) {
		return effect_list[data.type].compile_expression(data.rule);
		
	}

}