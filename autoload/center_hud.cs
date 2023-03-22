using Obj.hud;
using Obj.sp_player;

namespace Obj.autoload;

public class centerHud : IserviceCenter
{
	public static readonly string path_hudNode = "%hud_layer";

	public static readonly string name_huditem = "hud_item";
	public static readonly string name_hudtxt = "hud_txt";

	public Node main_node { get; set; }

	public CanvasLayer? _cantainer_layer;

	//public event Action<Icontrollable>? player_changed;


	#region hud_node

	public hudItem? hud_item { get; set; }
	public txtViewer? hud_txt { get; set; }

	#endregion


	public centerHud(Node main_node) {
		this.main_node = main_node;
		start_service();
	}

	public void start_service() {
		GD.Print($"hud Loading: ");
		_cantainer_layer = main_node.GetNode<CanvasLayer>(path_hudNode);
		init_hud();

	}

	public void stop_service() {

	}

	void init_hud() {
		hud_item = _cantainer_layer!.GetNode<hudItem>(name_huditem);
		hud_txt = _cantainer_layer!.GetNode<txtViewer>(name_hudtxt);
	}


}