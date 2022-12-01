using Godot;
using System;

namespace sp_player_collections;
/*
@人物实体 基类

#提供人物基本数据(移动趋势,视线方向)

#提供事件输入
	@通过物理控制器
	@通过代码控制器

#管理额外属性(attribute)
#特殊状态转移(e.g dead)
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

	/*
	//attribute for battle
	[Export]
	public float health;

	[Export]
	public float balance;

	[Export]
	public float armor;
	*/

	//基本状态机
	[Export]
	public sp_state_machine basic_state;

	public float view_mov_deg
	{
		get => view_dir.Dot(mov_dir);
	}

	public InputEvent action_input{
		set{
			//GD.Print("get");
			//action_input_node?.process_action(value);
			EmitSignal(nameof(action_event),value);
		}
	}

	//if need
	public InputEvent mouse_input{
		set{
			//action_input_node?.process_action(value);
			EmitSignal(nameof(action_mouse),value);
		}
	}

	public Vector2 inp_mov_dir = Vector2.Zero;
	public Vector2 inp_view_dir = Vector2.Zero;
		

	public virtual void _action_be_hit(){}

	[Signal]
	public delegate void action_eventEventHandler(InputEvent action);

	[Signal]
	public delegate void action_mouseEventHandler(); //if need

	//test
	public sp_status action_input_node;
}
