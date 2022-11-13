using Godot;
using Godot.Collections;
using System.Collections;


/*
#人物基础物理控制器 -> action_event
    @输入action(just_pressed/just_released)
    @运动趋势(mov_dir : Vector2)
    @视角方向(view_dir : Vector2)
*/

public partial class sp_controller : Node
{

    [Export]
    public sp_player_root node_player;

    public override void _Ready(){
        SetProcessUnhandledInput(true);
        node_player = Owner as sp_player_root;


        /*
        tmp_action.Action = "action_up";
        tmp_action.Pressed = false;
        Input.ParseInputEvent(tmp_action);
        */
    }


    public override void _PhysicsProcess(double delta){
        node_player.mov_dir = Input.GetVector("action_left","action_right","action_up","action_down");
        node_player.view_dir = node_player.GetLocalMousePosition();
    }


    //动作 [@event]--player_node--> sp_status[process_action()]
    public override void _UnhandledInput(InputEvent @event){
        if(!(@event is InputEventMouseMotion)){
            node_player.EmitSignal(nameof(node_player.action_event),@event);
            //GD.Print($"ev {@event.AsText()} pressed : {@event.IsPressed()}");
        }
        else{
            node_player.EmitSignal(nameof(node_player.action_event),@event);
        }
    }


}
