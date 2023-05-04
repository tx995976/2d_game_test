using Obj.hud;
using Obj.ui;

namespace Obj.autoload;

public class centerHud : IserviceCenter
{
	public static readonly string path_hudNode = "%hud_layer";
	public static readonly string path_uiNode = "%ui_layer";

	public static readonly string name_huditem = "hud_item";

	public static readonly string name_uitxt = "ui_txt";

	public Node main_node { get; set; }

	public CanvasLayer? _cantainer_hud;
	public CanvasLayer? _cantainer_ui;

	//public event Action<Icontrollable>? player_changed;
	

	#region hud_node

	public hudItem? hud_item { get; set; }

	#endregion

	#region ui_node

	public txtViewer? ui_txt { get; set; }

	#endregion


	public centerHud(Node main_node) {
		this.main_node = main_node;
		start_service();
	}

	public void start_service() {
		logLine.debug("system",$"hud Loading: ");
		_cantainer_hud = main_node.GetNode<CanvasLayer>(path_hudNode);
		_cantainer_ui = main_node.GetNode<CanvasLayer>(path_uiNode);

		init_hud();
	}

	public void stop_service() {

	}

	void init_hud() {
		//cost
		hud_item = _cantainer_hud!.GetNode<hudItem>(name_huditem);

		ui_txt = _cantainer_ui!.GetNode<txtViewer>(name_uitxt);

		

	}

}