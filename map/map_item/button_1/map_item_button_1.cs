using Godot;
using System;

using Obj.ev_collection;

public partial class map_item_button_1 : ev_trigger_button
{
	public override void _action_be_pressed()
	{
		base._action_be_pressed();
		GetTree().CallGroup(("group_trigger_" +this.Name),"_action_be_trigger");
	}

}
