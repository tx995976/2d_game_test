using Godot;
using System;

/*
# 物理控制器 -> action_event
    @输入action(just_pressed/just_released)
    @运动趋势(Vector2)
    @视角方向(Vector2)

*/

public partial class sp_controller : Node
{
    [Export]
    sp_player_root node_player;

    [Export]
    bool is_active;

    public override void _Ready(){
        SetProcessUnhandledInput(true);
    }

    public override void _UnhandledInput(InputEvent @event){
        if(@event is InputEventKey){
            
        }

            //node_player.EmitSignal(nameof(node_player.action_event),@event as InputEventAction);
    }

}
