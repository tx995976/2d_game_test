namespace Obj.sp_player.entity;

#region singal_attribute

public interface Ihitable
{
    //TODO: 设计受击信息
    public void action_hited();

}

public interface Ihealth
{
    [ExportGroup("Health")]
    [Export]
    public int health { get; set; }

    [Export]
    public int armor { get; set; }

    [Export]
    public int banlance { get; set; }

    public event Action? health_break;
    public event Action? armor_break;
    public event Action? banlance_break;

    public void be_dead(); //force implementation

    public void be_armor_break() { }
    public void be_banlance_break() { }

}

public interface Iwalkable
{
    [ExportGroup("walk")]
    [Export]
    public Vector2 view_dir { get; set; }

    [Export]
    public Vector2 velocity_dir { get; set; }

    double speed { get; set; }

    //TODO: add data
    public void walk();

}

public interface Istatemut
{
    IstateMachine motionState { get; set; }
    IstateMachine equipState { get; set; }



}

public interface Ianimate
{



}

public interface Ivocal
{




}

#endregion


#region constructor_atributes

public interface default_character :Ihitable, Iwalkable, Ihealth, Istatemut, Ianimate, Ivocal
{

}


#endregion