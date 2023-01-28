namespace Obj.sp_player.entity;

public interface Ihitable
{
    //TODO: 设计受击信息
    public void action_hited();

}

public interface Ihealth
{

    public int health { get; set; }
    public int armor { get; set; }
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

    Vector2 view_dir { get; set; }
    Vector2 velocity_dir { get; set; }

    double speed { get; set; }

    //TODO: add data
    public void walk();

}

public interface Istatemut
{
    //TODO: 


}