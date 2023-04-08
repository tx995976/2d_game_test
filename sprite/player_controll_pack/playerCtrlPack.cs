namespace Obj.sp_player;

public partial class playerCtrlPack : Node2D
{
	public Icontrollable? player;

	Camera2D? camera;
	IroleController? roleController;

	public override void _Ready() {
		camera = GetNode<Camera2D>("main_view");
		roleController = GetNode<IroleController>("controller");
	}

	public void _switch(Node2D _player) {
		if (_player is Icontrollable ctrlNode)
		{
			this.MoveSelf(_player);
			
			player = ctrlNode;
			roleController!.ctrlSource = ctrlNode;
			
			camera!.Enabled = true;
		}

	}


}
