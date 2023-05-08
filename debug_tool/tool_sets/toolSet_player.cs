namespace Obj.tool.toolSet;

using Obj.sp_player;

[toolSet]
public class toolSet_player : ItoolSet
{
	public string ToolName => "playc";

	public terminal_result exec_command(string[]? args) {
		if (args is null)
			return terminal_result.usage("switch -name");
		
		if(args[0] == "free"){
			ObjMain.gameplayServe._player_controller!.free_view();
			return terminal_result.ok("ok");
		}

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