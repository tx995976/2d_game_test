using Godot;
using System;

namespace Obj.res_collection;

public partial class res_item_root : Resource
{
	//texture_for_ui
	[Export]
	public StringName item_name;

	[Export]
	public Texture2D item_texture;

	[Export]
	public Texture2D item_type_texture;

	[Export(PropertyHint.MultilineText)]
	public string comment;

	
}
