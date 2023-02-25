using Obj.sp_player;

namespace Obj.test;

[Tool]
public partial class test_res_txt : EditorScript
{
	public override void _Run() {
		var res = GD.Load("res://texture/package_sprite/data_animationBlend_test1.tres");
		if (res is not res_animation_blend)
		{
			GD.Print("yes");
			GD.Print(res.Get("blend_path"));
		}

	}

	public static void test(){
		var res = GD.Load("res://texture/package_sprite/data_animationBlend_test1.tres");
		GD.Print("get");
		if (res is res_item_static_data resblend)
		{
			GD.Print(resblend);
		}
	}
}
