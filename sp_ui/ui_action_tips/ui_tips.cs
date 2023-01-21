using Godot;
using System;
using Godot.Collections;

namespace Obj.ui;

public partial class ui_tips : TextureRect
{
	[Export] 
	public Dictionary<StringName,Texture2D> tips_list { get; set; } = new();

    public static readonly string node_name = "ui_tips";

	public override void _Ready(){
		var arr_child = GetChildren();
		/*
		foreach (Node it in arr_child){
			tips_list.Add(it.Name,it as TextureRect);
		}
		*/
	}

	public void _show_tips(string tips){
		if(Texture != null)
			Visible = false;
		Texture = tips_list[tips];
		Visible = true;
	}

	public void _exit_tips(){
		if(Texture == null)
			return;
		Visible = false;
		Texture = null;
	}

}
