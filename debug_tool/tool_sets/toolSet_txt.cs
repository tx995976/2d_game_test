namespace Obj.tool.toolSet;

[toolSet]
public class toolSet_txt : ItoolSet
{
	public string ToolName => "txt";

	public string exec_command(string[] args) {
		var pack_name = args[0];
        int index = -1;
		if (args.Length > 1)
		{
            int.TryParse(args[1],out index);
		}

        ObjMain.mediaServe!.call_txt_view(pack_name,index);
		return "ok";
	}
}