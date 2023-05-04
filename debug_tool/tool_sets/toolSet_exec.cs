namespace Obj.tool.toolSet;

[toolSet]
public class toolSet_exec : ItoolSet
{
	public string ToolName => "exec";

	public terminal_result exec_command(string[]? args)
	{
		if (args is null)
            return terminal_result.usage("exec [script_path]");
        
        return terminal_result.ok("ok");
	}
}
