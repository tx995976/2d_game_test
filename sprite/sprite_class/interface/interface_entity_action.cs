namespace Obj.sp_player;

public interface Iaction_character : Ibase_character
{
    
    // Iwalk
    Action<Ibase_character,double>? walk_action { get; set; }
    Action<Ibase_character,double>? move_action { get; set; }

    //Icollider
    Action<Ibase_character,KinematicCollision2D>? collide_action { get; set; }

    //Ihealth
    public event Action<Ibase_character,int>? health_changing;
	public event Action<Ibase_character,int>? armor_changing;
	public event Action<Ibase_character,int>? banlance_changing;

	public event Action<Ibase_character,int>? health_changed;
	public event Action<Ibase_character,int>? armor_changed;
	public event Action<Ibase_character,int>? banlance_changed;

    
}