using Godot;
using System;

/*
@人物实体 基类

#提供人物基本数据(移动趋势,视线方向)

#提供事件转换输入
	@通过物理控制器
	@通过代码控制器

#管理额外属性(res_for_attribute)
*/

public partial class sp_player_root : CharacterBody2D
{
	[Export]
	Vector2 mov_dir;

	[Export]
	Vector2 view_dir;

	double view_mov_deg
	{
		get{
			return view_dir.Dot(mov_dir);
		}
	}

	[Signal]
	public delegate void action_eventEventHandler(InputEventAction action);



}
