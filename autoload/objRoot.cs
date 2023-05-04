namespace Obj.autoload;

public partial class objRoot : Node
{

	public override void _EnterTree() {
		pre_setting();

		//serve start
		ObjMain.root = this;
		ObjMain.hudServe = new(this);
		ObjMain.mediaServe = new(this);
		ObjMain.itemServe = new(this);
		ObjMain.cmdServe = new(this);
		ObjMain.gameplayServe = new(this);

		finish_setting();
	}

	public void pre_setting() {
		System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.LowLatency;

		tool.logLine.pushAction = tool.tool_log._instance.log;

		
	}

	public void finish_setting() {
		tool.logLine.info("system", "initialized");
	}


}
