using Godot;
using System;

public partial class map_item_door_1 : map_item_root
{
	
	[Export]
	public bool st_door;

	AnimationPlayer ani_node;

	public override void _Ready(){
		base._Ready();
		ani_node = (AnimationPlayer)GetNode("ani");
	}

	public override void _action_be_trigger(){
		if(st_door)
			ani_node.Play("door_open");
		else
			ani_node.PlayBackwards("door_open");
		st_door = !st_door;
	}

}

