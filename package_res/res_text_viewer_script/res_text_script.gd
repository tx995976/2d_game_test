@tool
extends EditorScript

@export_file var path_json

var path_txt = "res://icon.png"
var res_pack = preload("res://package_res/res_text_viewer_script/res_text_pack.cs")

func _init_package(path):
	
	pass
	
func _run() -> void:
	_init_package(path_txt)
	pass

	
