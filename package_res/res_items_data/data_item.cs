using Godot;
using System;


namespace Obj.resource;

public sealed partial class data_item :Resource
{
    [Export]
    public res_item_static_data? @define { get; set; }

    [Export]
    public int num_now {
        get => _num_now;
        set
        {
            _num_now = value;
            signal_data_change?.Invoke();
        }
    }
    int _num_now;

    public Action? signal_data_change;
}
