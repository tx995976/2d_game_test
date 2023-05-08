using Obj.sp_player.action;

namespace Obj.sp_player;

public partial class sp_temp_player_normal : CharacterBody2D, Ibase_character
{
	#region walkable

	[Export]
	public Vector2 view_dir { get; set; }

	[Export]
	public Vector2 velocity_dir { get; set; }

	[Export]
	public double speed { get; set; }



	// public void walk(double delta) {
	// 	Velocity = (float)speed * velocity_dir;
	// 	MoveAndSlide();

	// }

	// public event Action<CharacterBody2D, double>? move_action;
	// public event Action<CharacterBody2D, double>? walk_action;

	#endregion

	#region statemut

	public IstateNodeMachine? motionState { get; set; }
	public IstateNodeMachine? equipState { get; set; }

	#endregion

	#region media

	public Sprite2D? texture { get; set; }
	public IanimateActionSync? animation { get; set; }
	public IaudioPlayer? audioNode { get; set; }

	#endregion

	#region health

	[Export]
	public int health {
		get => _health;
		set {
			health_changing?.Invoke(this, value);
			_health = value;
			health_changed?.Invoke(this, value);
		}
	}
	int _health;

	[Export]
	public int armor {
		get => _armor;
		set {
			armor_changing?.Invoke(this, value);
			_armor = value;
			armor_changed?.Invoke(this, value);
		}
	}
	int _armor;

	[Export]
	public int banlance {
		get => _banlance;
		set {
			banlance_changing?.Invoke(this, value);
			_banlance = value;
			banlance_changed?.Invoke(this, value);
		}
	}
	int _banlance;

	public event Action<Ihealth, int>? health_changing;
	public event Action<Ihealth, int>? armor_changing;
	public event Action<Ihealth, int>? banlance_changing;

	public event Action<Ihealth, int>? health_changed;
	public event Action<Ihealth, int>? armor_changed;
	public event Action<Ihealth, int>? banlance_changed;

	#endregion

	#region actor

	public actionInfo? infoAction { get; set; }
	public CharacterBody2D? body { get; set; }
	public Node2D? baseNode { get; set; }

	#endregion

	#region Controllable

	public Action<InputEvent>? inputSource { get; set; }

	#endregion

	#region equiphave

	public IBag? bagNode { get; set; }

	#endregion
	
	public Action<double>? walk_action { get; set; }

	public Action<double>? move_action { get; set; }

	public Action<KinematicCollision2D>? collide_action { get; set; }




	#region collider

	public void action_hited(hit_data context) { }
	public void action_collide(KinematicCollision2D info) { }

	#endregion

	public override void _EnterTree() {

		if (infoAction is null)
			infoAction = new(this);

		body = this;
		baseNode = this;

		motionState = GetNodeOrNull<IstateNodeMachine>("motionState");
		equipState = GetNodeOrNull<IstateNodeMachine>("equipState");
		bagNode = GetNodeOrNull<IBag>("item_bag");

		texture = GetNode<Sprite2D>("texture_pack");
		animation = GetNode<IanimateActionSync>("texture_pack/animation_tree");
		//audioNode = GetNode<>

	}

	public override void _Ready() {
		walk_action = this.move_default;

		infoAction!._Ready();
	}



}
