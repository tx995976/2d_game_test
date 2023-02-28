namespace Obj.autoload;

public class centerHud : IserviceCenter
{
    public static readonly string path_hudNode = "hud_layer";

    CanvasLayer? _cantainer_layer;
    Node _rootNode;

	public centerHud(Node rootNode)
	{
		_rootNode = rootNode;
	}

	public void start_service() {
		
	}

	public void stop_service() {
		
	}


}