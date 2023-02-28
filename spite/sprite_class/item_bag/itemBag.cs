
namespace Obj.sp_player;

public partial class itemBag :Node, IBag
{
    public IdataItem? selected_equip => arr_equip[index_equip];
    public IdataItem? selected_supply => arr_supply[index_supply];

    public IdataItem?[] arr_equip { get; set; } = new IdataItem[IBag._max_equip];
    public IdataItem?[] arr_supply { get; set; } = new IdataItem[IBag._max_supply];

    public int index_equip;
    public int index_supply;

    public event Action? selected_changed;
    public event Action? item_changed;

    [Export]
    public Resource? init_list { get; set; }

    IdataItem?[] _get_arr(itemType type) => type switch
    {
        itemType.equip => arr_equip,
        itemType.supply => arr_supply,
        _ => arr_equip
    };

    public override void _Ready() {
        if(init_list is not null)
            _init_bag();
    }

    public void _init_bag() {
        
    }

    #region bag operations

    public void select(itemType type, int index) {
        switch (type) {
            case itemType.equip:
                index_equip = index;
                break;
            case itemType.supply:
                index_supply = index;
                break;
        }

        selected_changed?.Invoke();
    }

    public void drop(itemType type, int index) {
        IdataItem? discardItem;
        var arr = _get_arr(type);
        discardItem = arr[index];
        arr[index] = null;
        //TODO: drop process

    }

    public void pick(itemType type, int index, IdataItem pick_item) {
        var arr = _get_arr(type);
        arr[index] = pick_item;
    }


    public void swap(itemType type, int index, IdataItem pick_item) {
        var arr = _get_arr(type);
        var swap_item = arr[index];
        arr[index] = pick_item;

        //TODO: swap process
    }

    #endregion
}