using Obj.autoload;
namespace Obj.sp_player;

public interface IBag
{
    public static int _max_weapon = 4;
	public static int _max_item = 4;

    Iitem_center? item_center { get; set; }

    public event Action selected_changed;

    //TODO: Iitem


}