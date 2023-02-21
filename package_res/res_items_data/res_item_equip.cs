namespace Obj.resource;

public partial class res_item_equip :Resource, IresItem
{

    [Export]
    public StringName? item_name { get; set; }

    [Export]
    public Texture2D? item_texture { get; set; }

    [Export]
    public Texture2D? item_type_texture { get; set; }

    [Export]
    public string? comment { get; set; }


    [Export]
    public int knife_range { get; set; }//近战距离

    //sup_setting
    //消声器耐久 -1 --> no sup
    [Export]
    public int sup_max { get; set; } = -1;

    //ammo_setting
    [Export]
    public int max_ammo_in { get; set; }//最大弹匣容量

    [Export]
    public int max_range { get; set; }//子弹最大距离

    //shoot_mode
    [Export]
    public int num_bullet { get; set; }//发射模式()


}

public record class data_gun : IdataItem
{
    public IresItem? @define { get; set; }

    public int ammo_in {
        get => _ammo_in;
        set{
            _ammo_in = value;
           dataChanged?.Invoke();
        }
    }
    int _ammo_in;

    public int ammo_bag {
        get => _ammo_bag;
        set{
            _ammo_bag = value;
           dataChanged?.Invoke();
        }
    }
    int _ammo_bag;

    public int sup {
        get => _sup;
        set{
            _sup = value;
           dataChanged?.Invoke();
        }
    }
    int _sup;

    public event Action? dataChanged;
}