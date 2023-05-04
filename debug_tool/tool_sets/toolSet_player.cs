namespace Obj.tool.toolSet;

using Obj.sp_player;

[toolSet]
public class toolSet_player : ItoolSet
{
	public string ToolName => "player";

	public terminal_result exec_command(string[]? args) {
		if (args is null || args.Length < 2)
			return terminal_result.usage("switch -name");

		if (args[0] == "switch")
		{
			var res = ObjMain.gameplayServe.call_player_switch(args[1]);
			if (res)
				return terminal_result.ok("ok");
			else
				return terminal_result.error("no such entity");
		}

		return terminal_result.ok("ok");
	}
}