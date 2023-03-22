using Obj.map;
using Obj.sp_player;

namespace Obj.autoload;


public sealed class center_gameplay : IserviceCenter
{
	public Node main_node { get; set; }

    public static readonly string node_controller = "%player_controller";
    public static readonly string node_maploader = "%map";

    public event Action<Icontrollable>? player_changed;

	Node2D? _player_controller;
    mapLoader? _map_loader;


	public center_gameplay(Node main_node) {
		this.main_node = main_node;
		start_service();
	}

	public void start_service() {

	}

	public void stop_service() {

	}
}