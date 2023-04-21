using Obj.map;
using Obj.sp_player;

namespace Obj.autoload;


public sealed class center_gameplay : IserviceCenter
{
	public Node main_node { get; set; }

    public static readonly string node_controller = "%player_controller";
    public static readonly string node_maploader = "%map";

    public event Action<Icontrollable>? player_changed;


    public mapLoader _map_loader;
	public playerCtrlPack? _player_controller;


	public center_gameplay(Node _main_node)
	{
		main_node = _main_node;
		_map_loader = new(_main_node);

		start_service();
	}

	public void start_service() {
		_player_controller = main_node.GetNode<playerCtrlPack>("player_controller");
	}

	public void stop_service() {

	}
}