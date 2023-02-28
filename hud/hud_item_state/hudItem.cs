using Obj.sp_player;

namespace Obj.hud;

public partial class hudItem : Control, Ihud
{
	public IBag? current_bag { get; set; }

	itemLabel? _label_equip;
	itemLabel? _label_supply;

	itemSelector? _selector_equip;
	itemSelector? _selector_supply;


	public void ui_hide() {
		Visible = false;
	}

	public void ui_show() {
		Visible = true;
	}
}