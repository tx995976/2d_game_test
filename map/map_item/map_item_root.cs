using Godot;
using System;

namespace Obj.map.entity;

/*
地图互动物品基类

_action_be_trigger()
@触发-> group_call (group_trigger_{trigger.Name})

_action_be_hit()
@触发->物理碰撞->call

*/
public partial class map_item_root : Node2D
{
	[Export]
    public Node2D trigger_node;

    public override void _Ready(){
        if(trigger_node != null)
            AddToGroup("group_trigger_"+trigger_node.Name);
    }

    public virtual void _action_be_trigger(){}
    public virtual void _action_be_hit(){}
}
