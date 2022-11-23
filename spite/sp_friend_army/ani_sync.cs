using Godot;
using Godot.Collections;
using sp_player_collections;

namespace sp_player_friend_1;

public partial class ani_sync : sp_anim_sync
{

    public override void _Ready(){
        base._Ready();
        //blend
        blend_params = new Dictionary<StringName, string>{
            {"change_none","parameters/sp_status/change_none/blend_position"},
            {"change_weapon","parameters/sp_status/change_weapon/blend_position"},
            {"idle","parameters/sp_status/idle/blend_position"},
            {"idle_weapon","parameters/sp_status/idle_weapon/blend_position"},
            {"walk","parameters/sp_status/walk/blend_position"},
            {"walk_weapon","parameters/sp_status/walk_weapon/blend_position"}
        };
        //playbacks
        pb_now = (AnimationNodeStateMachinePlayback)Get("parameters/sp_status/playback");
        //
        str_cm = common_st_node?.start_state.Name;
        

        GD.Print($"ani_state : {str_cm} {str_item}");
    }

    public override void _PhysicsProcess(double delta){
        //params_sync
        Set(blend_params["change_none"],sp_node.view_dir);
        Set(blend_params["change_weapon"],sp_node.view_dir);
        Set(blend_params["idle"],sp_node.view_dir);
        Set(blend_params["idle_weapon"],sp_node.view_dir);
        Set(blend_params["walk"],sp_node.view_dir);
        Set(blend_params["walk_weapon"],sp_node.view_dir);
    }

    public override void cm_st_change(string new_st){
        if(str_item == null){
            pb_now.Travel(new_st);
        }
        else{

        }
    }

    public override void item_st_change(string new_st){
        
    }





}
