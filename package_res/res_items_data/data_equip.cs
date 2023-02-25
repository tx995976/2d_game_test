namespace Obj.resource;

public record class data_equip : IdataItem
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