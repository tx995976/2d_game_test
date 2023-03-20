using Obj.sp_player;

namespace Obj.hud;

public partial class hudItem : Control, Ihud
{
	public IBag? current_bag {
		get => _current_bag;
		set {
			if (_current_bag != value)
			{
				_current_bag = value;
				flush_bag();
			}
		}
	}
	IBag? _current_bag;

	itemLabel? _label_equip;
	itemLabel? _label_supply;

	itemSelector? _selector_equip;
	itemSelector? _selector_supply;

	Label? _comment;

	bool _inselected = false;

	public override void _EnterTree() {
		_label_equip = GetNode<itemLabel>("label_equip");
		_label_supply = GetNode<itemLabel>("label_supply");

		_selector_equip = GetNode<itemSelector>("selector_equip");
		_selector_supply = GetNode<itemSelector>("selector_supply");

		_comment = GetNode<Label>("comment");

		_selector_equip.SelectChanged += equip_selected;
		_selector_equip.SelectView += peek_equip_comment;

		_selector_supply.SelectChanged += supply_selected;
		_selector_supply.SelectView += peek_supply_comment;
	}

	async Task selector_change(itemType type, bool visible) {
		var selector = type switch
		{
			itemType.equip => _selector_equip,
			itemType.supply => _selector_supply,
			_ => null
		};

		_comment!.Visible = visible;

		if (visible)
			await selector!.open_select();
		else
		{
			await selector!.end_select();
		}

		_inselected = visible;
		// _label_supply!.Visible = !visible;
		// _label_equip!.Visible = !visible;
	}

	public override void _Input(InputEvent @event) {
		if (Input.IsActionJustPressed("ui_select_equip") && !_inselected)
			_ = selector_change(itemType.equip, true);

		else if (Input.IsActionJustPressed("ui_select_supply") && !_inselected)
			_ = selector_change(itemType.supply, true);

		else if (Input.IsActionJustReleased("ui_select_equip"))
			_ = selector_change(itemType.equip, false);

		else if (Input.IsActionJustReleased("ui_select_supply"))
			_ = selector_change(itemType.supply, false);
	}


	public void ui_show() => Visible = true;

	public void ui_hide() => Visible = false;


	public void equip_selected(int index) {
		current_bag?.select(itemType.equip, index);

		_label_equip!.itemdata = current_bag?.arr_equip[index];
	}

	public void supply_selected(int index) {
		current_bag?.select(itemType.supply, index);

		_label_supply!.itemdata = current_bag?.arr_supply[index];
	}

	public void peek_equip_comment(int index) {
		_comment!.Text = current_bag?.arr_equip[index]?.define!.comment;
	}

	public void peek_supply_comment(int index) {
		_comment!.Text = current_bag?.arr_supply[index]?.define!.comment;
	}

	public void flush_bag() {

		for (int i = 0;i < IBag._max_equip;i++)
		{
			_selector_equip!.itemLabels[i].itemdata = current_bag!.arr_equip[i];
			_selector_supply!.itemLabels[i].itemdata = current_bag!.arr_supply[i];
		}

		_label_equip!.itemdata = current_bag!.selected_equip;
		_label_supply!.itemdata = current_bag!.selected_supply;
	}

}
