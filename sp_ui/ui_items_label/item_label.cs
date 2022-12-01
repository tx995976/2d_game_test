using Godot;

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

	public select_panel node_selecter; 

	public Vector2 pos_open;
	public int pos_num;

	[Export]
	public data_item item_dym;

	[Signal]
	public delegate void selectedEventHandler(int pos);

	public override void _Ready() {
		item_tex = GetNode<TextureRect>(nameof(item_tex));
		item_type_tex = GetNode<TextureRect>(nameof(item_type_tex));
		name_item = GetNode<Label>(nameof(name_item));
		info_ammo = GetNode<Label>(nameof(info_ammo));

		MouseEntered += _mouse_enter;
		pos_open = Position;

		//flush_label();
	}

	public void flush_label() {
		if(item_dym == null) 
			return;

		var label_data = item_dym.define;

		name_item.Text = label_data.item_name;
		item_tex.Texture = label_data.item_texture;
		item_type_tex.Texture = label_data.item_type_texture;

		info_ammo.Text = $"{item_dym.num_now}";
	}

	public void sync_to_data() {
		info_ammo.Text = $"{item_dym?.num_now}";
	}

	public void _mouse_enter() {
		(Material as ShaderMaterial)?.SetShaderParameter("selec_flag", true);
		EmitSignal(nameof(selected),pos_num);
		GD.Print($"item {pos_num} be selected");
	}

	public void _mouse_exit() {
		(Material as ShaderMaterial)?.SetShaderParameter("selec_flag", false);
		GD.Print($"item {pos_num} defuse selected");
	}

}
