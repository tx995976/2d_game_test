using Godot;
using System;

using Obj.sp_player;

namespace sp_player_friend_1;

using mode_st = sp_state_machine.st_mode;

public partial class st_idle : sp_status
{

	public override void process_action(InputEvent @event){

		
	}

	public override void _PhysicsProcess(double delta){
		node_player.mov_dir = node_player.inp_mov_dir;
		node_player.view_dir = node_player.inp_mov_dir;

        if(node_player.mov_dir != Vector2.Zero)
			EmitSignal(nameof(status_change),(int)mode_st.st_swap,"walk");
	}


}
