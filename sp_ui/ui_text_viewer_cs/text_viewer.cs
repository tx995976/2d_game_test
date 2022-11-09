using Godot;
using Godot.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public partial class text_viewer : Control{

	[Export(PropertyHint.File)]
	string path_richtext;

	public enum task_type{
		tp_wait,
		tp_txt,
		tp_clear
	}

	[Export]
	int num_txt_node;

	[Export]
	Godot.Collections.Dictionary<string,text_container> container_list;

	Queue<text_richtext_node> pool_txt_node = new Queue<text_richtext_node>();
	PackedScene tscn_text_richtext;

	public override void _Ready(){
		
		//res_load
		tscn_text_richtext = GD.Load<PackedScene>(path_richtext);

		//signal_connect
		pack_txt_exec += _exec_txt_res;
		

		//container初始化
		container_list = new Godot.Collections.Dictionary<string, text_container>();
		var arr_child = GetChildren();
		foreach(Node it in arr_child){
			container_list.Add(it.Name,(it as text_container));
		}

		//pool_txt 初始化
		for(int i = 0;i < num_txt_node;i++){
			var node_txt = tscn_text_richtext.Instantiate<text_richtext_node>();
			node_txt.txt_destroy += _node_free;
			//GD.Print(node_txt.Name);
			pool_txt_node.Enqueue(node_txt);
		}
	}

	public void _node_free(text_richtext_node node){
		pool_txt_node.Enqueue(node);
	}

	public text_richtext_node _node_get(){
		return new text_richtext_node();
	}

	async public Task _show_one_msg(Dictionary para){
		switch((task_type)(int)para["type"]){
			case task_type.tp_wait:
				var sleep_timer = GetTree().CreateTimer((double)para["sleep_time"]);
				await ToSignal(sleep_timer,"timeout");
				break;
			case task_type.tp_txt:
				container_list[(string)para["pos"]]._init_text(para);
				if(!para.ContainsKey("sleep_time"))
					return;
				// bug? -> sleep_timer #define place; 
				sleep_timer = GetTree().CreateTimer((double)para["sleep_time"]);
				await ToSignal(sleep_timer,"timeout");
				break;
			case task_type.tp_clear:
				container_list[(string)para["pos"]]._clear_child();
				break;
		}
	}

	async public void _exec_txt_res(Array<Dictionary> pack){
		foreach(Dictionary txt in pack){
			await _show_one_msg(txt);
		}
	}

	[Signal]
	public delegate void pack_txt_execEventHandler(Array<Dictionary> packs);

}
