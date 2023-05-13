namespace Obj.sp_player;

public partial class playerCtrlPack : Node2D,Icontrollable
{
	public Icontrollable? player;

	Camera2D? camera;
	IroleController? roleController;

	#region action

	public Action<InputEvent>? eventInput_action { get; set; }
	public Action<Vector2>? veldirInput_action { get; set; }
	public Action<Vector2>? viewInput_action { get; set; }

	[Export]
	public double speed { get; set; } = 400.0;

	public Vector2 Veldir { get; set; }

	#endregion

	public override void _Ready() {
		camera = GetNode<Camera2D>("main_view");
		roleController = GetNode<IroleController>("controller");
		SetPhysicsProcess(false);

		veldirInput_action = veldir_input;
	}

	public void _switch(Node2D _player) {
		SetPhysicsProcess(false);
		
		if (_player is Icontrollable ctrlNode)
		{
			this.MoveSelf(_player);
			Position = Vector2.Zero;

			player = ctrlNode;
			roleController!.ctrlSource = ctrlNode;

			camera!.Enabled = true;
		}
	}

	public void free_view() {
		if (player is not null)
		{
			GlobalPosition = (player as Node2D)!.GlobalPosition;
			this.MoveSelf(ObjMain.root);
		}
		roleController!.ctrlSource = this;
		SetPhysicsProcess(true);
	}


	public override void _PhysicsProcess(double delta) {
		if(Veldir != Vector2.Zero){
			Position += Veldir * (float)(speed * delta);
		}
	}

	void veldir_input(Vector2 dir) => Veldir = dir;





}
