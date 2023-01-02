using Godot;
using Godot.Collections;
using System.Linq;

using Obj.resource;
using System.Threading.Tasks;
// ReSharper disable All

namespace Obj.autoload;

/*
#item_center
    @物品静态数据存储
    @生成动态数据
    @新数据注册(地图包数据)
*/

public partial class center_item : Node
{
    public const string path_node = "/root/center_item";
    public const string path_data = "res://package_res/data_items/"; //default_data

    [Export]
    public Dictionary<StringName,res_item_static_data> dic_items;

    [Export]
    public Dictionary<StringName,res_weapon_static_data> dic_weapons;


    async public override void _Ready(){
        //default data load
        dic_weapons = new Dictionary<StringName, res_weapon_static_data>();
        dic_items = new Dictionary<StringName, res_item_static_data>();
        var dir_datas = DirAccess.Open(path_data);

        foreach(var filename in dir_datas.GetFiles()){
            //GD.Print(filename);
            if(filename.EndsWith(".tres")){
                GD.Print($"load {path_data+filename}");
                var res = await Task.Run(() => GD.Load(path_data+filename));
                reg_data(res);
            }
        }
    }

    //method for bags

    public data_item init_item(StringName str_item,int nums){
        var new_data = new data_item();
        new_data.define = dic_items[str_item];
        new_data.num_now = nums;
        return new_data;
    }

    public data_weapon init_weapon(StringName str_weapon,int ammo_in,int ammo_bag,int sup){
        var new_data = new data_weapon();
        var define_res = dic_weapons[str_weapon];
        //
        new_data.define = define_res;
        new_data.ammo_in = (ammo_in < new_data.define.max_ammo_in) ? ammo_in : new_data.define.max_ammo_in;
        new_data.ammo_bag = (ammo_bag < new_data.define.bag_ammo) ? ammo_bag : new_data.define.bag_ammo;
        new_data.sup = sup < (new_data.define.sup_max) ? sup : new_data.define.sup_max;
        return new_data;
    }

    public void reg_data(Resource reg_info){
        if(reg_info is res_item_static_data){
            var info = reg_info as res_item_static_data;
            if(!dic_items.ContainsKey(info.item_name))
                dic_items[info.item_name] = info;
        }
        else if(reg_info is res_weapon_static_data){
            var info = reg_info as res_weapon_static_data;
            if(!dic_weapons.ContainsKey(info.item_name))
                dic_weapons[info.item_name] = info;
        }
        else
            GD.Print($"not match resource {reg_info}");
    }

}
