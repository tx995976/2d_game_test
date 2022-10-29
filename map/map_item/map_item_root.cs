using Godot;
using System;

public partial class map_item_root : Node2D
{
	[Export]
    public Node2D trigger_node;

    public override void _Ready(){
        if(trigger_node != null)
            AddToGroup("ev_button_"+trigger_node.Name);
    }

    public virtual void _action_be_trigger(){}
    public virtual void _action_be_hit(){}
}
