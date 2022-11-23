using Godot;
using Godot.Collections;

using res_collection;

namespace autoload_sp;

public partial class center_item : Node
{
    [Export]
    public Dictionary<StringName,res_item_static_data> dic_items;

    [Export]
    public Dictionary<StringName,res_weapon_static_data> dic_weapons;

    

    

}
