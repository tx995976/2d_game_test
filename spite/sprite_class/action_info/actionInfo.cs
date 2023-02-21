namespace Obj.sp_player;


public class actionInfo
{

    public StringName? motionName { get; set; }
    public StringName? equipStateName { get; set; }

    public StringName? equipName { get; set; }

    public StringName? actionName { get; set; }

    //required
    Istatemut Source { get; set; }
    Iequiphave equipSource { get; set; }

    public event Action? stateChanged;
    
    public actionInfo(Istatemut owner){
        Source = owner;
        equipSource = (Iequiphave)owner;
    }

    public void _Ready(){
        if(Source.motionState is not null)
            Source.motionState.state_changed += motion_changed;
        if(Source.equipState is not null)
            Source.equipState.state_changed += equip_state_changed;
        
        //TODO: 完成 Iequiphave后补充

    }

    public void invoke_action(StringName name, Action action){
        actionName = name;
        action.Invoke();

    }

    void motion_changed(string name){
        motionName = name;
    }

    void equip_state_changed(string name){
        equipStateName = name;
    }

    void equip_changed(string name){
        equipName = name;
    }

}