using Godot;
using System;
using static Godot.GD;

public partial class sp_map_lifter : Area2D{
	[Export(PropertyHint.ArrayType)]
	int[] floor_len;

	[Export]
	Double time_left;

	[Export]
	int next_floor;

	int floor_now = 0;
	Vector2 delta_trans = Vector2.Zero;
	Vector2 pre_pos;

	public override void _Ready(){
		BodyEntered += _sp_enter;
		BodyExited += _sp_exit;
		SetPhysicsProcess(false);
	}

	public void _sp_enter(Node2D body){
		body.AddToGroup("in_lift");
		Print((object)(body + " entered"));
	}

	public void _sp_exit(Node2D body){
		body.RemoveFromGroup("in_lift");
		Print((object)(body + " exited"));
	}

	async public void _lift_start(){
		var tween = GetTree().CreateTween().SetProcessMode(Tween.TweenProcessMode.Physics).SetEase(Tween.EaseType.InOut).SetTrans(Tween.TransitionType.Quad);
		Vector2 mov_relat = new Vector2(0,floor_len[next_floor] - floor_len[floor_now]);
		tween.TweenProperty(this,nameof(Position).ToLower(),mov_relat,time_left).AsRelative();
		pre_pos = Position;
		SetPhysicsProcess(true);

		await ToSignal(tween,nameof(tween.Finished).ToLower());
		SetPhysicsProcess(false);
		floor_now = next_floor;
		next_floor = (next_floor+1) % floor_len.Length;
	}

	public override void _PhysicsProcess(double delta){
		GetTree().SetGroup("in_lift","extra_move",Position-pre_pos);
		pre_pos = Position;
	}

}
