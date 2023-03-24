namespace Obj.ui;

public partial class txtNode : RichTextLabel
{
	public static double tween_time = 1.0;
	public static double exit_item = 0.5;

	public event Action<txtNode>? destroy;

	public Action<txtNode>? extra_effect;
	public Action? voice_action;

	public bool isActive = false;

	public res_txtLine? txt;

	public override void _Ready() {
		init_effect();
	}

	async public Task show() {
		if (txt is null) return;

		isActive = true;

		if (txt.time_sleep != 0)
			await Task.Delay(TimeSpan.FromSeconds(txt.time_sleep));

		Text = txt.text_bbcode;
		if (extra_effect != null)
			_ = Task.Run(() => extra_effect.Invoke(this));
		effect_out(txt.effect_out);

		//TODO: voice
		voice_action?.Invoke();

		if (txt.time_apply != 0){
			await Task.Delay(TimeSpan.FromSeconds(txt.time_apply));
			_ = dispose();
		}
	}

	async public Task dispose() {
		isActive = false;
		
		effect_out(-1);
		await ToSignal(_exit_tween,Tween.SignalName.Finished);

		this.RemoveSelf();
		destroy?.Invoke(this);
	}

	#region font_effect

	Tween? _ratio_tween;
	Tween? _alpha_tween;

	Tween? _exit_tween;

	public void init_effect() {
		_ratio_tween = this.CreateStopTween();
		_alpha_tween = this.CreateStopTween();
		_exit_tween = this.CreateStopTween(() => this.Modulate = new(1,1,1,1));

		_ratio_tween.TweenProperty(this, "visible_ratio", 1.0, tween_time)
			.From(0.0);

		_alpha_tween.TweenProperty(this, "modulate:a", 1.0, tween_time)
			.From(0.0);

		_exit_tween.TweenProperty(this, "modulate:a", 0.0, tween_time / 2)
			.From(1.0);
	}

	public void effect_out(int type) {
		var tween = type switch
		{
			-1 => _exit_tween,
			0 => _ratio_tween,
			1 => _alpha_tween,
			_ => null
		};
		tween?.Play();
	}

	#endregion

}
