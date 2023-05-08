namespace Obj.sp_player;

//issue  不应实现Iwalkable
public partial class playerCtrlPack : Node2D, Iwalkable, Icontrollable
{
	public Icontrollable? player;

	Camera2D? camera;
	IroleController? roleController;

	#region  action
	public Vector2 view_dir { get; set; }
	public Vector2 velocity_dir { get; set; }

	public Vector2 Velocity { get; set; }
	public double speed { get; set; } = 400.0;

	public Action<double>? walk_action { get; set; }

	public Action<InputEvent>? inputSource { get; set; }
	#endregion

	public override void _Ready() {
		camera = GetNode<Camera2D>("main_view");
		roleController = GetNode<IroleController>("controller");
		SetPhysicsProcess(false);
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
		if (velocity_dir != Vector2.Zero)
			Position += velocity_dir * (float)(speed * delta);
	}



}
