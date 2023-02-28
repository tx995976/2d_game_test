namespace Obj.resource;

public partial class data_supply : IdataItem
{
    public IresItem? @define { get; set; }

    public int num_now {
        get => _num_now;
        set
        {
            _num_now = value;
            dataChanged?.Invoke();
        }
    }
    int _num_now;


    public event Action? dataChanged;
}