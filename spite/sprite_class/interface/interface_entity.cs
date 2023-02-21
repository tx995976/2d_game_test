namespace Obj.sp_player;

#region normal_attribute

///收集可用信息给出entity的完整动作,状态
public interface Iactor
{


}

public interface Icollider
{
    public void action_hited(hit_data context) { }
    public void action_collide(KinematicCollision2D info) { }

}

public interface Iwalkable
{
    public Vector2 view_dir { get; set; }
    public Vector2 velocity_dir { get; set; }
    double speed { get; set; }

    //TODO: add data
    public void walk() { }

}

public interface Istatemut
{

    IstateMachine? motionState { get; set; }
    IstateMachine? equipState { get; set; }

}

public interface Imedia
{
    Sprite2D? texture { get; set; }
    IanimateTreeSync? animation { get; set; }
    IaudioPlayer? audioNode { get; set; }
}

public interface Iusage
{
    //TODO: Iuseage_node need
    Area2D? useRange { get; set; }
    public void trigger_usage();
}

public interface Icontrollable
{
    IroleController? controllerNode { get; set; }
}

#endregion


#region other_attributes

public interface Ihealth
{
    public int health { get; set; }
    public int armor { get; set; }
    public int banlance { get; set; }

    public event Action? health_break;
    public event Action? armor_break;
    public event Action? banlance_break;

    public void be_health_break() { }
    public void be_armor_break() { }
    public void be_banlance_break() { }

}

public interface Iequiphave
{
    IBag? bagNode { get; set; }
    

}


#endregion


#region constructor_interface

public interface IequiphaveSystem : Istatemut,Iequiphave {}

public interface Idefault_character :Icollider, Iwalkable, Ihealth, Istatemut, Imedia { }

public interface Idefault_enemy :Icollider, Iwalkable, Ihealth, Istatemut, Imedia { }


#endregion