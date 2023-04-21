namespace Obj.tool.toolSet;


[toolSet]
public class toolSet_log : ItoolSet
{
	public string ToolName => "log";

	public static readonly string log_path = "res://log";

	public terminal_result exec_command(string[]? args) {
		if (args is null)
			return terminal_result.usage("log | level <lowest level> | tag <tag> | reset | dump");

		if (args.Length == 1)
		{
			if (args[0] == "reset")
			{
				tool_log._instance.fliter = (data) => (int)data.level >= (int)logLevel.debug ? true : false;
				return terminal_result.ok("set filter to default");
			}
			else if (args[0] == "dump")
			{
				var path = tool_log._instance.dump(log_path);
				return terminal_result.ok($"save in {path}");
			}
		}

		if (args.Length == 2)
		{
			var (policy, name) = (args[0], args[1]);
			if (policy == "level")
			{
				int level = -1;
				int.TryParse(name, out level);
				if (level >= 0)
				{
					tool_log._instance.fliter = (data) => (int)data.level >= level ? true : false;
					return terminal_result.ok($"set level to {level}");
				}
				else
					return terminal_result.error("invaild level");
			}
			else if (policy == "tag")
			{
				tool_log._instance.fliter = (data) => data.tag == name ? true : false;
				return terminal_result.ok($"set tag to {name}");
			}
		}
		return terminal_result.error("no such usage");
	}


}