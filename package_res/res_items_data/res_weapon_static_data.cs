using Godot;
using System;

namespace res_collection;

/*
#武器基类
	@远程武器(近战,远程)
	@近战武器(近战)

#特殊效果
	@Node--->

*/

public partial class res_weapon_static_data : res_item_root
{
	[Export]
	public bool is_gun;//是否为远程武器

	[Export]
	public int knife_range;//近战距离

    //sup_setting
	[Export]
	public bool has_sup;//消声器

	[Export]
	public int sup_max;//消声器耐久

	//ammo_setting
	[Export]
	public int max_ammo_in;//最大弹匣容量

	[Export]
	public int bag_ammo;//最大备弹容量

	[Export]
	public int max_range;//子弹最大距离

	//shoot_mode
	[Export]
	public int num_bullet;//发射模式()

	//特殊效果
	[Export]
	public Node effect_node;


}
