using Obj.autoload;

namespace Obj.map;

public class mapLoader
{
	public static readonly string basePath = "res://map/test_tscn/";
	public static readonly string worldName = "world2d";

	Node main_node;

	public mapLoader(Node main_node)
	{
		this.main_node = main_node;
	}

	public Node2D? group_map;
	public Node2D? group_entity;

	async public Task call_map_load(string map_name) {
		//call load ui
		var path = basePath + map_name + resNames.csnSuffix;
		if (!FileAccess.FileExists(path)){
			logLine.warning("resource",$"no such map named {map_name}");
			return;
		}

		var mapmeta = await GDext.LoadAsync<PackedScene>(path);
		var maptree = mapmeta.Instantiate<Node2D>();

		await free_map();
		main_node.JoinNode(maptree);

		group_map = maptree.GetNode<Node2D>("map");
		group_entity = maptree.GetNode<Node2D>("entity");

		//ADDON gameplay init

	}


	async Task free_map(){
		await Task.CompletedTask;

		var maptree = main_node.GetNodeOrNull<Node2D>(worldName);
		if(maptree != null){
			maptree.RemoveSelf();
			maptree.QueueFree();
		}
	}

	



}