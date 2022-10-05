extends Node

@export_file var text_json :
	set(value):
		_load_json(value)
		return

func _load_json(path):
	var txt :=  FileAccess.open(path,FileAccess.READ)
	var txt_dic = await JSON.parse_string(txt.get_as_text()) as Array
	owner.call("_play_by_script",txt_dic)
	return
