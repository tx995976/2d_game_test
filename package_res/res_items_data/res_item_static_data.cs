using Godot;
using System;

namespace Obj.resource;

public partial class res_item_static_data : res_item_root
{
    [Export]
    public int max_num { get; set; }

    //use_effect
    [Export]
    public Node? effect { get; set;}

}
