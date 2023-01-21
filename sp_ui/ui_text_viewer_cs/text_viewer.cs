using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Obj.ui;

/*
	@single
*/

public partial class text_viewer :Control
{

    public static text_viewer? instance;

    [Export(PropertyHint.File)]
    string path_richtext;

    public enum task_type
    {
        tp_wait, //在package_text中有意义
        tp_txt,
        tp_clear
    }

    [Export]
    public int num_txt_node { get; set; }

    [Export]
    Godot.Collections.Dictionary<string, text_container> container_list;

    //Queue<text_richtext_node> pool_txt_node = new Queue<text_richtext_node>();
    util.Objectpools<text_richtext_node> pools;
    PackedScene tscn_text_richtext;

    public override void _EnterTree() {
        instance = this;
    }

    async public override void _Ready() {

        //res_load
        tscn_text_richtext = await Task.Run(() => GD.Load<PackedScene>(path_richtext));


        //signal_connect
        pack_txt_exec += _exec_txt_res;


        //container初始化
        container_list = new Godot.Collections.Dictionary<string, text_container>();
        var arr_child = GetChildren();
        foreach (var it in arr_child) {
            container_list.Add(it.Name, ((text_container)it));
        }

        //pool_txt 初始化
        pools = new util.Objectpools<text_richtext_node>(num_txt_node, tscn_text_richtext,
        (node) =>
        {
            node.txt_destroy += _node_free;
        });
        /*
        for (int i = 0;i < num_txt_node;i++) {
            var node_txt = tscn_text_richtext.Instantiate<text_richtext_node>();
            //GD.Print(node_txt.Name);
            node_txt.txt_destroy += _node_free;
            pool_txt_node.Enqueue(node_txt);
        }
        */
    }

    public void _node_free(text_richtext_node node) {
        pools.push(node);
    }

    public text_richtext_node _node_get() {
        return pools.pop();
    }

    public void _show_one_msg(Dictionary para) {
        switch ((task_type)(int)para["type"]) {
            case task_type.tp_txt:
                container_list[(string)para["pos"]]._init_text(para);
                break;
            case task_type.tp_clear:
                container_list[(string)para["pos"]]._clear_child();
                break;
        }
    }

    async public void _exec_txt_res(Array<Dictionary> pack) {
        foreach (Dictionary txt in pack) {
            _show_one_msg(txt);
            if (txt.ContainsKey("sleep_time")) {
                var sleep_timer = GetTree().CreateTimer((double)txt["sleep_time"]);
                await ToSignal(sleep_timer, "timeout");
            }
        }
    }


    public Action<Array<Dictionary>>? pack_txt_exec;

}
