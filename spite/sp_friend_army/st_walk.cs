using Godot;
using System;

using mode_st = sp_state_machine.st_mode;

namespace sp_friend_1;

public partial class st_walk : sp_status
{

    public override void process_action(InputEvent @event){

    }

    public override void _PhysicsProcess(double delta){
        if(node_player.mov_dir == Vector2.Zero)
            EmitSignal(nameof(status_change),(int)mode_st.st_swap,"idle");
        //mov
        //GD.Print($"mov_distance {node_player.mov_dir * (float)(node_player.speed * delta)}");
        node_player.MoveAndCollide(node_player.mov_dir * (float)(node_player.speed * delta));

    }


}
