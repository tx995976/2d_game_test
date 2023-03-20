namespace Obj.test;

[Tool]
public partial class test_GDfile : EditorScript
{
	public override void _Run() {
		var file = GDfile.GetResFilePaths("res://resource/tres_item",".tres");
		file.ForEach(x => GD.Print(x));
	}



}
