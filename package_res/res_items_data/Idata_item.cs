namespace Obj.resource;

public interface IresItem
{
	public StringName? item_name { get; set; }
	public Texture2D? item_texture { get; set; }
	public Texture2D? item_type_texture { get; set; }

	StringName? itemStyle { get; set; }

	public string? comment { get; set; }
	
}

public interface IdataItem
{
	public IresItem? @define { get; set; } 

	public event Action? dataChanged;

}

#region type definitions

public enum itemType : int{
    equip,
    supply
}

#endregion