using Godot;
using System;


//地图内交互物品基类

public partial class map_static_item_root : StaticBody2D
{
    [Export]
    string group_name;

    public override void _Ready(){
        if(group_name != null)
            AddToGroup(group_name);

    }

    public virtual void _action_be_trigger(){}
    public virtual void _action_be_hit(){}


}
