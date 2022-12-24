using Godot;
using System;

namespace Obj.res_collection;

public partial class data_weapon : Resource
{
    [Export]
    public res_weapon_static_data @define;

    [Export]
    public int ammo_in;

    [Export]
    public int ammo_bag;

    [Export]
    public int sup;
    
}
