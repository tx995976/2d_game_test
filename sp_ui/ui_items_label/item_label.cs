using System;
using Godot;
using Obj.resource;

namespace Obj.ui;

/*
#物品标签
	@链接动态物品数据
	@可选中效果
*/

public partial class item_label : Panel
{
	TextureRect item_tex;
	TextureRect item_type_tex;
	Label name_item;
	Label info_ammo;
	ProgressBar sup_progress;

 
	#region for_select

	public Vector2 pos_open { get; set; }
	public int pos_num { get; set; }
	
	#endregion

	[Export]
	public Resource? item{ 
		get => _item_dym; 
		set{
			clear_label();
			_item_dym = value;
			if(value == null)
				return;
			if(value is data_item item)
				flush_label(item);
			else
				flush_label((data_weapon)value);

		} 
	}
	Resource? _item_dym;

	
	[Signal]
	public delegate void selectedEventHandler(int pos);

	public Action<int>? select;

	public override void _EnterTree(){
		item_tex = GetNode<TextureRect>(nameof(item_tex));
		item_type_tex = GetNode<TextureRect>(nameof(item_type_tex));
		name_item = GetNode<Label>(nameof(name_item));
		info_ammo = GetNode<Label>(nameof(info_ammo));
		sup_progress = GetNode<ProgressBar>(nameof(sup_progress));

	}

	public override void _Ready() {

		pos_open = Position;

		//flush_label();
	}


	#region item_flush

	public void flush_label(data_item item_dym) {
		var label_data = item_dym.define!;

		name_item.Text = label_data.item_name;
		item_tex.Texture = label_data.item_texture;
		item_type_tex.Texture = label_data.item_type_texture;

		info_ammo.Text = $"{item_dym.num_now}";

		item_dym.signal_data_change += sync_item;
	}

	public void flush_label(data_weapon item_dym) {
		var label_data = item_dym.define;

		name_item.Text = label_data.item_name;
		item_tex.Texture = label_data.item_texture;
		item_type_tex.Texture = label_data.item_type_texture;

		info_ammo.Text = $"{item_dym.ammo_in}/{item_dym.ammo_bag}";

		if (label_data.has_sup) {
			sup_progress.MaxValue = label_data.sup_max;
			sup_progress.Value = item_dym.sup;
			sup_progress.Visible = true;
		}
		else {
			sup_progress.Visible = false;
		}

		item_dym.signal_data_change += sync_weapon;
	}

	public void clear_label(){
		name_item.Text = null;
		item_tex.Texture = null;
		item_type_tex.Texture = null;

		info_ammo.Text = "";
		sup_progress.Visible = false;

		if(item is data_item iitem){
			iitem.signal_data_change -= sync_item;
		}
		else if(item is data_weapon witem){
			witem.signal_data_change -= sync_weapon;
		}	
	}

	#endregion

	#region data_sync

	public void sync_item(){
		var item_dym = (data_item)item!;

		info_ammo.Text = $"{item_dym.num_now}";
	}

	public void sync_weapon(){
		var item_dym = (data_weapon)item!;

		info_ammo.Text = $"{item_dym.ammo_in}/{item_dym.ammo_bag}";
		sup_progress.Value = item_dym.sup;
	}

	public string? get_commit(){
		if(item is data_item iitem){
			return iitem.define!.comment;
		}
		else if(item is data_weapon witem){
			return witem.define!.comment;
		}	
		return "";
	}

	#endregion

	#region mouse_action

	public void _mouse_enter() {
		(Material as ShaderMaterial)?.SetShaderParameter("selec_flag", true);
		select?.Invoke(pos_num);
		GD.Print($"item {pos_num} be selected");
	}

	public void _mouse_exit() {
		(Material as ShaderMaterial)?.SetShaderParameter("selec_flag", false);
		GD.Print($"item {pos_num} defuse selected");
	}

	public void enable_mouse(){
		MouseEntered += _mouse_enter;
	}

	#endregion

}
 
