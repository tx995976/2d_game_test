using Obj.map;
using Obj.sp_player;

namespace Obj.autoload;


public sealed class centerGameplay : IserviceCenter
{
	public Node main_node { get; set; }

	public static readonly string node_controller = "%player_controller";
	public static readonly string node_maploader = "%map";

	public mapLoader _map_loader;
	public playerCtrlPack? _player_controller;

	#region event

	public event Action<Node2D>? player_changed;

	#endregion


	public centerGameplay(Node _main_node) {
		main_node = _main_node;
		_map_loader = new(_main_node);

		start_service();
	}

	public void start_service() {
		_player_controller = main_node.GetNode<playerCtrlPack>("player_controller");
	}

	public void stop_service() {}


	#region call_method

	public bool call_player_switch(string name) {
		var group = _map_loader.group_entity;

		if (group is null)
			return false;

		var entity = group.GetNodeOrNull<Node2D>(name);
		if (entity is null){
			logLine.warning("system",$"no such entity named {name}");
			return false;
		}

		_player_controller!._switch(entity);
		player_changed?.Invoke(entity);
		
		return true;
	}

	#endregion


}