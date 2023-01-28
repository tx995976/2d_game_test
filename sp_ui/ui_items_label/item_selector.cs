using System.Collections.Generic;

namespace Obj.ui;

public partial class item_selector :Panel
{

	public List<item_label> items = new List<item_label>();

	public int select_label { get; set; }

	public Vector2 mid_position { get; set; }

	public override void _Ready() {
		//init label
		var labels = GetChildren();
		var num = 0;
		foreach (item_label item in labels) {
			item.pos_num = num++;
			item.select += select_changed;
			items.Add(item);
		}


	}

	public void select_changed(int pos) {
		items[select_label]._mouse_exit();
		select_label = pos;
	}

	public void open_select() {

	}

	public int end_select() {
		
		return select_label;
	}

	#region animation




	#endregion


}
