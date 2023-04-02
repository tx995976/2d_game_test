namespace Obj.tool.toolSet;

[toolSet]
public sealed class toolSet_map : ItoolSet
{
	public string ToolName => "map";

	public terminal_result exec_command(string[]? args) {
		
		return new(status_cmd.ok,"load ");
	}
}