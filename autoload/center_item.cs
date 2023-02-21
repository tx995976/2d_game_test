using Godot;
using Godot.Collections;

using Obj.resource;

namespace Obj.autoload;

/*
#item_center
	@物品静态数据存储
	@生成动态数据
	@新数据注册(地图包数据)
*/

public partial class center_item : Node
{
	public static center_item? instance;
	//public static string path_node = "/root/center_item";
	public static string path_data = "res://resource/tres_item/"; //default_data

	[Export]
	public gdc.Dictionary<StringName,res_item_static_data> dic_items { get; set; } = new();

	[Export]
	public gdc.Dictionary<StringName,res_weapon_static_data> dic_weapons { get; set; } = new();

	public override void _EnterTree(){
		instance = this;
	}


	public override void _Ready(){
		//default data load
		Task.Run(() => load_res());
	}

	void load_res(){
		var dir_datas = DirAccess.Open(path_data);
		foreach(var filename in dir_datas.GetFiles()){
			//GD.Print(filename);
			if(filename.EndsWith(".tres")){
				GD.Print($"load {path_data+filename}");
				var res = GD.Load(path_data+filename);
				reg_data(res);
			}
		}
	}

	#region method_bag

	public data_item init_item(StringName str_item,int nums){
		var new_data = new data_item();
		new_data.define = dic_items[str_item];
		new_data.num_now = nums;
		return new_data;
	}

	public data_weapon init_weapon(StringName str_weapon,int ammo_in,int ammo_bag,int sup){
		var new_data = new data_weapon();
		var define_res = dic_weapons[str_weapon];
		//
		new_data.define = define_res;
		new_data.ammo_in = (ammo_in < define_res.max_ammo_in) ? ammo_in : define_res.max_ammo_in;
		new_data.ammo_bag = (ammo_bag < define_res.bag_ammo) ? ammo_bag : define_res.bag_ammo;
		new_data.sup = sup < (define_res.sup_max) ? sup : define_res.sup_max;
		return new_data;
	}

	public void reg_data(Resource reg_info){
		if(reg_info is res_item_static_data info_item){
			if(!dic_items.ContainsKey(info_item.item_name))
				dic_items[info_item.item_name] = info_item;
		}
		else if(reg_info is res_weapon_static_data info_weapon){
			if(!dic_weapons.ContainsKey(info_weapon.item_name))
				dic_weapons[info_weapon.item_name] = info_weapon;
		}
		else
			GD.Print($"not match resource {reg_info}");
	}

	#endregion
}
