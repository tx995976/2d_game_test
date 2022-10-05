extends VBoxContainer

class_name ui_text_container

@export var limit_txt : int

func _ready():
	new_txt.connect(self._add_txt)
	pass

func _add_txt(node):
	add_child(node)
	if not(get_child_count() < limit_txt):
		get_child(0).call("_exit_node")
	node.owner = self
	pass

func _clear_child():
	for node in get_children():
		node.call("_exit_node")
	pass

signal new_txt(node)








