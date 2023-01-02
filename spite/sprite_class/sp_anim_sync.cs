using Godot;
using Godot.Collections;


namespace Obj.sp_player;

/*
#动画同步节点
    @根据人物数值匹配动画

*/

public partial class sp_anim_sync : AnimationTree
{
    [Export]
    public sp_player_root sp_node;

    [Export]
    public sp_state_machine common_st_node;

    [Export]
    public sp_state_machine item_st_node; // if need;

    [Export]
    public AnimationNodeStateMachinePlayback pb_now;
    
    [Export]
    public Dictionary<StringName,string> blend_params;

    [Export]
    public Dictionary<StringName,AnimationNodeStateMachinePlayback> playbacks; //if need;
    //info_state

    public string str_cm { get; set; }
    public string str_item { get; set; }

    //重写以添加params
    public override void _Ready(){
        //init
        sp_node = Owner as sp_player_root;
        
        common_st_node.state_change += cm_st_change;
        item_st_node.state_change += item_st_change;

    }

    public virtual void cm_st_change(string new_st){}
    public virtual void item_st_change(string new_st){}

}
