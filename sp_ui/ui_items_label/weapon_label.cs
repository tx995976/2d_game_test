using Godot;
using System;

using res_collection;

namespace ui_collections;

/*
#武器标签


*/
public partial class weapon_label : Panel
{
	TextureRect item_tex;
	TextureRect item_type_tex;
	Label name_item;
	Label info_ammo;

	Label info_sup;
	ProgressBar sup_progress;

	public Vector2 pos_open;
	public int pos_num;

	[Export]
	public data_weapon item_dym;

	[Signal]
	public delegate void selectedEventHandler(int pos);

	public override void _Ready() {
		item_tex = GetNode<TextureRect>(nameof(item_tex));
		item_type_tex = GetNode<TextureRect>(nameof(item_type_tex));
		name_item = GetNode<Label>(nameof(name_item));
		info_ammo = GetNode<Label>(nameof(info_ammo));
		//other_info
		info_sup = GetNode<Label>(nameof(info_sup));
		sup_progress = info_sup.GetNode<ProgressBar>(nameof(sup_progress));

		MouseEntered += _mouse_enter;
		pos_open = Position;

		//test
		//flush_label();
	}

	public void flush_label() {
		if(item_dym == null)
			return;

		var label_data = item_dym.define;

		name_item.Text = label_data.item_name;
		item_tex.Texture = label_data.item_texture;
		item_type_tex.Texture = label_data.item_type_texture;

		info_ammo.Text = $"{item_dym.ammo_in}/{item_dym.ammo_bag}";

		if (label_data.has_sup) {
			sup_progress.MaxValue = label_data.sup_max;
			sup_progress.Value = item_dym.sup;
			info_sup.Visible = true;
		}
		else {
			info_sup.Visible = false;
		}
	}

	public void sync_to_data() {
		info_ammo.Text = $"{item_dym?.ammo_in}/{item_dym?.ammo_bag}";
		if (info_sup.Visible)
			sup_progress.Value = (item_dym == null) ? 0 : item_dym.sup;
	}

	public void _mouse_enter() {
		(Material as ShaderMaterial)?.SetShaderParameter("selec_flag", true);
		EmitSignal(nameof(selected),pos_num);
		GD.Print($"weapon {pos_num} be selected");
	}

	public void _mouse_exit() {
		(Material as ShaderMaterial)?.SetShaderParameter("selec_flag", false);
		GD.Print($"weapon {pos_num} defuse selected");
	}

}
