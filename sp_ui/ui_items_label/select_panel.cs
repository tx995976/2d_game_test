using Godot;
using Godot.Collections;

using Obj.sp_player;

namespace Obj.ui;
/*
#ui_select_panel
	@响应用户输入
	@物品选择
	@物品管理
*/

public partial class select_panel : Control
{
	const int max_label = 4;

	public Array<item_label> @selecter_items = new Array<item_label>();
	public Array<weapon_label> @selecter_weapons = new Array<weapon_label>();

	
	Control @panel_item { get; set; }
	Control @panel_weapon { get; set; }

	[Export]
	Label comment_node { get; set; }

//------------------------------------------------------------------------------------
	public override void _Ready() {
		panel_pos = GetNode<Marker2D>("mid_pos").Position;
		@panel_item = GetNode<Control>("item_select");
		@panel_weapon = GetNode<Control>("weapon_select");
		comment_node = GetNode<Label>("comment");
		//
		var arr_child = @panel_item.GetChildren();
		for (int i = 0; i < max_label;i++){
			var item = (item_label)arr_child[i];
			@selecter_items.Add(item);
			item.pos_num = i; 
			item.selected += item_changed;
		}

		arr_child = @panel_weapon.GetChildren();
		for (int i = 0; i < max_label;i++){
			var item = arr_child[i] as weapon_label;
			@selecter_weapons.Add(item);
			item.pos_num = i; 
			item.selected += weapon_changed;
		}
	}

	public override void _Input(InputEvent @event) {
		if (Input.IsActionJustPressed("ui_select_item")) {
			open_item();
		}
		if (Input.IsActionJustReleased("ui_select_item")) {
			//GD.Print("get");
			close_item();
		}
		if (Input.IsActionJustPressed("ui_select_weapon")) {
			open_weapon();
		}
		if (Input.IsActionJustReleased("ui_select_weapon")) {
			close_weapon();
		}
	}

	public void flush_panel(){
		for (int i = 0; i < max_label; i++){
			@selecter_items[i].item = connect_bags?.arr_item[i];
			//@selecter_items[i].flush_label();
			@selecter_weapons[i].item_dym = connect_bags?.arr_weapon[i];
			//@selecter_weapons[i].flush_label();
		}
		GD.Print("panel_flush");
	}

//------------------------------------------------------------------------------------
	[Export]
	public sp_item_bags connect_bags;
		
	[Export]
	public double tween_time;

	Vector2 panel_pos;
	//Array<Vector2> dir_label = new Array<Vector2> { Vector2.Up, Vector2.Right, Vector2.Down, Vector2.Left };
	int @pos_item = 1,@pos_weapon = 1;

//------------------------------------------------------------------------------------
	public void open_item() {
		if (@panel_item.Visible)
			return;

		flush_panel();

		for (int i = 0; i < max_label; i++)
				@selecter_items[i].Visible = true;
		comment_node.Visible = true;

		//ani
		var tween_node = GetTree().CreateTween()
			.SetTrans(Tween.TransitionType.Back)
			.SetEase(Tween.EaseType.Out)
			.SetParallel(true);
		
		for (int i = 0; i < max_label; i++) {
			var node_label = @selecter_items[i];
			tween_node.TweenProperty(node_label, "position", node_label.pos_open, tween_time)
			.From(panel_pos);
		}
		@panel_item.Visible = true;
		//

	}

	async public void close_item() {
		//GD.Print("get");
		var tween_node = GetTree().CreateTween()
				.SetTrans(Tween.TransitionType.Back)
				.SetEase(Tween.EaseType.Out);

		//ani
		for (int i = 0; i < max_label; i++)
			if(i != @pos_item)
				@selecter_items[i].Visible = false;
		
		var sel_item = @selecter_items[@pos_item];
		(sel_item.Material as ShaderMaterial).SetShaderParameter("change_flag",true);
		tween_node.TweenProperty(sel_item,"position", panel_pos, tween_time*2);
		
		//data ----> [bag] [label]
		if (connect_bags != null) 
			//connect_bags.item_num = @pos_item;

		//

		comment_node.Visible = false;
		

		await ToSignal(tween_node,"finished");
		//wait panel close
		(sel_item.Material as ShaderMaterial).SetShaderParameter("change_flag",false);
		@panel_item.Visible = false;
		sel_item.Position = panel_pos;
	}

	public void item_changed(int pos){
		comment_node.Text = @selecter_items[pos].get_commit();

		if (pos == @pos_item)
			return;

		@selecter_items[@pos_item]._mouse_exit();
		@pos_item = pos;
	}

//----------------------------------------------------------------------------------

public void open_weapon() {
		if (@panel_weapon.Visible)
			return;

		flush_panel();

		for (int i = 0; i < max_label; i++)
				@selecter_weapons[i].Visible = true;
		comment_node.Visible = true;

		//ani
		var tween_node = GetTree().CreateTween()
			.SetTrans(Tween.TransitionType.Back)
			.SetEase(Tween.EaseType.Out)
			.SetParallel(true);
		
		for (int i = 0; i < max_label; i++) {
			var node_label = @selecter_weapons[i];
			tween_node.TweenProperty(node_label, "position", node_label.pos_open, tween_time)
			.From(panel_pos);
		}
		@panel_weapon.Visible = true;
		//

	}

	async public void close_weapon() {
		//GD.Print("get");
		var tween_node = GetTree().CreateTween()
			.SetTrans(Tween.TransitionType.Back)
			.SetEase(Tween.EaseType.Out);

		//ani
		for (int i = 0; i < max_label; i++)
			if(i != @pos_weapon)
				@selecter_weapons[i].Visible = false;
		
		var sel_item = @selecter_weapons[@pos_weapon];
		(sel_item.Material as ShaderMaterial).SetShaderParameter("change_flag",true);
		tween_node.TweenProperty(sel_item,"position", panel_pos, tween_time*2);
		
		//data ----> [bag] [label]
		if (connect_bags != null) 
			//connect_bags.item_num = @pos_item;

		//

		comment_node.Visible = false;

		await ToSignal(tween_node,"finished");
		//wait panel close
		(sel_item.Material as ShaderMaterial).SetShaderParameter("change_flag",false);
		@panel_weapon.Visible = false;
		sel_item.Position = panel_pos;
	}

	public void weapon_changed(int pos){
		comment_node.Text = @selecter_weapons[pos]?.item_dym?.define.comment;

		if (pos == @pos_weapon)
			return;

		@selecter_weapons[@pos_weapon]._mouse_exit();
		@pos_weapon = pos;
	}

//----------------------------------------------------------------
	public void open_panel(int tab) {
		if (@panel_item.Visible || @panel_weapon.Visible)
			return;

		flush_panel();

		for (int i = 0; i < max_label; i++)
				@selecter_items[i].Visible = true;

		comment_node.Visible = true;
		//ani
		var tween_node = GetTree().CreateTween()
			.SetTrans(Tween.TransitionType.Back)
			.SetEase(Tween.EaseType.Out)
			.SetParallel(true);
		
		for (int i = 0; i < max_label; i++) {
			var node_label = @selecter_items[i];
			tween_node.TweenProperty(node_label, "position", node_label.pos_open, tween_time)
			.From(panel_pos);
		}
		@panel_item.Visible = true;
		//

	}

	async public void close_panel(int tab) {
		//GD.Print("get");
		var tween_node = GetTree().CreateTween()
			.SetTrans(Tween.TransitionType.Back)
			.SetEase(Tween.EaseType.Out);

		//ani
		for (int i = 0; i < max_label; i++)
			if(i != @pos_item)
				@selecter_items[i].Visible = false;
		
		var sel_item = @selecter_items[@pos_item];
		(sel_item.Material as ShaderMaterial)?.SetShaderParameter("change_flag",true);
		tween_node.TweenProperty(sel_item,"position", panel_pos, tween_time*2);
		
		//data ----> [bag] [label]
		if (connect_bags != null) 
			connect_bags.item_num = @pos_item;

		//

		comment_node.Visible = false;

		await ToSignal(tween_node,"finished");
		//wait panel close
		(sel_item.Material as ShaderMaterial)?.SetShaderParameter("change_flag",false);
		@panel_item.Visible = false;
		sel_item.Position = panel_pos;
	}

}
