namespace Obj.tool.toolSet;

[toolSet]
public class toolSet_item : ItoolSet
{
	public string ToolName => "item";

	public terminal_result exec_command(string[]? args) {


		return new(status_cmd.ok , "ok");
	}
}