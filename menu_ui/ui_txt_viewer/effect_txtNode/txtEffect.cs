using Obj.effect.txtSolver;
using Obj.ui;

namespace Obj.effect;

public class txtEffect
{

	public static readonly Dictionary<string, ItxtEffectSolver> effect_list = new();

	public void _Ready() {
		var type = typeExtend.searchClassAttribute(typeof(txtEffectSolverAttribute));
		logLine.info("ui", $"load txtsolver");
		foreach (var t in type)
		{
			var solver = Activator.CreateInstance(t) as ItxtEffectSolver;
			effect_list.Add(solver!.rule_type, solver);
			logLine.info("ui", $"find txtsolver {solver.rule_type}");
		}
	}

	public Action<txtNode> solve(res_txtEffect data) {
		return effect_list[data.type].compile_expression(data.rule);

	}

}


public sealed class txtEffectSolverAttribute : Attribute
{

}