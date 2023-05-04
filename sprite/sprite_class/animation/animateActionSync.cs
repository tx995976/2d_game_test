namespace Obj.sp_player;

public partial class animateActionSync
	: AnimationTree, IanimateActionSync
{
	static Dictionary<string, List<string>> cache_path = new();

	[Export]
	public string tex_name = string.Empty;

	[Export]
	public res_animation_blend? animationBlend { get; set; }

	[Export]
	public string playbackPath { get; set; } = string.Empty;

	public Iactor? stateSource { get; set; }


	Iwalkable? _viewSource;
	actionInfo? _actionSource;
	
	AnimationNodeStateMachinePlayback? _pb_back;
	List<string>? _animateParam;

	public override void _Ready() {

		stateSource = this.SearchOwner<Iactor>();
		if (stateSource is null)
		{
			logLine.warning("animate", $"{this} Owner not find");
			return;
		}

		blend_path_load();

		_viewSource = stateSource as Iwalkable;
		stateSource.infoAction!.stateChanged += actionStateChanged;
		_actionSource = stateSource.infoAction;

		_pb_back = (AnimationNodeStateMachinePlayback)Get(playbackPath);
		if (_pb_back is null)
		{
			logLine.warning("animate", $"{this} pb_back not find");
		}

	}

	void blend_path_load() {
		if (cache_path.ContainsKey(tex_name))
			_animateParam = cache_path[tex_name];
		else
		{
			var property = this.GetPropertyList();
			_animateParam = property.Where(p => ((string)p["name"]).EndsWith("blend_position"))
					.Select(p => (string)p["name"])
					.ToList();

			logLine.debug("animate", $"load blend for {tex_name}");
			cache_path[tex_name] = _animateParam;
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
