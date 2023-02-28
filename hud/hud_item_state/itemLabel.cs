namespace Obj.hud;

public partial class itemLabel : Panel
{
	public TextureRect? _item_tex;
	public TextureRect? _item_type_tex;

	public Label? _name_item;
	public Label? _info_ammo;

	public ProgressBar? _progress;
	public Label? _info_progress;

	public IdataItem? itemdata {
		get => _itemdata;
		set{
			if(_itemdata == value)
				return;

			if(_itemdata is not null)
				_itemdata.dataChanged -= OndataChanged;
			reset();

			_itemdata = value;
			if(_itemdata is not null){
				_itemdata.dataChanged += OndataChanged;
				_itemdata.draw_data(this);
			}
		}
	}
	private IdataItem? _itemdata;

	public override void _EnterTree() {
		_item_tex = GetNode<TextureRect>("item_tex");
		_item_type_tex = GetNode<TextureRect>("item_type_tex");
		_name_item = GetNode<Label>("name_item");
		_info_ammo = GetNode<Label>("info_ammo");
		_progress = GetNode<ProgressBar>("progress");
		_info_progress = GetNode<Label>("progress/info_progress");

	}

	public void reset(){
		_item_tex!.Texture = null;
		_item_type_tex!.Texture = null;
		_name_item!.Text = string.Empty;
		_info_ammo!.Text = string.Empty;

		_progress!.Visible = false;
	}

	public void OndataChanged() => _itemdata!.update_data(this);

}
