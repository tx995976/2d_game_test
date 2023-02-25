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
	gdc.Array<string>? _animateParam;

	string _actionState = string.Empty;

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
		
		_actionState = _actionSource!.motionName;
		if(_actionSource.equipStateName is not null)
			_actionState += '_'+_actionSource.equipStateName;
		if(_actionSource.equipStyleName is not null)
			_actionState += '_'+_actionSource.equipStyleName;
		if(_actionSource.actionName is not null)
			_actionState += '_'+_actionSource.actionName;

		_pb_back!.Travel(_actionState);
	}

}
