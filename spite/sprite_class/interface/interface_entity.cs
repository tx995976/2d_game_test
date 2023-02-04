
namespace Obj.sp_player;

#region singal_attribute

public interface Ihitable
{
	
	public void action_hited(hitData context);

}

public interface Ihealth
{
	public int health { get; set; }

	public int armor { get; set; }

	public int banlance { get; set; }

	public event Action? health_break;
	public event Action? armor_break;
	public event Action? banlance_break;

	public void be_health_break(); //force implementation

	public void be_armor_break() { }
	public void be_banlance_break() { }

}

public interface Iwalkable
{

	public Vector2 view_dir { get; set; }

	public Vector2 velocity_dir { get; set; }

	double speed { get; set; }

	//TODO: add data
	public void walk();

}

public interface Istatemut
{

	IstateMachine? motionState { get; set; }
	IstateMachine? equipState { get; set; }

}

public interface Ianimate
{
	IanimateTreeSync? nodeAnimateSync { get; set; }
	IspriteTexture? nodeTexture { get; set; }

}

public interface Ivocal
{


}


#endregion


#region other_atributes
public interface Iequiphave
{
	
}

public interface Iusage
{
	Area2D? use_range { get; set; }

	public void trigger_usage();
}

#endregion


#region constructor_atributes

public interface Idefault_character :Ihitable, Iwalkable, Ihealth, Istatemut, Ianimate, Ivocal
{

}


#endregion