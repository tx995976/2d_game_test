using Godot;
using System;

namespace Obj.resource;

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
	public bool is_gun { get; set; }//是否为远程武器

	[Export]
	public int knife_range { get; set; }//近战距离

	//sup_setting
	[Export]
	public bool has_sup { get; set; }//消声器

	[Export]
	public int sup_max { get; set; }//消声器耐久

	//ammo_setting
	[Export]
	public int max_ammo_in { get; set; }//最大弹匣容量

	[Export]
	public int bag_ammo { get; set; }//最大备弹容量

	[Export]
	public int max_range { get; set; }//子弹最大距离

	//shoot_mode
	[Export]
	public int num_bullet { get; set; }//发射模式()

	//特殊效果
	[Export]
	public Node? effect { get; set; }


}
