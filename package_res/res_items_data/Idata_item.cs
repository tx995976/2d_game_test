namespace Obj.resource;


public interface IresItem
{
	public StringName item_name { get; set; }
	public Texture2D? item_texture { get; set; }
	public string? comment { get; set; }
	

}

public interface IdataItem
{
	public IresItem? @define { get; set; }

	public event Action dataChanged;

}