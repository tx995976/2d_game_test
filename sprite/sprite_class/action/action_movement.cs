namespace Obj.sp_player.action;

public static class action_movement
{
	public static void move_default(this Ibase_character data, double delta) {
		data.Velocity = (float)data.speed * data.velocity_dir;
		data.body!.MoveAndSlide();
	}

	public static void move_none(this Ibase_character data,double delta){
		logLine.debug("sprite",$"{(data as Node)} no move because choosed none");
	}





}