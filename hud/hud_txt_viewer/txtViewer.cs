using Obj.effect;

namespace Obj.hud;

public partial class txtViewer : Control, Ihud
{

	[Export]
	PackedScene? res_txtnode;

	[Export]
	double time_clear { get; set; } = 1.5;

	Dictionary<string, txtContainer> _container_list = new();
	Nodepools<txtNode>? pooltxt;

	PeriodicTimer? _clear_timer;
	txtEffect _effector = new();

	public event Action<StringName>? voice_require;

	public override void _EnterTree() {
		foreach (txtContainer container in GetChildren())
			_container_list[container.Name] = container;

	}

	public override void _Ready() {

		pooltxt = new(res_txtnode!, (x) =>
		{
			x.destroy += pooltxt!.push;
		});

		pooltxt.pushAction = (x) =>
		{
			x.txt = null;
			x.extra_effect = null;
		};

		pooltxt.getAction = (x) =>
		{
			x.Text = string.Empty;
		};

		_clear_timer = new(TimeSpan.FromSeconds(time_clear));

	}

	public void ui_show() => Visible = true;
	public void ui_hide() => Visible = false;


	async public Task exec_txt(res_text_pack pack, int index = -1) {
		await Task.CompletedTask;

		if (index != -1)
		{
			await exec_singal_txt(pack[index],pack);
			_ = call_clear();
		}
		else
		{
			foreach (var line in pack.pack_txt)
			{
				await exec_singal_txt(line,pack);
			}
			_ = call_clear();
		}
	}


	async Task exec_singal_txt(res_txtLine txtline, res_text_pack pack) {
		if(!Visible)
			return;

		var node = pooltxt!.get();
		node.txt = txtline;

		if (txtline.effect > -1)
		{
			var effect_data = pack.pack_effects[txtline.effect];
			node.extra_effect = _effector.solve(effect_data);
		}
		
		//TODO voice

		_container_list[txtline.show_pos!].add_txt(node);
		await node.show();
	}

	async Task call_clear() {
		await _clear_timer!.WaitForNextTickAsync();
		foreach (var container in _container_list.Values)
		{
			container.clear_child();
		}
	}

}
