namespace Obj.sp_player;

public partial class sp_temp_player_normal : CharacterBody2D, Idefault_character
{
	[Export]
	public Vector2 view_dir { get; set; }

	[Export]
	public Vector2 velocity_dir { get; set; }

	[Export]
	public double speed { get; set; }

	public IstateNodeMachine? motionState { get; set; }
	public IstateNodeMachine? equipState { get; set; }

	public Sprite2D? texture { get; set; }
	public IanimateActionSync? animation { get; set; }
	public IaudioPlayer? audioNode { get; set; }

	[Export]
	public int health { get; set; }

	[Export]
	public int armor { get; set; }
	
	[Export]
	public int banlance { get; set; }

	public event Action? health_break;
	public event Action? armor_break;
	public event Action? banlance_break;


	public actionInfo? infoAction { get; set; }

	public Action<InputEvent>? inputSource { get; set; }

	public IBag? bagNode { get; set; }


	public override void _EnterTree() {
		if(infoAction is null)
			infoAction = new(this);
		
		motionState = GetNode<IstateNodeMachine>("motionState");
		equipState = GetNode<IstateNodeMachine>("equipState");

		texture = GetNode<Sprite2D>("texture_pack");
		animation = GetNode<IanimateActionSync>("texture_pack/animation_tree");
		//audioNode = GetNode<>

		bagNode = GetNode<IBag>("item_bag");
	}

	public override void _Ready() {

		infoAction!._Ready();

	}


	public void walk(double delta) {
		Velocity = (float)speed * velocity_dir;
		MoveAndSlide();
	}


	public void be_health_break() {
		throw new NotImplementedException();
	}

	public void action_hited(hit_data context) {
		throw new NotImplementedException();
	}
}