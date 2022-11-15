using Godot;
using System;
using static Godot.GD;

namespace ui_collections;
public partial class text_richtext_node : RichTextLabel{

	public enum out_type{
		ONE_OUT,
		ALL_OUT
	}

	[Export(PropertyHint.Enum)]
	out_type txt_out_type;

	[Export(PropertyHint.MultilineText)]
	String txt_static;

	[Export]
	double tween_time;

	[Export]
	double time_left;

	[Export]
	double out_time = 0.5;

	public override void _Ready(){
		var tween = GetTree().CreateTween().SetEase(Tween.EaseType.InOut).SetTrans(Tween.TransitionType.Back);

		switch(txt_out_type){
			case out_type.ONE_OUT:
				VisibleRatio = 0;
				tween.TweenProperty(this,nameof(VisibleRatio).ToLower(),1.0,tween_time);
				break;
			case out_type.ALL_OUT:
				Modulate = new Color(1,1,1,0);
				tween.TweenProperty(this,"modulate",new Color(1,1,1,1),tween_time);
				break;
		}

		if(time_left != 0.0){
			var timer = GetTree().CreateTimer(time_left);
			timer.Timeout += _exit_node;
		}
		RequestReady();
	}

	 async public void _exit_node(){
		if(Owner != null)
			return;
		var tween = GetTree().CreateTween().SetEase(Tween.EaseType.InOut).SetTrans(Tween.TransitionType.Back);
		tween.TweenProperty(this,"modulate",new Color(1,1,1,0),out_time);
		await ToSignal(tween,"finished");
		EmitSignal(nameof(txt_destroy),this);
		Owner.RemoveChild(this);
	}


	[Signal]
	public delegate void txt_destroyEventHandler(text_richtext_node node_self);

}
