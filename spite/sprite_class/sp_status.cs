using Godot;
using System;


public partial class sp_status : Node
{

	public sp_player_root node_player;

	public override void _Ready(){
		SetPhysicsProcess(false);
		SetProcessUnhandledInput(false);
		node_player = Owner as sp_player_root;
		
	}

	public virtual void enter_st(){
		SetPhysicsProcess(true);
		node_player.action_event += process_action;
		//SetProcessUnhandledInput(true);
	}

	public virtual void exit_st(){
		SetPhysicsProcess(false);
		node_player.action_event -= process_action;
		//SetProcessUnhandledInput(false);		
	}

	public virtual void process_action(InputEvent @event){}
	
	[Signal]
	public delegate void status_changeEventHandler(int mode,string name_st);
	
}
