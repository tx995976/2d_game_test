using Godot;
using System;

namespace Obj.resource;

public partial class res_item_root : Resource
{
	//texture_for_ui
	[Export]
	public StringName item_name { get; set; } = "";

	[Export]
	public Texture2D? item_texture { get; set; }

	[Export]
	public Texture2D? item_type_texture { get; set; }

	[Export(PropertyHint.MultilineText)]
	public string? comment { get; set; }


}
