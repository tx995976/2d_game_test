namespace Obj.hud;

public partial class itemSelector : Control
{
	/// requires ShaderMaterial
	List<itemLabel> _itemLabels = new();
	List<Vector2> _default_panel_pos = new();

	Marker2D? _pos_panel;

	public int select_index = default;

	public event Action<int>? SelectChanged;

	public override void _EnterTree() {
		var child = GetChildren().ToArray();
		int index = 0;
		foreach (var node in child)
		{
			if (node is itemLabel label)
			{
				_itemLabels.Add(label);
				_default_panel_pos.Add(label.Position);
				int id = index++;
				label.MouseEntered += () => mouseSelected(id);
			}
		}

		_pos_panel = GetNode<Marker2D>("pos_panel");

		effect_panel_init();
	}

	public void mouseSelected(int index) {
		select_index = index;

		shader_effect_check(select_index, false);
		shader_effect_check(index, true);
	}

	public void open_select() {
		effect_panel(true);
	}

	public void end_select() {
		effect_panel(false);
		SelectChanged?.Invoke(select_index);
	}

	#region animation_effects

	[Export]
	double _tween_time = 1.5;

	Tween? _tweenOpen;
	Tween? _tweenClose;

	public void shader_effect_check(int index, bool flag) {
		(_itemLabels[index].Material as ShaderMaterial)?
			.SetShaderParameter("selec_flag", flag);
	}

	public void shader_effect_select(int index, bool flag) {
		(_itemLabels[index].Material as ShaderMaterial)?
			.SetShaderParameter("change_flag", flag);
	}

	async public void effect_panel(bool flag) {
		if (flag)
		{
			foreach (var item in _itemLabels)
				item.Visible = true;
			_tweenOpen!.Play();
		}
		else
		{
			for (int i = 0;i < _itemLabels.Count;i++)
			{
				if (i != select_index)
					_itemLabels[i].Visible = false;
			}
			shader_effect_select(select_index, true);
			_tweenClose!.Play();

			await ToSignal(_tweenClose, Tween.SignalName.Finished);

			shader_effect_select(select_index, false);
			_itemLabels[select_index].Visible = false;
		}
	}

	public void effect_panel_init() {
		_tweenOpen = CreateTween()
			.SetTrans(Tween.TransitionType.Back)
			.SetEase(Tween.EaseType.Out)
			.SetParallel(true);
		_tweenOpen.Stop();
		_tweenOpen.Finished += () => _tweenOpen.Stop();

		var pos = _default_panel_pos.GetEnumerator();
		foreach (var item in _itemLabels)
		{
			_tweenOpen.TweenProperty(item, "position", pos.Current, _tween_time)
				.From(_pos_panel!.Position);
			pos.MoveNext();
		}

		_tweenClose = CreateTween()
			.SetTrans(Tween.TransitionType.Back)
			.SetEase(Tween.EaseType.Out)
			.SetParallel(true);
		_tweenClose.Stop();
		_tweenClose.Finished += () => _tweenClose.Stop();

		foreach (var item in _itemLabels)
		{
			_tweenClose.TweenProperty(item, "position", _pos_panel!.Position, _tween_time)
				.FromCurrent();
		}
	}

	#endregion
}