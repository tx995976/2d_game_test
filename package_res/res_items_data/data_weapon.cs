using Godot;
using System;

namespace Obj.resource;

public sealed partial class data_weapon :Resource
{
    [Export]
    public res_weapon_static_data @define;

    [Export]
    public int ammo_in {
        get => _ammo_in;
        set{
            _ammo_in = value;
            signal_data_change?.Invoke();
        }
    }
    int _ammo_in;

    [Export]
    public int ammo_bag {
        get => _ammo_bag;
        set{
            _ammo_bag = value;
            signal_data_change?.Invoke();
        }
    }
    int _ammo_bag;

    [Export]
    public int sup {
        get => _sup;
        set{
            _sup = value;
            signal_data_change?.Invoke();
        }
    }
    int _sup;


    public event Action? signal_data_change;
}
