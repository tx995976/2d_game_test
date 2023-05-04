namespace Obj.sp_player;

#region normal_attribute

///收集可用信息给出entity的完整动作,状态
public interface Iactor
{
	actionInfo? infoAction { get; set; }
	CharacterBody2D? body { get; set; }
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

	public void walk(double delta) { }

	public event Action<CharacterBody2D,double>? move_action;
	public event Action<CharacterBody2D,double>? walk_action;
}

public interface Istatemut
{
	IstateNodeMachine? motionState { get; set; }
	IstateNodeMachine? equipState { get; set; }
}

public interface Imedia
{
	
	Sprite2D? texture { get; set; }
	IanimateActionSync? animation { get; set; }
	IaudioPlayer? audioNode { get; set; }
}

public interface Iusage
{
	//TODO: Iusage_node need
	Area2D? useRange { get; set; }
	
}

public interface Icontrollable
{
	Action<InputEvent>? inputSource { get; set; }
}

#endregion


#region other_attributes

public interface Ihealth
{
	public int health { get; set; }
	public int armor { get; set; }
	public int banlance { get; set; }

	public event Action<Ihealth,int>? health_changing;
	public event Action<Ihealth,int>? armor_changing;
	public event Action<Ihealth,int>? banlance_changing;

	public event Action<Ihealth,int>? health_changed;
	public event Action<Ihealth,int>? armor_changed;
	public event Action<Ihealth,int>? banlance_changed;

}

public interface Iequiphave
{
	IBag? bagNode { get; set; }

}

#endregion


#region constructor_interface

public interface Idefault_character : Icollider, Iwalkable, Ihealth, Istatemut, Imedia, Iactor, Icontrollable, Iequiphave { }

public interface Ibase_character : Icollider, Iwalkable, Ihealth, Istatemut, Imedia, Iactor, Icontrollable, Iequiphave {}


#endregion