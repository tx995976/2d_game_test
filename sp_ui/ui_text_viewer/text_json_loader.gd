extends Node

class_name ui_text_json_loader

func _load_json(path):
	var txt :=  FileAccess.open(path,FileAccess.READ)
	var txt_dic = await JSON.parse_string(txt.get_as_text()) as Array
	owner.call("_play_by_script",txt_dic)
	return 
