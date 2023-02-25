namespace Obj.hud;

public partial class confimTipProgress : TextureProgressBar
{
	public static double default_time = 1.0;

	public Action? confimAction { get; set; }

	Tween? _tween;

	public override void _Ready() {
		_tween = CreateTween();
		_tween.TweenProperty(this, "value", 100, default_time);
		_tween!.Stop();

		_tween.Finished += (
			() => _tween.Stop());

		_tween.Finished += (
			() => confimAction?.Invoke());
	}

	public override void _Input(InputEvent @event) {

		if (Input.IsActionJustPressed("player_action_use"))
			_tween!.Play();

		else if (Input.IsActionJustReleased("player_action_use"))
		{
			_tween!.Stop();
			Value = 0;
		}

	}

}
