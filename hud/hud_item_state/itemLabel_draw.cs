using Obj.hud;

namespace Obj.resource;

public partial class data_equip
{
	public void draw_data(itemLabel label) {
		var source = (res_item_equip)define!;

		label._item_tex!.Texture = source.item_texture;
		label._item_type_tex!.Texture = source.item_type_texture;
		label._name_item!.Text = source.item_name;

		if (source.sup_max != 0)
		{
			label._info_progress!.Text = "Sup";
			label._progress!.MaxValue = source.sup_max;
            label._progress!.Visible = true;
		}

        update_data(label);
	}

	public void update_data(itemLabel label) {
		label._info_ammo!.Text = $"{ammo_in} / {ammo_bag}";
		label._progress!.Value = sup;
	}

}


public partial class data_supply
{
	public void draw_data(itemLabel label) {
        var source = (res_item_supply)define!;

        label._item_tex!.Texture = source.item_texture;
		label._item_type_tex!.Texture = source.item_type_texture;
		label._name_item!.Text = source.item_name;

        update_data(label);
	}

	public void update_data(itemLabel label) { 
        label._info_ammo!.Text = $"{num_now}";
    }
}