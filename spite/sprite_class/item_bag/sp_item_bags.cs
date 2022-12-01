using Godot;
using System.Collections.Generic;

using res_collection;
using autoload_sp;

namespace sp_player_collections;

/*
#人物背包
	@add_item => 添加物品至指定位置
	@swap => 交换物品 --> 原有物品
	@drop => 丢弃 --> 原有物品


#逻辑判断
	@ui_select => 上层负责判断情况
	@ui_select --> [action:@select] --> item_num -->[signal:select_changed]
*/

public partial class sp_item_bags : Node
{
	public const int max_weapon = 4;
	public const int max_item = 4;

	public center_item item_node;
	
	public data_item selected_item{
		get => arr_item[item_num];
	}
	public data_weapon selected_weapon{
		get => arr_weapon[weapon_num];
	}

	public data_weapon[] arr_weapon = new data_weapon[max_weapon];
	public data_item[] arr_item = new data_item[max_item]; 

	public int item_num{
		get => item_num;
		set{
			item_num = value;
			EmitSignal(nameof(select_changed));
		}
	}

	public int weapon_num {
		get => weapon_num;
		set{
			weapon_num = value;
			EmitSignal(nameof(select_changed));
			
		}
	}
	//
	[Signal]
	public delegate void select_changedEventHandler();  //选择更新时触发

//--------------------------------------------------------------

	public override void _Ready(){
		item_node = GetNode<center_item>(center_item.path_node);

		//test
		var timer = GetTree().CreateTimer(3.0);
		timer.Timeout += test_method;
	}

	//test
	public void test_method(){
		add_item(item_node.init_item("phc-12",6),0);
		add_item(item_node.init_item("phc-12",7),1);
        
        add_item(item_node.init_weapon("mk4-s",10,60,5),0);
        add_item(item_node.init_weapon("mk4-s",1,60,1),2);
        GD.Print("init_bag_item");
	}

	public void add_item(Resource item,int pos){
		if(item is data_item)
			arr_item[pos] = item as data_item;
		else
			arr_weapon[pos] = item as data_weapon;
	}

	public data_item swap_item(data_item item,int pos){
		var swap_data = arr_item[pos];
		arr_item[pos] = item;
		return swap_data;
	}

	public data_item drop_item(int pos){
		var gc_data = arr_item[pos];
		arr_item[pos] = null;
		return gc_data;
	}

	public data_weapon swap_weapon(data_weapon weapon,int pos){
		var swap_data = arr_weapon[pos];
		arr_weapon[pos] = weapon;
		return swap_data;
	}

	public data_weapon drop_weapon(int pos){
		var gc_data = arr_weapon[pos];
		arr_weapon[pos] = null;
		return gc_data;
	}
}
