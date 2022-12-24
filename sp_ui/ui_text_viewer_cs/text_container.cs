using Godot;
using System;
using Godot.Collections;

namespace Obj.ui_collections;

public partial class text_container : VBoxContainer
{
    [Export]
    int limit_txt;

    [Export(PropertyHint.MultilineText)]
    String re_init_str;

    public text_viewer node_viewer;

    public override void _Ready(){
        node_viewer = (text_viewer)Owner;
    }

    public void _add_txt(text_richtext_node node){
        AddChild(node);
        if(GetChildCount() > limit_txt)
            GetChild<text_richtext_node>(0)._exit_node();
        node.Owner = this;
    }

    public void _clear_child(){
        foreach(text_richtext_node it in GetChildren()){
            it._exit_node();
        }
    }

    public virtual void _init_text(Dictionary para){}
    [Signal]
    public delegate void new_txtEventHandler(text_richtext_node node);

}
