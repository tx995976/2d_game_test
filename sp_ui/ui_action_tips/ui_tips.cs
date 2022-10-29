using Godot;
using System;
using Godot.Collections;


public partial class ui_tips : Control
{
	[Export]
	public Dictionary<string,TextureRect> tips_list;

	[Export]
	TextureRect tips_now;

	public override void _Ready(){
		var arr_child = GetChildren();

		foreach (Node it in arr_child){
			tips_list.Add(it.Name,it as TextureRect);
		}
	}

	public void _show_tips(string tips){
		if(tips_now != null)
			tips_now.Visible = false;
		tips_now = tips_list[tips];
		tips_now.Visible = true;
	}

	public void _exit_tips(){
		if(tips_now == null)
			return;
		tips_now.Visible = false;
		tips_now = null;
	}





}
