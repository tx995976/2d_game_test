namespace Obj.tool.toolSet;

[toolSet]
public sealed class toolSet_map : ItoolSet
{
	public string ToolName => "map";

	public string exec_command(string[] args) {
		
		return "load ";
	}
}