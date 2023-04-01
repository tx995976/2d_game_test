using Obj.autoload;
namespace Obj.sp_player;

public interface IBag
{
    public static int _max_equip = 4;
	public static int _max_supply = 4;

    public event Action? selected_changed;
    public event Action? item_changed;
    
    public event Action<IdataItem>? Dropitem;
    public event Action<IdataItem>? Swapitem;

    IdataItem? selected_equip { get; }
    IdataItem? selected_supply { get; }

    IdataItem?[] arr_equip { get; set; }
    IdataItem?[] arr_supply { get; set; }

    void select(itemType type,int index);

    void drop(itemType type,int index);
    void pick(itemType type,int index,IdataItem pick_item);
    void swap(itemType type,int index,IdataItem pick_item);

}