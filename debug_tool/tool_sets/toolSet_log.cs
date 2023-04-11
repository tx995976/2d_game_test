namespace Obj.tool.toolSet;


[toolSet]
public class toolSet_log : ItoolSet
{
	public string ToolName => "log";

	public terminal_result exec_command(string[]? args)
	{
		

        return terminal_result.ok("ok");
	}
}