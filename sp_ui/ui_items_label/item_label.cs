using Godot;
using System;

using res_collection;

namespace ui_collections;

/*
#物品标签

*/

public partial class item_label : Panel
{
	TextureRect item_tex;
	TextureRect item_type_tex;
	Label name_item;
	Label info_ammo;

	[Export]
	public data_item item_dym;

	public override void _Ready(){
		item_tex = GetNode<TextureRect>(nameof(item_tex));
		item_type_tex = GetNode<TextureRect>(nameof(item_type_tex));
		name_item = GetNode<Label>(nameof(name_item));
		info_ammo = GetNode<Label>(nameof(info_ammo));
	}

	public void flush_label(){

		var label_data = item_dym.define;

		name_item.Text = label_data.item_name;
		item_tex.Texture = label_data.item_texture;
		item_type_tex.Texture = label_data.item_type_texture;

		info_ammo.Text = $"{item_dym.num_now}";
	}

	public void sync_to_data(){
		info_ammo.Text = $"{item_dym.num_now}";
	}





}
