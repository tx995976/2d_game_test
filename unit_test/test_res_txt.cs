namespace Obj.test;

[Tool]
public partial class test_res_txt :EditorScript
{
	public override void _Run(){
		var res = res_text_pack.Load("res://package_res/res_text_viewer_script/txtLine.csv.txt");
		if (res is res_text_pack) {
			GD.Print("yes");
			GD.Print(res.packName);
			res.pack_txt.ForEach(x => GD.Print(x));
		}
		
	}
}
