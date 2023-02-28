namespace Obj.sp_player;

public partial class animateActionSync
	: AnimationTree, IanimateActionSync
{

	public Iactor? stateSource { get; set; }

	[Export]
	public res_animation_blend? animationBlend { get; set; }

	[Export]
	public string? playbackPath { get; set; }

	Iwalkable? _viewSource;
	actionInfo? _actionSource;
	AnimationNodeStateMachinePlayback? _pb_back;
	StringName[]? _animateParam;

	public override void _Ready() {
		//GD.Print("Owner is ",Owner);

		stateSource = (Iactor)Owner;
		_viewSource = (Iwalkable)Owner;

		stateSource.infoAction!.stateChanged += actionStateChanged;
		_actionSource = stateSource.infoAction;

		_pb_back = (AnimationNodeStateMachinePlayback)Get(playbackPath);

		_animateParam = animationBlend?.blend_path;
		if (animationBlend is null)
		{
			SetProcessInput(false);
		}
	}

	public override void _PhysicsProcess(double delta) {
		foreach (var i in _animateParam!)
		{
			Set(i!, _viewSource!.view_dir);
		}
	}

	public void Travel(string state) {
		_pb_back!.Travel(state);
	}

	public void actionStateChanged() {
		var _actionState = _actionSource!._shortcut();
		_pb_back!.Travel(_actionState);
	}

}
