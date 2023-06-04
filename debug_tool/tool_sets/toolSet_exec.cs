namespace Obj.tool.toolSet;

[toolSet]
public class toolSet_exec : ItoolSet
{
	public string ToolName => "exec";

	static readonly string script_path = "res://script/";
	static readonly TimeSpan time_delay = TimeSpan.FromSeconds(2.0);

	public terminal_result exec_command(string[]? args) {
		if (args is null)
			return terminal_result.usage("exec [script_path]");
		else if (args.Length == 1)
		{
			var s_name = args[0];
			var script = FileAccess.Open(script_path + s_name + resNames.scriptSuffix, FileAccess.ModeFlags.Read);
			if (script is null)
				return terminal_result.error("invaild script name");

			_ = execute(script);
		}

		return terminal_result.ok("running");
	}

	async ValueTask execute(FileAccess script) {
		foreach (var line in script.GetLineEnum())
		{
			ObjMain.cmdServe.exec_command(line);
			await Task.Delay(time_delay);
		}

	}
}
