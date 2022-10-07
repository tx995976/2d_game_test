extends Control

@export var num_txt := 20
@export_file var scirpt_json_path : String :
	set(value):
		txt_loader._load_json(value)
		return

@onready var txt_info := get_node("info_viewer") as ui_text_container
@onready var txt_top := get_node("top_viewer") as ui_text_container
@onready var txt_talk := get_node("talk_viewer") as ui_text_container
@onready var txt_loader := get_node("loader") as ui_text_json_loader

var res_node_txt := preload("res://sp_ui/ui_text_viewer/text_richtext_node.tscn")

enum {TP_txt = 0,TP_wait = 1,TP_clear = 2}
enum {POS_INFO,POS_TOP,POS_TALK}

var pool_text_node := []

#basic
func _ready():
	for i in range(num_txt):
		var node_text :=  res_node_txt.instantiate() as ui_text_richtext_node
		pool_text_node.append(node_text)
		node_text.txt_destroy.connect(self._node_free)

	txt_script_in.connect(self._play_by_script)

	pass

func _get_txt_node():
	if not (pool_text_node.is_empty()):
		return pool_text_node.pop_front()
	pass

func _node_free(node):
	pool_text_node.push_back(node)
	pass
#basic

#txt_init
const re_txt_info := "[color=%s]%s[/color]"
const re_txt_top := "[color=%s]%s[/color]"
const re_txt_talk := "[color=%s]%s[/color] [color=%s]%s[/color]"

func _init_info(info_str: Dictionary):
	var txt := _get_txt_node() as ui_text_richtext_node
	txt.flag_txt_type = info_str['income_type'] as int
	txt.txt_time_left = info_str['appear_time']
	txt.txt_static = re_txt_info % [info_str['str_color'],info_str['str']]

	if(info_str.has('time')):
		txt.date_time = info_str['time']
		txt.time_direct = info_str['time_direct']
		txt.flag_flush_delta = true
	txt_info._add_txt(txt)
	pass

func _init_top(info_str: Dictionary):
	var txt := _get_txt_node() as ui_text_richtext_node
	txt.flag_txt_type = info_str['income_type'] as int
	txt.txt_time_left = info_str['appear_time']
	txt.txt_static = re_txt_top % [info_str['str_color'],info_str['str']]

	if(info_str.has('time')):
		txt.date_time = info_str['time']
		txt.time_direct = info_str['time_direct']
		txt.flag_flush_delta = true
	txt_top._add_txt(txt)
	pass

func _init_talk(info_str: Dictionary):
	var txt := _get_txt_node() as ui_text_richtext_node
	txt.flag_txt_type = info_str['income_type'] as int
	txt.txt_time_left = info_str['appear_time']
	txt.txt_static = re_txt_talk % [info_str['name_color'],info_str['name'],info_str['str_color'],info_str['str']]
	txt_talk._add_txt(txt)
	pass
#txt_init

#txt_running
func _str_one_shot(info_str: Dictionary):
	match info_str["type"] as int:
		TP_wait:
			var sleep_timer := get_tree().create_timer(info_str['sleep_time'])
			await sleep_timer.timeout
			return
		TP_txt:
			match info_str['pos']:
				'info':
					_init_info(info_str)
				'top':
					_init_top(info_str)
				'talk':
					_init_talk(info_str)
			return
		TP_clear:
			match info_str['pos']:
				'info':
					txt_info._clear_child()
				'top':
					txt_top._clear_child()
				'talk':
					txt_info._clear_child()
			return
	return

func _play_by_script(txt_array:Array):
	for per_txt in txt_array:
		await _str_one_shot(per_txt)
	pass
#txt_running


#signal
signal txt_script_in(txt_array)
#signal

