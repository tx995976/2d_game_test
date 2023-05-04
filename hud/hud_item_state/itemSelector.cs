namespace Obj.hud;

public partial class itemSelector : Control
{
	List<Vector2> _default_panel_pos = new();

	Marker2D? _pos_panel;

	[Export]
	double _tween_time = 1.5;

	Tween? _tweenOpen;
	Tween? _tweenClose;

	/// requires ShaderMaterial
	public List<itemLabel> itemLabels = new();
	public int select_index = default;

	public event Action<int>? SelectChanged;
	public event Action<int>? SelectView;

	public event Action<int>? Dropitem;


	public override void _Ready() {
		var child = GetChildren().ToArray();
		int index = 0;
		foreach (var node in child)
		{
			if (node is itemLabel label)
			{
				itemLabels.Add(label);
				//GD.Print(label.Position);
				_default_panel_pos.Add(label.Position);
				int id = index++;
				label.MouseEntered += () =>
				{
					mouseSelected(id);
#if DEBUG
					logLine.debug("hud",$"label {id} mounted");
#endif
				};
			}
		}

		_pos_panel = GetNode<Marker2D>("pos_panel");

		effect_panel_init();

		// GD.Print("pos_panel");
		// _default_panel_pos.ForEach(x => GD.Print($"pos {x}"));
		// GD.Print($"pos marked: {_pos_panel.Position}");

	}

	public void mouseSelected(int index) {
		shader_effect_check(select_index, false);
		select_index = index;
		SelectView?.Invoke(index);
		shader_effect_check(index, true);
	}

	async public Task open_select() {
		Visible = true;
		await effect_panel(true);
	}

	async public Task end_select() {
		SelectChanged?.Invoke(select_index);
		shader_effect_check(select_index, false);
		await effect_panel(false);
		Visible = false;
	}


	#region animation_effects

	public void shader_effect_check(int index, bool flag) {
		(itemLabels[index].Material as ShaderMaterial)?
			.SetShaderParameter("selec_flag", flag);
	}

	public void shader_effect_select(int index, bool flag) {
		(itemLabels[index].Material as ShaderMaterial)?
			.SetShaderParameter("change_flag", flag);
	}

	async public Task effect_panel(bool flag) {
		if (flag)
		{
			foreach (var item in itemLabels)
				item.Visible = true;
			_tweenClose!.Stop();
			_tweenOpen!.Play();
		}
		else
		{
			for (int i = 0;i < itemLabels.Count;i++)
			{
				if (i != select_index)
					itemLabels[i].Visible = false;
			}
			shader_effect_select(select_index, true);
			_tweenOpen!.Stop();
			_tweenClose!.Play();

			await ToSignal(_tweenClose, Tween.SignalName.Finished);

			shader_effect_select(select_index, false);
			itemLabels[select_index].Visible = false;
		}

	}

	public void effect_panel_init() {
		_tweenOpen = this.CreateStopTween()
				   .SetTrans(Tween.TransitionType.Back)
				   .SetEase(Tween.EaseType.Out)
				   .SetParallel(true);

		var pos = _default_panel_pos.GetEnumerator();
		pos.MoveNext();
		foreach (var item in itemLabels)
		{
			_tweenOpen.TweenProperty(item, "position", pos.Current, _tween_time)
				.From(_pos_panel!.Position);
			//GD.Print(_pos_panel!.Position, " -> ", pos.Current);
			pos.MoveNext();
		}

		_tweenClose = this.CreateStopTween()
					.SetTrans(Tween.TransitionType.Back)
					.SetEase(Tween.EaseType.Out)
					.SetParallel(true);

		foreach (var item in itemLabels)
		{
			_tweenClose.TweenProperty(item, "position", _pos_panel!.Position, _tween_time)
				.FromCurrent();
		}
	}

	#endregion
}
