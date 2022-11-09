using Godot;
using System;


public partial class sp_status : Node
{
	
	public override void _Ready(){
		SetPhysicsProcess(false);
		SetProcessUnhandledInput(false);
	}

	public virtual void enter_st(){
		SetPhysicsProcess(true);
		SetProcessUnhandledInput(true);
	}

	public virtual void exit_st(){
		SetPhysicsProcess(false);
		SetProcessUnhandledInput(false);		
	}

	public virtual void process_event(){}
	
	[Signal]
	public delegate void status_changeEventHandler(int mode,string name_st);
	
}
