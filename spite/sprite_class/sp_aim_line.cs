using Godot;
using System;

namespace sp_player_collections;

/*
#物理设备瞄准线
	@player使用
	@提供碰撞检测
*/

public partial class sp_aim_line : RayCast2D
{
	[Export]
	public Vector2 ray_lenth;

	public sp_player_root node_player;
	public Line2D node_line;

	public bool ray_active{
		get{return ray_active;}
		set{
			SetPhysicsProcess(value);
			SetProcessUnhandledInput(value);
			LookAt(GetGlobalMousePosition());
			ray_active = value;
		}
	}

    public override void _Ready(){
        SetPhysicsProcess(false);
		SetProcessUnhandledInput(false);
		Visible = false;

		node_player = Owner as sp_player_root;
		node_line = GetNode<Line2D>("aim_line");

		TargetPosition = ray_lenth;
    }

	public void action_mouse(){

	}

    public override void _PhysicsProcess(double delta){
		
    }


}
