using Obj.ui;

namespace Obj.effect;

public interface ItxtEffectSolver
{
	public Action<txtNode> compile_expression(string rule);
}  
