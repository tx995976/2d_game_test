namespace Obj.sp_player;

public partial class animateTreeSync :AnimationTree, IanimateTreeSync
{
    public Istatemut? stateSource { get; set; }

    [Export]
    public Resource? animationBlend { get; set; }

    [Export]
    public string? playbackPath { get; set; }

    res_animation_blend? blend_param;
    Iwalkable? walkSource;
    AnimationNodeStateMachinePlayback? pb_back;

    public override void _Ready() {
        stateSource = (Istatemut)Owner;
        walkSource = (Iwalkable)Owner;

        stateSource.motionState!.state_changed += motionStateChanged;
        stateSource.equipState!.state_changed += equipStateChanged;


        pb_back = (AnimationNodeStateMachinePlayback)Get(playbackPath);

        if(animationBlend is not null)
            blend_param = (res_animation_blend)animationBlend;
        else{
            GD.Print(this+" no animation blend");
        }
    }

    public override void _Input(InputEvent @event) {
        foreach(var i in blend_param!.blend_path){
            Set(i!,walkSource!.view_dir);
        }
    }

    public void Travel(string state) {
        pb_back!.Travel(state);

    }
    public void motionStateChanged(string state) {
        pb_back!.Travel(state+"_"+stateSource!.equipState!.state_now!.name);
    }

    public void equipStateChanged(string state) {
        pb_back!.Travel(stateSource!.motionState!.state_now!.name+"_"+state);
    }

    public void actionOccurred(string action)
    {
        throw new NotImplementedException();
    }
}