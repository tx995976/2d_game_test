using Godot;
using System;

public partial class text_container : VBoxContainer
{
    [Export]
    int limit_txt;

    [Export(PropertyHint.MultilineText)]
    String re_init_str;

    public override void _Ready(){
        
    }

    public void _add_txt(){

    }

    public virtual void _init_text(){}

    [Signal]
    public delegate void new_txtEventHandler(text_richtext_node node);


}
