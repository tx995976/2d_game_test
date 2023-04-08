namespace Obj.tool.toolSet;

using Obj.sp_player;

[toolSet]
public class toolSet_player : ItoolSet
{
	public string ToolName => "player";

	public terminal_result exec_command(string[]? args) {
		if (args is null || args.Length < 2)
			return terminal_result.usage("switch -name");

		if(args[0] == "switch"){
			var group = ObjMain.gameplayServe._map_loader.group_entity;
			if(group is null)
				return terminal_result.error("no group entity");
			
			var entity = group.GetNodeOrNull<Node2D>(args[1]);

			if(entity is null)
				return terminal_result.error("no such entity");

			ObjMain.gameplayServe._player_controller!._switch(entity);
		}

		return terminal_result.ok("ok");
	}
}