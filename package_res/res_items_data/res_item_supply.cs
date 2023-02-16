namespace Obj.resource;

public partial class res_item_supply : Resource,IresItem
{
	
	[Export]
	public StringName? item_name { get; set; }

	[Export]
	public Texture2D? item_texture { get; set; }

	[Export]
	public Texture2D? item_type_texture { get; set; }

	[Export(PropertyHint.MultilineText)]
	public string? comment { get; set; }

    [Export]
    public int max_num { get; set; }

    //use_effect
    [Export]
    public Node? effect { get; set;}


}

public record class data_supply : IdataItem
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