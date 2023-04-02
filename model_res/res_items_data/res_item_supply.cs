namespace Obj.resource;

public partial class res_item_supply : Resource,IresItem
{
	
	[Export]
	public StringName item_name { get; set; } = string.Empty;

	[Export]
	public Texture2D? item_texture { get; set; }

	[Export]
	public Texture2D? item_type_texture { get; set; }

	[Export(PropertyHint.MultilineText)]
	public string comment { get; set; } = string.Empty;

	[Export]
	public StringName itemStyle { get; set; } = string.Empty;


	[Export]
	public int max_num { get; set; }

	//use_effect
	[Export]
	public Node? effect { get; set;}

}
