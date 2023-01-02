using Godot;
using System;

namespace Obj.sp_player.status;

using mode_st = sp_state_machine.st_mode;

public partial class st_idle : sp_status
{


	public override void process_action(InputEvent @event){
		
	}

	public override void _PhysicsProcess(double delta){
		if(node_player.mov_dir != Vector2.Zero)
			EmitSignal(nameof(status_change),(int)mode_st.st_swap,"walk");

	}
}
