using Godot;
using System;

namespace Obj.res_collection;

public partial class data_item : Resource
{
    [Export]
    public res_item_static_data @define;

    [Export]
    public int num_now;

 
}
