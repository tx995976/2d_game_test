namespace Obj.autoload;

public partial class objRoot : Node
{

	public override void _EnterTree() {
		ObjMain.root = this;
		ObjMain.hudServe = new(this);
		ObjMain.mediaServe = new(this);
		ObjMain.itemServe = new(this);
		ObjMain.cmdServe = new(this);
		ObjMain.gameplayServe = new(this);


		System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.LowLatency;
	}




}
