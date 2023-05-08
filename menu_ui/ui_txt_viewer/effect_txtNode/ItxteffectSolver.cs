using Obj.ui;

namespace Obj.effect;

public interface ItxtEffectSolver
{
	public Action<txtNode> compile_expression(string rule);
	public string rule_type { get; }
}
