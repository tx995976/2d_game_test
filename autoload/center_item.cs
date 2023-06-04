namespace Obj.autoload;

/*
#item_center
	@新数据注册(地图包数据)
*/

public class centerItem : IserviceCenter
{
	static string path_data = "res://resource/tres_item/"; //default_data

	public Node main_node { get; set; }

	public Dictionary<StringName, IresItem> item_supply { get; set; } = new();
	public Dictionary<StringName, IresItem> item_equip { get; set; } = new();

	

	public centerItem(Node main_node) {
		this.main_node = main_node;
		
	}

	public void start_service() {
		load_res(path_data);
	}

	public void stop_service() {

	}

	void load_res(string path) {
		var files = GDfile.GetResFilePaths(path,resNames.resSuffix);

		logLine.info("system",$"item Loading: ");
		foreach (var filename in files)
		{
			logLine.info("resource",$"Load {filename}");
			var res = GD.Load<IresItem>(filename);
			if(res is res_item_equip)
				item_equip.Add(res.item_name!,res);
			else
				item_supply.Add(res.item_name!,res);
		}
	}

	#region method_bag

	// public data_item init_item(StringName str_item,int nums){
	// 	var new_data = new data_item();
	// 	new_data.define = dic_items[str_item];
	// 	new_data.num_now = nums;
	// 	return new_data;
	// }

	// public data_weapon init_weapon(StringName str_weapon,int ammo_in,int ammo_bag,int sup){
	// 	var new_data = new data_weapon();
	// 	var define_res = dic_weapons[str_weapon];
	// 	//
	// 	new_data.define = define_res;
	// 	new_data.ammo_in = (ammo_in < define_res.max_ammo_in) ? ammo_in : define_res.max_ammo_in;
	// 	new_data.ammo_bag = (ammo_bag < define_res.bag_ammo) ? ammo_bag : define_res.bag_ammo;
	// 	new_data.sup = sup < (define_res.sup_max) ? sup : define_res.sup_max;
	// 	return new_data;
	// }

	// public void reg_data(Resource reg_info){
	// 	if(reg_info is res_item_static_data info_item){
	// 		if(!dic_items.ContainsKey(info_item.item_name))
	// 			dic_items[info_item.item_name] = info_item;
	// 	}
	// 	else if(reg_info is res_weapon_static_data info_weapon){
	// 		if(!dic_weapons.ContainsKey(info_weapon.item_name))
	// 			dic_weapons[info_weapon.item_name] = info_weapon;
	// 	}
	// 	else
	// 		GD.Print($"not match resource {reg_info}");
	// }

	#endregion
}
