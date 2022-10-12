extends Control

class_name ui_text_viewer

@export var num_txt := 20
@export_file var scirpt_json_path : String :
	set(value):
		json_arr = await txt_loader._load_json(value)
		return

@export var json_arr := [] :
	set(value):
		txt_script_in.emit(value)
		return

var res_node_txt := preload("res://sp_ui/ui_text_viewer/text_richtext_node.tscn")
var txt_loader :=  ui_text_json_loader.new()

enum {TP_txt = 0,TP_wait = 1,TP_clear = 2}

var pool_text_node := []
var dic_pos_container := {}

#basic
func _ready():
	for i in range(num_txt):
		var node_text :=  res_node_txt.instantiate() as ui_text_richtext_node
		pool_text_node.append(node_text)
		node_text.txt_destroy.connect(self._node_free)

	for child in get_children():
		dic_pos_container[child.name] = child

	txt_script_in.connect(self._play_by_script)
	viewer_ready.emit()
	pass

func _get_txt_node():
	if not (pool_text_node.is_empty()):
		return pool_text_node.pop_front()
	pass

func _node_free(node):
	pool_text_node.push_back(node)
	pass
#basic

#txt_running
func _str_one_shot(info_str: Dictionary):
	match info_str["type"] as int:
		TP_wait:
			var sleep_timer := get_tree().create_timer(info_str['sleep_time'])
			await sleep_timer.timeout
			return
		TP_txt:
			dic_pos_container[info_str['pos']].call("_init_text",info_str,_get_txt_node())
			return
		TP_clear:
			dic_pos_container[info_str['pos']].call("_clear_child")
			return
	return

func _play_by_script(txt_array:Array):
	for per_txt in txt_array:
		await _str_one_shot(per_txt)
	pass
#txt_running

#signal
signal txt_script_in(txt_array)
signal viewer_ready
#signal

