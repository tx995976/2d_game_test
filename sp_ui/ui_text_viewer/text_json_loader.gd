extends RefCounted

class_name ui_text_json_loader

func _load_json(path):
	var txt :=  FileAccess.open(path,FileAccess.READ)
	var txt_dic := await JSON.parse_string(txt.get_as_text()) as Array
	return txt_dic
