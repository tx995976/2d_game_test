namespace Obj.tool.toolSet;

[toolSet]
public sealed class toolSet_map : ItoolSet
{
	public string ToolName => "map";

	public terminal_result exec_command(string[]? args) {
		if (args is null)
			return terminal_result.usage("map -name");

		_ = ObjMain.gameplayServe._map_loader.call_map_load(args[0]);
		return terminal_result.ok($"load {args[0]}");
	}
}