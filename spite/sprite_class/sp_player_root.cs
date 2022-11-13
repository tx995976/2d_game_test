using Godot;
using System;

/*
@人物实体 基类

#提供人物基本数据(移动趋势,视线方向)

#提供事件输入
	@通过物理控制器
	@通过代码控制器

#管理额外属性(attribute)
#特殊状态转移
*/

public partial class sp_player_root : CharacterBody2D
{

	//attribute for direct
	[Export]
	public Vector2 mov_dir = Vector2.Zero;

	[Export]
	public Vector2 view_dir = Vector2.Zero;

	//attribute for move
	[Export]
	public int speed;

	//attribute for battle
	[Export]
	public float health;

	[Export]
	public float balance;

	[Export]
	public float armor;

	[Export]
	public sp_state_machine basic_state;


	public float view_mov_deg
	{
		get{
			return view_dir.Dot(mov_dir);
		}
	}

	public virtual void _action_be_hit(){}

	[Signal]
	public delegate void action_eventEventHandler(InputEvent action);

	[Signal]
	public delegate void action_mouseEventHandler();

}
