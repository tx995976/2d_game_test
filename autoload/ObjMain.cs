namespace Obj.autoload;

public partial class ObjMain : Node
{
	public static centerHud? hudServe;

	public static centerMedia? mediaServe;

	public static centerItem? itemServe;

	public static centerCmd? cmdServe;

	public static ObjMain? root;

	public override void _EnterTree() {
		root = this;
	//TODO: init service
		hudServe = new(this);
		mediaServe = new(this);
		itemServe = new(this);
		cmdServe = new(this);


		System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.LowLatency;
	}
}
